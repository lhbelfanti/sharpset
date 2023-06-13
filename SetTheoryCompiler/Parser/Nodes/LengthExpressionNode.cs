using System.Collections.Generic;

namespace SetTheoryCompiler.Parser.Nodes
{
    public class LengthExpressionNode : IExpressionNode
    {
        private readonly List<int> _expression;

        public LengthExpressionNode(List<int> expression)
        {
            _expression = expression;
        }

        public List<int> GetSet()
        {
            return _expression;
        }

        public NodeType GetNodeType()
        {
            return NodeType.LengthNode;
        }
    }
}