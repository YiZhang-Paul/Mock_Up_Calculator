using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebContentClassLibrary {
    public interface IExchangeRateLoader {

        string Base { get; }
        IEnumerable<Tuple<string, decimal>> Rates { get; }

        void Load(string key, string[] symbols);
    }
}