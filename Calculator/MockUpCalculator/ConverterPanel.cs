using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConverterClassLibrary;
using FormatterClassLibrary;
using UserControlClassLibrary;
using UtilityClassLibrary;

namespace MockUpCalculator {
    public partial class ConverterPanel : UserControl {

        public ConverterPanel() {

            InitializeComponent();
        }

        public ConverterPanel(

            IKeyChecker checker,
            IFormatter numberFormatter

        ) {

            InitializeComponent();
        }
    }
}