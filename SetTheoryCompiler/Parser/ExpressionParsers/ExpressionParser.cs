using SetTheoryCompiler.Parser.Nodes;

namespace SetTheoryCompiler.Parser.ExpressionParsers
{
	public abstract class ExpressionParser
	{
		protected ParserState _state;
		protected ExpressionDelegate _expressionFunc;
		public delegate IExpressionNode ExpressionDelegate();

		public abstract IExpressionNode Parse();

		
		public ParserState State
		{
			get => _state;
			set => _state = value;
		}

		public ExpressionDelegate ExpressionFunc
		{
			get => _expressionFunc;
			set => _expressionFunc = value;
		}
	}
}
