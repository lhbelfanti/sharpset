using SetTheoryCompiler.Parser.Nodes;

namespace SetTheoryCompiler.Parser.ExpressionParsers
{
	public abstract class ExpressionParser
	{
		protected IExpressionNode _node;

		protected ParserState _state;

		protected abstract IExpressionNode Parse();

		protected ExpressionParser(ParserState state)
		{
			_state = state;
			_node = Parse();
		}

		public IExpressionNode Node => _node;
		public ParserState State => _state;
	}
}
