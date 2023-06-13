using System;
using System.Collections.Generic;
using SetTheoryCompiler.Parser.Nodes;
using SetTheoryCompiler.Tokenizer;

namespace SetTheoryCompiler.Parser.ExpressionParsers
{
    public class AddExpressionParser : ExpressionParser
    {
        public override IExpressionNode Parse()
        {
            if (_state.Lookahead.TokenId == Token.Add)
            {
                _state.NextToken();

                if (_state.Lookahead.TokenId == Token.Variable)
                {
                    String variable = _state.Lookahead.Sequence;

                    _state.NextToken();

                    if (_state.Lookahead.TokenId == Token.Comma)
                    {
                        _state.NextToken();

                        if (_state.Lookahead.TokenId == Token.Number)
                        {
                            List<int> expression = _state.GetVariableValue(variable);
                            expression.Add(Int32.Parse(_state.Lookahead.Sequence));

                            _state.NextToken();

                            return new AddExpressionNode(expression);
                        }

                        throw new Exception("AddExpressionParser - Syntax error. Expected 2 argument, only 1 given.");
                    }

                    throw new Exception("AddExpressionParser - Syntax error. Expected comma after variable.");
                }

                throw new Exception("AddExpressionParser - Syntax error. Expected 2 arguments.");
            }
            
            return null;
        }
    }
}