using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormatterClassLibrary;

namespace UserControlClassLibrary {
    public interface IItemDisplay<T> {

        int TryGetKey(object sender);
        void ClearItems();
        void ShowItems(T[] values, IFormatter formatter);
        void RefreshItems(T[] values, IFormatter formatter);
    }
}