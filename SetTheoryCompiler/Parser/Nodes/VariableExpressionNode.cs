using System.Collections.Generic;

namespace SetTheoryCompiler.Parser.Nodes
{
    class VariableExpressionNode : IExpressionNode
    {
        private readonly List<int> _expression;

        public VariableExpressionNode(List<int> expression)
        {
            _expression = expression;
        }

        public NodeType GetNodeType()
        {
            return NodeType.VariableNode;
        }

        public List<int> GetSet()
        {
            return _expression;
        }
    }
}
