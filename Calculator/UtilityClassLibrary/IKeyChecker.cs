using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityClassLibrary {
    public interface IKeyChecker {

        bool IsInputKey(string input);
        bool IsActionKey(string input);
        bool IsFunctionKey(string input);
        bool IsMemoryKey(string input);
    }
}