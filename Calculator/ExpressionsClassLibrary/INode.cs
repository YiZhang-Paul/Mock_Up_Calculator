using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionsClassLibrary {
    public interface INode {

        INode Parent { get; set; }
        INode Left { get; }
        INode Right { get; }
        bool IsOperand { get; set; }
        decimal Value { get; set; }

        void AddLeft(INode child);
        void AddRight(INode child);
    }
}