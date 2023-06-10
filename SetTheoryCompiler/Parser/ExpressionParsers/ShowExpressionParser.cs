using System;
using System.Collections.Generic;
using SetTheoryCompiler.Parser.Nodes;
using SetTheoryCompiler.Tokenizer;

namespace SetTheoryCompiler.Parser.ExpressionParsers
{
	public class ShowExpressionParser : ExpressionParser
	{
		public ShowExpressionParser(ParserState state) : base(state)
		{
		}

		protected override IExpressionNode Parse()
		{
			if (_state.Lookahead.TokenId == Token.Show)
			{
				_state.NextToken();

				if (_state.Lookahead != null && _state.Lookahead.TokenId == Token.Variable)
				{
					List<int> variables = _state.GetVariableValue(_state.Lookahead.Sequence);
					for (int i = 0; i < variables.Count; i++)
					{
						if (i == 0)
						{
							_state.AppendToResult("[");
							Console.Write("[");
						}

						bool lastElement = i == variables.Count - 1;
						string comma = lastElement ? "" : ",";
						string numComma = $"{variables[i]}" + comma;
						_state.AppendToResult(numComma);
						Console.Write(numComma);

						if (lastElement)
						{
							_state.AppendToResult("]");
							Console.Write("]");
						}
					}

					_state.AppendToResult("\n");
					Console.WriteLine();

					return new ShowExpressionNode(_state.GetVariableValue(_state.Lookahead.Sequence));
				}

				throw new Exception("ShowExpressionParser - Syntax error. Variable name missing.");
			}

			return null;
		}
	}
}
