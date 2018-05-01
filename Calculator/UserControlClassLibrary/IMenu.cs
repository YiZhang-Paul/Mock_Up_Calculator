using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlClassLibrary {
    public interface IMenu {

        void ShowMenu(List<string[]> items, string current);
    }
}