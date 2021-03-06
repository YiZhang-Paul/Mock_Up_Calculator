﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using FormatterClassLibrary;
using ConverterClassLibrary;

namespace UserControlClassLibrary {
    public partial class CurrencyConverterDisplay : ConverterDisplay {

        public override string InputUnit { get { return GetCurrencyCode(InputUnitBox.SelectedItem); } }
        public override string MainOutputUnit { get { return GetCurrencyCode(OutputUnitBox.SelectedItem); } }

        private ICurrencyCodeConverter Converter { get; set; }

        public CurrencyConverterDisplay(ICurrencyCodeConverter converter) : base() {

            Converter = converter;
        }

        private string GetDisplayName(string countryCode) {

            try {

                var region = new RegionInfo(countryCode);

                return region.EnglishName + " - " + region.CurrencyEnglishName;
            }
            catch(Exception) {

                return null;
            }
        }

        private string GetSymbol(object selected) {

            var item = (KeyValuePair<string, Tuple<string, string>>)selected;

            return new RegionInfo(item.Value.Item1).CurrencySymbol;
        }

        private string GetCurrencyCode(object selected) {

            var item = (KeyValuePair<string, Tuple<string, string>>)selected;

            return item.Value.Item2;
        }

        private void AddCountry(SortedDictionary<string, Tuple<string, string>> countries, string country, string currency) {

            string displayName = GetDisplayName(country);
            //ignore unsupported countries
            if(displayName != null) {

                countries[displayName] = new Tuple<string, string>(country, currency);
            }
        }

        private SortedDictionary<string, Tuple<string, string>> GetCountries(string[] currencyCodes) {

            var countries = new SortedDictionary<string, Tuple<string, string>>();

            foreach(string currencyCode in currencyCodes) {

                try {
                    //check for unsupported countries
                    foreach(string countryCode in Converter.ToCountryCode(currencyCode)) {

                        AddCountry(countries, countryCode, currencyCode);
                    }
                }
                catch(Exception) {

                    continue;
                }
            }

            return countries;
        }

        private void BindData(SortedDictionary<string, Tuple<string, string>> data, ComboBox comboBox) {

            comboBox.DataSource = new BindingSource(data, null);
            comboBox.DisplayMember = "Key";
            comboBox.ValueMember = "Value";
        }

        public override void PopulateOptions(string[] currencyCodes) {

            var countries = GetCountries(currencyCodes);
            BindData(countries, InputUnitBox);
            BindData(countries, OutputUnitBox);
            OutputUnitBox.SelectedIndex = 1;
        }

        public override void DisplayInput(string input, IFormatter formatter) {

            InputSymbolLabel.Text = GetSymbol(InputUnitBox.SelectedItem);
            InputLabel.Text = formatter.Format(input);
            InputLabel.Left = InputSymbolLabel.Right;
        }

        public override void DisplayMainOutput(string output, IFormatter formatter) {

            OutputSymbolLabel.Text = GetSymbol(OutputUnitBox.SelectedItem);
            OutputLabel.Text = formatter.Format(output);
            OutputLabel.Left = OutputSymbolLabel.Right;
        }

        public override void DisplayExtraOutputs(Tuple<string, string>[] outputs, IFormatter formatter) {

            ExtraOutputTitleLabel.Visible = true;

            for(int i = 0; i < outputs.Length; i++) {

                if(i == ExtraOutputLabels.Length) {

                    return;
                }

                if(outputs[i] != null) {

                    ExtraOutputLabels[i].Text = outputs[i].Item2 + " ";
                    ExtraOutputLabels[i].Text += formatter.Format(outputs[i].Item1);
                }
            }
        }
    }
}