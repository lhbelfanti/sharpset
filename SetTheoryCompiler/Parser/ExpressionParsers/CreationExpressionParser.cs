using System;
using System.Collections.Generic;
using SetTheoryCompiler.Parser.Nodes;
using SetTheoryCompiler.Tokenizer;

namespace SetTheoryCompiler.Parser.ExpressionParsers
{
	public class CreationExpressionParser : ExpressionParser
	{
		public CreationExpressionParser(ParserState state) : base(state)
		{
		}

		protected override IExpressionNode Parse()
		{
			List<int> expression = new List<int>();

			if (_state.Lookahead.TokenId == Token.Create)
			{
				_state.NextToken();
				if (_state.Lookahead == null || _state.Lookahead.TokenId != Token.OpenParenthesis)
					throw new Exception("CreationExpressionParser - Syntax error. Open parenthesis missing.");

				_state.NextToken();
				if (_state.Lookahead == null || _state.Lookahead.TokenId != Token.Number)
					throw new Exception("CreationExpressionParser - Syntax error. From number missing.");
				int from = Int32.Parse(_state.Lookahead.Sequence);

				_state.NextToken();
				if (_state.Lookahead == null || _state.Lookahead.TokenId != Token.Comma)
					throw new Exception("CreationExpressionParser - Syntax error. Comma after first parameter missing.");

				_state.NextToken();
				if (_state.Lookahead == null || _state.Lookahead.TokenId != Token.Number)
					throw new Exception("CreationExpressionParser - Syntax error. To number missing.");
				int to = Int32.Parse(_state.Lookahead.Sequence);

				_state.NextToken();
				if (_state.Lookahead == null || _state.Lookahead.TokenId != Token.Comma)
					throw new Exception("CreationExpressionParser - Syntax error. Comma after second parameter missing.");

				_state.NextToken();
				if (_state.Lookahead == null || _state.Lookahead.TokenId != Token.Number)
					throw new Exception("CreationExpressionParser - Syntax error. Jump number missing.");
				int jump = Int32.Parse(_state.Lookahead.Sequence);

				_state.NextToken();
				if (_state.Lookahead == null || _state.Lookahead.TokenId != Token.CloseParenthesis)
					throw new Exception("CreationExpressionParser - Syntax error. Close parenthesis missing.");

				_state.NextToken();

				for (int i = from; i < to; i += jump)
					expression.Add(i);

				return new CreationExpressionNode(expression);
			}
			return null;
		}
	}
}
