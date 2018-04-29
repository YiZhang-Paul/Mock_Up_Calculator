using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UserControlClassLibrary {
    public interface IResize {

        int[] Keys { get; }
        Dictionary<int, Func<Rectangle>> Boxes { get; }
    }
}