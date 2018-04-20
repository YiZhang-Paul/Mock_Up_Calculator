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
        string Operator { get; }
        decimal Operand { get; }

        void AddLeft(INode child);
        void AddRight(INode child);
        bool IsLeaf();
    }
}