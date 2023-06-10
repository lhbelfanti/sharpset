using System.Collections.Generic;

namespace SetTheoryCompiler.Parser.Nodes
{
    public class ShowExpressionNode : IExpressionNode
    {
        private readonly List<int> _expression;

        public ShowExpressionNode(List<int> expression)
        {
            _expression = expression;
        }

        public NodeType GetNodeType()
        {
            return NodeType.ShowNode;
        }

        public List<int> GetSet()
        {
            return _expression;
        }
    }
}
