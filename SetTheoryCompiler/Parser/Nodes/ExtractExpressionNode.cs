using System.Collections.Generic;

namespace SetTheoryCompiler.Parser.Nodes
{
    public class ExtractExpressionNode : IExpressionNode
    {
        private readonly List<int> _expression;

        public ExtractExpressionNode(List<int> expression)
        {
            _expression = expression;
        }

        public NodeType GetNodeType()
        {
            return NodeType.ExtractNode;
        }

        public List<int> GetSet()
        {
            return _expression;
        }
    }
}
