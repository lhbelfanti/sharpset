using System.Collections.Generic;

namespace SetTheoryCompiler.Parser.Nodes
{
    class MinExpressionNode : IExpressionNode
    {
        private readonly List<int> _expression;

        public MinExpressionNode(List<int> expression)
        {
            _expression = expression;
        }

        public List<int> GetSet()
        {
            return _expression;
        }

        public NodeType GetNodeType()
        {
            return NodeType.MinNode;
        }
    }
}
