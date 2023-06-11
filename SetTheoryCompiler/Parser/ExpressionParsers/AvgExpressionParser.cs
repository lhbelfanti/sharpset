using System;
using System.Collections.Generic;
using System.Linq;
using SetTheoryCompiler.Parser.Nodes;
using SetTheoryCompiler.Tokenizer;

namespace SetTheoryCompiler.Parser.ExpressionParsers
{
	public class AvgExpressionParser : ExpressionParser
	{
		public override IExpressionNode Parse()
		{
			if (_state.Lookahead.TokenId == Token.Mean)
			{
				_state.NextToken();

				if (_state.Lookahead.TokenId == Token.Variable)
				{
					int sum = _state.GetVariableValue(_state.Lookahead.Sequence).Sum();

					List<int> expression = new List<int>();
					expression.Add(sum / _state.GetVariableValue(_state.Lookahead.Sequence).Count);

					return new AvgExpressionNode(expression);
				}

				throw new Exception("AvgExpressionParser - Syntax error. Variable name missing.");
			}

			return null;
		}
	}
}
