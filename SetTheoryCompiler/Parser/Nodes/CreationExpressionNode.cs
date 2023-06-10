using System.Collections.Generic;

namespace SetTheoryCompiler.Parser.Nodes
{
    public class CreationExpressionNode : IExpressionNode
    {
        private readonly List<int> _expression;

        public CreationExpressionNode(List<int> expression)
        {
            _expression = expression;
        }

        public NodeType GetNodeType()
        {
            return NodeType.CreationNode;
        }

        public List<int> GetSet()
        {
            return _expression;
        }
    }
}
