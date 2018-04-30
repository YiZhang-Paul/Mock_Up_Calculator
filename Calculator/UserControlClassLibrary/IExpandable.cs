using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlClassLibrary {
    public interface IExpandable {

        event EventHandler OnExtended;
        event EventHandler OnShrunken;

        void Extend(int height);
        void Shrink();
    }
}