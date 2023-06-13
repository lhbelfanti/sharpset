using System.Collections.Generic;

namespace SetTheoryCompiler.Parser.Nodes
{
    public class AddExpressionNode : IExpressionNode
    {
        private readonly List<int> _expression;

        public AddExpressionNode(List<int> expression)
        {
            _expression = expression;
        }

        public List<int> GetSet()
        {
            return _expression;
        }

        public NodeType GetNodeType()
        {
            return NodeType.AddNode;
        }
    }
}