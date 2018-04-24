using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlClassLibrary {
    public interface IScientificKeypad {

        int AngularUnit { get; }
        bool EngineeringMode { get; }
    }
}