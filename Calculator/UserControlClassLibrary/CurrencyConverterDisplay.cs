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

namespace UserControlClassLibrary {
    public partial class CurrencyConverterDisplay : ConverterDisplay {

        public override string InputUnit { get { return GetCurrencyName(base.InputUnit); } }
        public override string MainOutputUnit { get { return GetCurrencyName(base.MainOutputUnit); } }

        private string GetSymbol(string currency) {

            var region = new RegionInfo(currency.Substring(0, 2));

            return region.CurrencySymbol;
        }

        private string GetDisplayName(string currency) {

            var region = new RegionInfo(currency.Substring(0, 2));

            return region.EnglishName + " (" + currency + ")";
        }

        private string GetCurrencyName(string displayName) {

            return Regex.Match(displayName, @"\(\w{3}").Value.Substring(1, 3);
        }

        public override void PopulateOptions(string[] units) {

            units = units.Select(unit => GetDisplayName(unit)).ToArray();
            InputUnitBox.DataSource = units.ToArray();
            OutputUnitBox.DataSource = units.ToArray();
            OutputUnitBox.SelectedIndex = 1;
            InputLabel.Text = GetSymbol(InputUnit) + " 0";
            OutputLabel.Text = GetSymbol(MainOutputUnit) + " 0";
        }

        public override void DisplayInput(string input, IFormatter formatter) {

            InputLabel.Text = GetSymbol(InputUnit) + " " + formatter.Format(input);
        }

        public override void DisplayMainOutput(string output, IFormatter formatter) {

            OutputLabel.Text = GetSymbol(MainOutputUnit) + " " + formatter.Format(output);
        }

        public override void DisplayExtraOutputs(Tuple<string, string>[] outputs, IFormatter formatter) {

            ExtraOutputTitleLabel.Visible = true;

            for(int i = 0; i < outputs.Length; i++) {

                if(i == ExtraOutputLabels.Length) {

                    return;
                }

                if(outputs[i] != null) {

                    ExtraOutputLabels[i].Text = GetSymbol(outputs[i].Item2) + " ";
                    ExtraOutputLabels[i].Text += formatter.Format(outputs[i].Item1);
                }
            }
        }
    }
}