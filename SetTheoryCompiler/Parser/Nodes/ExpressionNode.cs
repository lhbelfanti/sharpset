using System.Collections.Generic;

namespace SetTheoryCompiler.Parser.Nodes
{


    public interface IExpressionNode
    {
        NodeType GetNodeType();
        List<int> GetSet();
    }
}
