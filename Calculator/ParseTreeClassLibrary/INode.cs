using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTreeClassLibrary {
    public interface INode {

        INode Parent { get; }
        INode Left { get; }
        INode Right { get; }
        bool IsOperand { get; }
        bool IsLeaf { get; }
        decimal Value { get; set; }

        void AddLeft(INode child);
        void AddRight(INode child);
    }
}