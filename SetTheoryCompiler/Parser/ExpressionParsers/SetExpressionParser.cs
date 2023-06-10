using System;
using System.Collections.Generic;
using SetTheoryCompiler.Parser.Nodes;
using SetTheoryCompiler.Tokenizer;

namespace SetTheoryCompiler.Parser.ExpressionParsers
{
	public class SetExpressionParser : ExpressionParser
	{
		public SetExpressionParser(ParserState state) : base(state)
		{
		}

		protected override IExpressionNode Parse()
		{
			List<int> expression = new List<int>();

			if (_state.Lookahead.TokenId == Token.OpenBracket)
			{
				_state.NextToken();
				while (_state.Lookahead != null && _state.Lookahead.TokenId != Token.CloseBracket)
				{
					if (_state.Lookahead.TokenId == Token.Number)
						expression.Add(Int32.Parse(_state.Lookahead.Sequence));
					else if (_state.Lookahead.TokenId != Token.Comma)
						throw new Exception("SetExpressionParser - Syntax error. Missing comma.");

					_state.NextToken();
				}
				_state.NextToken();

				return new SetExpressionNode(expression);
			}

			return null;
		}
	}
}
