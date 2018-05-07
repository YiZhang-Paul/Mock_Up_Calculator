using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlClassLibrary;
using CalculatorClassLibrary;
using ConverterClassLibrary;
using ExpressionsClassLibrary;
using FormatterClassLibrary;
using StorageClassLibrary;
using UtilityClassLibrary;

namespace MockUpCalculator {
    public class ServiceLookup {

        private IInputBuffer InputBuffer { get; set; }
        private IOperatorLookup Operators { get; set; }
        private IUnitConverter UnitConverter { get; set; }
        private IOperatorConverter OperatorConverter { get; set; }
        private IParenthesize Parenthesizer { get; set; }
        private IExpressionBuilder ExpressionBuilder { get; set; }
        private IExpressionParser ExpressionParser { get; set; }
        private IEvaluate Evaluator { get; set; }
        private IMemoryStorage MemoryStorage { get; set; }

        private IKeyChecker KeyChecker { get; set; }
        private IFormatter NumberFormatter { get; set; }
        private IFormatter ExpressionFormatter { get; set; }
        private IFormatter EngineeringFormatter { get; set; }

        private void LoadCalculatorAsset() {

            InputBuffer = new InputBuffer();
            Operators = new OperatorLookup();
            UnitConverter = new UnitConverter();
            OperatorConverter = new OperatorConverter(Operators.Operators, Operators.Unary);
            Parenthesizer = new Parenthesizer(Operators.Precedence);
            ExpressionBuilder = new ExpressionBuilder(Parenthesizer);
            ExpressionParser = new ExpressionParser(OperatorConverter);
            Evaluator = new Evaluator(UnitConverter, OperatorConverter, Operators);
            MemoryStorage = new MemoryStorage();
        }

        private void LoadCalculatorPanelAsset() {

            KeyChecker = new KeyChecker();
            NumberFormatter = new NumberFormatter();
            ExpressionFormatter = new ExpressionFormatter(Operators.Unary);
            EngineeringFormatter = new EngineeringFormatter();
        }

        public StandardCalculatorPanel GetStandardCalculatorPanel() {

            LoadCalculatorAsset();
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

            LoadCalculatorAsset();
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
    }
}