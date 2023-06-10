using System.Collections.Generic;

namespace SetTheoryCompiler.Parser.Nodes
{
    class NumberExpressionNode : IExpressionNode
    {
        public NodeType GetNodeType()
        {
            return NodeType.NumberNode;
        }

        public List<int> GetSet()
        {
            return null;
        }
    }
}
