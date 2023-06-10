using System;
using System.Collections.Generic;
using System.Linq;
using SetTheoryCompiler.Parser.Nodes;
using SetTheoryCompiler.Tokenizer;

namespace SetTheoryCompiler.Parser.ExpressionParsers
{
	public class MaxExpressionParser : ExpressionParser
	{
		public MaxExpressionParser(ParserState state) : base(state)
		{
		}

		protected override IExpressionNode Parse()
		{
			if (_state.Lookahead.TokenId == Token.Maximum)
			{
				_state.NextToken();

				if (_state.Lookahead.TokenId == Token.Variable)
				{
					int max = _state.GetVariableValue(_state.Lookahead.Sequence).Max();
					List<int> expression = new List<int> { max };

					return new MaxExpressionNode(expression);
				}

				throw new Exception("MaxExpressionParser - Syntax error. Variable name missing.");
			}

			return null;
		}
	}
}
