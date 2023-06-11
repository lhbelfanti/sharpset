using System.Collections.Generic;

namespace SetTheoryCompiler.Parser.Nodes
{
    public class IntersectionExpressionNode : IExpressionNode
    {
        private readonly List<int> _expression;

        public IntersectionExpressionNode(List<int> expression)
        {
            _expression = expression;
        }

        public NodeType GetNodeType()
        {
            return NodeType.IntersectionNode;
        }

        public List<int> GetSet()
        {
            return _expression;
        }
    }
}