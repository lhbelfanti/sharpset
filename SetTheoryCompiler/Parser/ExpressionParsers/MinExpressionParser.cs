using System;
using System.Collections.Generic;
using System.Linq;
using SetTheoryCompiler.Parser.Nodes;
using SetTheoryCompiler.Tokenizer;

namespace SetTheoryCompiler.Parser.ExpressionParsers
{
	public class MinExpressionParser : ExpressionParser
	{
		public override IExpressionNode Parse()
		{;
			if (_state.Lookahead.TokenId == Token.Minimum)
			{
				_state.NextToken();

				if (_state.Lookahead.TokenId == Token.Variable)
				{
					int min = _state.GetVariableValue(_state.Lookahead.Sequence).Min();
					List<int> expression = new List<int>();
					expression.Add(min);

					return new MinExpressionNode(expression);
				}

				throw new Exception("MinExpressionParser - Syntax error. Variable name missing.");
			}

			return null;
		}
	}
}
