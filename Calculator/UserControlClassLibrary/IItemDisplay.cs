using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlClassLibrary {
    public interface IItemDisplay<T> {

        void ResetPointer();
        void ClearItems();
        void ShowItems(T[] values);
        void RefreshItems(T[] values);
    }
}