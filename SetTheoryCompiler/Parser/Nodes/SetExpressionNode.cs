using System.Collections.Generic;

namespace SetTheoryCompiler.Parser.Nodes
{
    class SetExpressionNode : IExpressionNode
    {
        private readonly List<int> _expression;

        public SetExpressionNode(List<int> expression)
        {
            _expression = expression;
        }

        public NodeType GetNodeType()
        {
            return NodeType.SetNode;
        }

        public List<int> GetSet()
        {
            return _expression;
        }
    }
}
