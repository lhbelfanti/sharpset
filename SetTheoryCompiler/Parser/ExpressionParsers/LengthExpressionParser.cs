using System;
using System.Collections.Generic;
using SetTheoryCompiler.Parser.Nodes;
using SetTheoryCompiler.Tokenizer;

namespace SetTheoryCompiler.Parser.ExpressionParsers
{
    public class LengthExpressionParser : ExpressionParser
    {
        public override IExpressionNode Parse()
        {
            if (_state.Lookahead.TokenId == Token.Length)
            {
                _state.NextToken();

                if (_state.Lookahead.TokenId == Token.Variable)
                {
                    List<int> value = _state.GetVariableValue(_state.Lookahead.Sequence);
                    
                    return new LengthExpressionNode(new List<int>(){value.Count});
                }

                throw new Exception("LengthExpressionParser - Syntax error. Expected variable.");
            }

            return null;
        }
    }
}