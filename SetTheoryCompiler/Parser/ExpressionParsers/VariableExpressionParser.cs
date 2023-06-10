using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SetTheoryCompiler.Parser.Nodes;
using SetTheoryCompiler.Tokenizer;

namespace SetTheoryCompiler.Parser.ExpressionParsers
{
	public class VariableExpressionParser : ExpressionParser
	{
		public delegate IExpressionNode ExpressionDelegate();

		private readonly ExpressionDelegate _expression;

		public VariableExpressionParser(ParserState state, ExpressionDelegate expression) : base(state)
		{
			_expression = expression;
			_node = ParseVariable();
		}

		protected override IExpressionNode Parse()
		{
			// We need to set the Expression function first
			return null;
		}

		private IExpressionNode ParseVariable()
		{
			if (_state.Lookahead.TokenId == Token.Variable)
			{
				String variableName = _state.Lookahead.Sequence;

				_state.NextToken();
				List<int> variable;
				if (_state.Lookahead != null && _state.Lookahead.TokenId == Token.Assign)
				{
					_state.NextToken();
					IExpressionNode exp = _expression();
					variable = exp.GetSet();
					_state.SaveVariable(variableName, variable);
				}
				else
				{
					variable = _state.GetVariableValue(variableName);
					if (variable == null)
						throw new Exception("VariableExpressionParser - Syntax error. Missing assignment symbol (=).");
				}

				return new VariableExpressionNode(variable);
			}

			return null;
		}
	}
}
