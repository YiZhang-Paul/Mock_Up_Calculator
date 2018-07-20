using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterClassLibrary {
    public interface ICurrencyCodeConverter {

        string ToCurrencyCode(string countryCode);
        IEnumerable<string> ToCountryCode(string currencyCode);
    }
}