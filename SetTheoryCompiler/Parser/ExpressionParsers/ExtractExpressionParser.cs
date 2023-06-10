using System;
using System.Collections.Generic;
using System.Linq;
using SetTheoryCompiler.Parser.Nodes;
using SetTheoryCompiler.Tokenizer;

namespace SetTheoryCompiler.Parser.ExpressionParsers
{
	public class ExtractExpressionParser : ExpressionParser
	{
		public ExtractExpressionParser(ParserState state) : base(state)
		{
		}

		protected override IExpressionNode Parse()
		{
			if (_state.Lookahead.TokenId == Token.Extract)
			{
				_state.NextToken();

				if (_state.Lookahead.TokenId == Token.Variable)
				{
					String sequence = _state.Lookahead.Sequence;

					_state.NextToken();

					if (_state.Lookahead.TokenId == Token.Comma)
					{
						_state.NextToken();

						if (_state.Lookahead.TokenId == Token.Number)
						{
							List<int> expression = _state.GetVariableValue(sequence);
							expression.RemoveAt(Int32.Parse(_state.Lookahead.Sequence));

							_state.NextToken();

							return new ExtractExpressionNode(expression);
						}

						throw new Exception("ExtractExpressionParser - Syntax error. Expected 2 argument, only 1 given.");
					}

					throw new Exception("ExtractExpressionParser - Syntax error. Expected comma after variable.");
				}

				throw new Exception("ExtractExpressionParser - Syntax error. Expected 2 arguments.");
			}

			return null;
		}
	}
}
