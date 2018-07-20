using System;
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

        public override string InputUnit {

            get {

                return ((KeyValuePair<string, Tuple<string, string>>)InputUnitBox.SelectedItem).Value.Item2;
            }
        }

        public override string MainOutputUnit {

            get {

                return ((KeyValuePair<string, Tuple<string, string>>)OutputUnitBox.SelectedItem).Value.Item2;
            }
        }

        private ICurrencyCodeConverter Converter { get; set; }

        public CurrencyConverterDisplay(ICurrencyCodeConverter converter) : base() {

            Converter = converter;
        }

        private string GetDisplayName(string countryCode) {

            try {

                var region = new RegionInfo(countryCode);

                return region.EnglishName + " - " + region.CurrencyEnglishName;
            }
            catch(Exception exception) {

                throw exception;
            }
        }

        private string GetSymbol(object selectedItem) {

            var item = (KeyValuePair<string, Tuple<string, string>>)selectedItem;
            string countryCode = item.Value.Item1;

            return new RegionInfo(countryCode).CurrencySymbol;
        }

        private SortedDictionary<string, Tuple<string, string>> GetCountries(string[] currencyCodes) {

            var countries = new SortedDictionary<string, Tuple<string, string>>();

            foreach(string currencyCode in currencyCodes) {

                try {

                    foreach(string countryCode in Converter.ToCountryCode(currencyCode)) {

                        try {

                            string displayName = GetDisplayName(countryCode);
                            countries[displayName] = new Tuple<string, string>(countryCode, currencyCode);
                        }
                        catch(Exception) {

                            continue;
                        }
                    }
                }
                catch(Exception) {

                    continue;
                }
            }

            return countries;
        }

        public override void PopulateOptions(string[] currencyCodes) {

            var countries = GetCountries(currencyCodes);
            InputUnitBox.DataSource = new BindingSource(countries, null);
            InputUnitBox.DisplayMember = "Key";
            InputUnitBox.ValueMember = "Value";
            OutputUnitBox.DataSource = new BindingSource(countries, null);
            OutputUnitBox.DisplayMember = "Key";
            OutputUnitBox.ValueMember = "Value";
            OutputUnitBox.SelectedIndex = 1;
            OutputUnitBox.SelectedIndex = 1;
        }

        public override void DisplayInput(string input, IFormatter formatter) {

            InputLabel.Text = GetSymbol(InputUnitBox.SelectedItem) + " " + formatter.Format(input);
        }

        public override void DisplayMainOutput(string output, IFormatter formatter) {

            OutputLabel.Text = GetSymbol(OutputUnitBox.SelectedItem) + " " + formatter.Format(output);
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