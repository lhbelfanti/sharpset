using System;
using System.Collections.Generic;
using SetTheoryCompiler.Parser.ExpressionParsers;
using SetTheoryCompiler.Parser.Nodes;
using SetTheoryCompiler.Tokenizer;

namespace SetTheoryCompiler.Parser
{
    public class Parser
    {
	    private ParserState _state;
	    private readonly List<string> _expressionParsers;

	    public Parser()
	    {
		    _expressionParsers = new List<string>()
		    {
			    "SetExpressionParser",
			    "VariableExpressionParser",
			    "CreationExpressionParser",
			    "ShowExpressionParser",
			    "MaxExpressionParser",
			    "MinExpressionParser",
			    "AvgExpressionParser",
			    "IntersectionExpressionParser",
			    "UnionExpressionParser",
			    "ExtractExpressionParser",
			    "LengthExpressionParser",
			    "AddExpressionParser",
			    "DeleteExpressionParser"
		    };
	    }
	    
        private Tokenizer.Tokenizer BuildTokenizer()
        {
            Tokenizer.Tokenizer tokenizer = new Tokenizer.Tokenizer();

            tokenizer.Add("\\[", Token.OpenBracket);
            tokenizer.Add("\\]", Token.CloseBracket);
            tokenizer.Add("\\(", Token.OpenParenthesis);
            tokenizer.Add("\\)", Token.CloseParenthesis);
            tokenizer.Add(",", Token.Comma);
            tokenizer.Add("=", Token.Assign);
            tokenizer.Add("set", Token.Create);
            tokenizer.Add("show", Token.Show);
            tokenizer.Add("max", Token.Maximum);
            tokenizer.Add("min", Token.Minimum);
            tokenizer.Add("avg", Token.Avg);
            tokenizer.Add("int", Token.Intersection);
            tokenizer.Add("uni", Token.Union);
            tokenizer.Add("ext", Token.Extract);
            tokenizer.Add("len", Token.Length);
            tokenizer.Add("add", Token.Add);
            tokenizer.Add("del", Token.Delete);
            tokenizer.Add("[0-9]+", Token.Number);
            tokenizer.Add("[a-z]+", Token.Variable);

            return tokenizer;
        }

        public string GetResults()
        {
	        return _state.Results;
        }

        public void Parse(String code)
        {
            Tokenizer.Tokenizer tokenizer = BuildTokenizer();
            tokenizer.Tokenize(code);
            var tokens = tokenizer.GetTokens();
            Parse(tokens);
        }

        private void Parse(List<Token> tokens)
        {
	        _state = new ParserState(tokens);

	        while (_state.Lookahead != null)
            {
                Expression();
            }
        }

        private IExpressionNode Expression()
        {
	        ExpressionParser ep;
	        IExpressionNode node;
	        
	        foreach (string expressionParserClassName in _expressionParsers)
	        {
		        ep = InstantiateParser(expressionParserClassName);
		        
		        ep.State = _state;
		        if (expressionParserClassName == "VariableExpressionParser")
			        ep.ExpressionFunc = Expression;

			    node = ep.Parse();
			    _state = ep.State;
			    if (node != null)
			        return node;
	        }

	        return null;
        }

        private ExpressionParser InstantiateParser(string expressionParserClassName)
        {
	        string objectToInstantiate = "SetTheoryCompiler.Parser.ExpressionParsers." + expressionParserClassName + ", SetTheoryCompiler";
	        var objectType = Type.GetType(objectToInstantiate);
	        if (objectType == null)
		        throw new Exception("Failed to GetType " + objectToInstantiate);
		        
	        ExpressionParser ep = Activator.CreateInstance(objectType) as ExpressionParser;
	        if (ep == null)
		        throw new Exception("Failed to instantiate " + objectToInstantiate);

	        return ep;
        }
    }
}
