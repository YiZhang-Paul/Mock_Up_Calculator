using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlClassLibrary;
using CalculatorClassLibrary;
using ConverterClassLibrary;
using ExpressionsClassLibrary;
using FormatterClassLibrary;
using StorageClassLibrary;
using UtilityClassLibrary;

namespace MockUpCalculator {
    public class ServiceLookup {

        public IInputBuffer InputBuffer { get; private set; }
        public IOperatorLookup Operators { get; private set; }
        public IUnitConverter UnitConverter { get; private set; }
        public IOperatorConverter OperatorConverter { get; private set; }
        public IParenthesize Parenthesizer { get; private set; }
        public IExpressionBuilder ExpressionBuilder { get; private set; }
        public IExpressionParser ExpressionParser { get; private set; }
        public IEvaluate Evaluator { get; private set; }
        public IMemoryStorage MemoryStorage { get; private set; }

        public IKeyChecker KeyChecker { get; private set; }
        public IFormatter NumberFormatter { get; private set; }
        public IFormatter ExpressionFormatter { get; private set; }
        public IFormatter EngineeringFormatter { get; private set; }

        public void LoadCalculatorAsset() {

            InputBuffer = new InputBuffer();
            Operators = new OperatorLookup();
            UnitConverter = new AngleConverter();
            OperatorConverter = new OperatorConverter(Operators.Operators, Operators.Unary);
            Parenthesizer = new Parenthesizer(Operators.Precedence);
            ExpressionBuilder = new ExpressionBuilder(Parenthesizer);
            ExpressionParser = new ExpressionParser(OperatorConverter);
            Evaluator = new Evaluator(UnitConverter, OperatorConverter, Operators);
            MemoryStorage = new MemoryStorage();
        }

        public void LoadCalculatorPanelAsset() {

            LoadCalculatorAsset();
            KeyChecker = new KeyChecker();
            NumberFormatter = new NumberFormatter();
            ExpressionFormatter = new ExpressionFormatter(Operators.Unary);
            EngineeringFormatter = new EngineeringFormatter();
        }

        public void LoadConverterPanelAsset() {

            InputBuffer = new InputBuffer();
            KeyChecker = new KeyChecker();
            NumberFormatter = new NumberFormatter();
        }

        public StandardCalculatorPanel GetStandardCalculatorPanel() {

            LoadCalculatorPanelAsset();

            return new StandardCalculatorPanel(

                KeyChecker,
                NumberFormatter,
                ExpressionFormatter,

                new StandardCalculator(

                    InputBuffer,
                    Operators,
                    UnitConverter,
                    OperatorConverter,
                    ExpressionBuilder,
                    ExpressionParser,
                    Evaluator,
                    MemoryStorage
                )
            );
        }

        public ScientificCalculatorPanel GetScientificCalculatorPanel() {

            LoadCalculatorPanelAsset();

            return new ScientificCalculatorPanel(

                KeyChecker,
                NumberFormatter,
                ExpressionFormatter,
                EngineeringFormatter,

                new ScientificCalculator(

                    InputBuffer,
                    Operators,
                    UnitConverter,
                    OperatorConverter,
                    ExpressionBuilder,
                    ExpressionParser,
                    Evaluator,
                    MemoryStorage
                )
            );
        }

        public ConverterPanel GetConverterPanel(IUnitConverter converter, string[] units) {

            LoadConverterPanelAsset();

            return new ConverterPanel(

                InputBuffer,
                KeyChecker,
                NumberFormatter,
                converter,
                units
            );
        }

        public ConverterPanel GetTemperatureConverterPanel() {

            string[] units = { "Celsius", "Fahrenheit", "Kelvin" };

            return GetConverterPanel(new TemperatureConverter(), units);
        }

        public ConverterPanel GetTimeConverterPanel() {

            string[] units = {

                "Microseconds", "Milliseconds", "Seconds",
                "Minutes", "Hours", "Days", "Weeks", "Years"
            };

            return GetConverterPanel(new TimeConverter(), units);
        }

        public ConverterPanel GetPowerConverterPanel() {

            string[] units = {

                "Watts", "Kilowatts", "Horsepower (US)",
                "Foot-pounds/minute", "BTUs/minute"
            };

            return GetConverterPanel(new PowerConverter(), units);
        }

        public ConverterPanel GetDataConverterPanel() {

            string[] units = {

                "bits", "bytes",
                "kilobits", "kibibits", "kilobytes", "kibibytes",
                "megabits", "mebibits", "megabytes", "mebibytes",
                "gigabits", "gibibits", "gigabytes", "gibibytes",
                "terabits", "tebibits", "terabytes", "tebibytes",
                "petabits", "pebibits", "petabytes", "pebibytes",
                "exabits", "exbibits", "exabytes", "exbibytes"
            };

            return GetConverterPanel(new DataConverter(), units);
        }

        public ConverterPanel GetPressureConverterPanel() {

            string[] units = {

                "Atmospheres", "Bars", "Kilopascals",
                "Millimetres of mercury", "Pascals",
                "Pounds per square inch"
            };

            return GetConverterPanel(new PressureConverter(), units);
        }

        public ConverterPanel GetAngleConverterPanel() {

            string[] units = { "Degrees", "Radians", "Gradians" };

            return GetConverterPanel(new AngleConverter(), units);
        }
    }
}