using System.Collections.Generic;

namespace SetTheoryCompiler.Parser.Nodes
{
    class AvgExpressionNode : IExpressionNode
    {
        private readonly List<int> _expression;

        public AvgExpressionNode(List<int> expression)
        {
            _expression = expression;
        }

        public List<int> GetSet()
        {
            return _expression;
        }

        public NodeType GetNodeType()
        {
            return NodeType.AvgNode;
        }
    }
}
