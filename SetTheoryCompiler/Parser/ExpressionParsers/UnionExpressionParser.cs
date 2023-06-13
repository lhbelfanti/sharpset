using System;
using System.Collections.Generic;
using System.Linq;
using SetTheoryCompiler.Parser.Nodes;
using SetTheoryCompiler.Tokenizer;

namespace SetTheoryCompiler.Parser.ExpressionParsers
{
    public class UnionExpressionParser : ExpressionParser
    {
        public override IExpressionNode Parse()
        {
            if (_state.Lookahead.TokenId == Token.Union)
            {
                _state.NextToken();

                if (_state.Lookahead.TokenId == Token.Variable)
                {
                    String firstVariable = _state.Lookahead.Sequence;

                    _state.NextToken();

                    if (_state.Lookahead.TokenId == Token.Comma)
                    {
                        _state.NextToken();

                        if (_state.Lookahead.TokenId == Token.Variable)
                        {
                            String secondVariable = _state.Lookahead.Sequence;
                            
                            List<int> set1 = _state.GetVariableValue(firstVariable);
                            List<int> set2 = _state.GetVariableValue(secondVariable);
                            List<int> union = set1.Union(set2).ToList();
                            
                            return new UnionExpressionNode(union);
                        }
                        
                        throw new Exception("UnionExpressionParser - Syntax error. Expected 2 argument, only 1 given.");
                    }

                    throw new Exception("UnionExpressionParser - Syntax error. Expected comma after variable.");
                }

                throw new Exception("UnionExpressionParser - Syntax error. Expected 2 arguments.");
            }

            return null;
        }
    }
}