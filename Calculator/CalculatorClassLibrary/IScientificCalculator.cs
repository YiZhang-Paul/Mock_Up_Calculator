﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClassLibrary {
    public interface IScientificCalculator : IStandardCalculator {

        int AngularUnit { get; }

        void ChangeAngularUnit();
        string CheckTrigonometricKey(string input);
    }
}