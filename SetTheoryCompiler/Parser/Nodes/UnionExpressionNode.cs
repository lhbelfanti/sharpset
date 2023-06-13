using System.Collections.Generic;

namespace SetTheoryCompiler.Parser.Nodes
{
    public class UnionExpressionNode : IExpressionNode
    {
        private readonly List<int> _expression;

        public UnionExpressionNode(List<int> expression)
        {
            _expression = expression;
        }

        public NodeType GetNodeType()
        {
            return NodeType.UnionNode;
        }

        public List<int> GetSet()
        {
            return _expression;
        }
    }
}