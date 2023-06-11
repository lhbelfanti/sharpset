using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SetTheoryCompiler.Parser.ExpressionParsers;
using SetTheoryCompiler.Parser.Nodes;
using SetTheoryCompiler.Tokenizer;

namespace SetTheoryCompiler.Parser
{
    public class Parser
    {
	    private ParserState _state;

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
            tokenizer.Add("avg", Token.Mean);
            tokenizer.Add("ext", Token.Extract);
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

	        ExpressionParser ep = new SetExpressionParser(_state);
	        _state = ep.State;
	        IExpressionNode node = ep.Node;
	        if (node != null)
		        return node;

	        ep = new VariableExpressionParser(_state, Expression);
	        _state = ep.State;
	        node = ep.Node;
	        if (node != null)
		        return node;
	        
	        ep = new CreationExpressionParser(_state);
	        _state = ep.State;
	        node = ep.Node;
	        if (node != null)
		        return node;

	        ep = new ShowExpressionParser(_state);
	        _state = ep.State;
	        node = ep.Node;
	        if (node != null)
		        return node;

	        ep = new MaxExpressionParser(_state);
	        _state = ep.State;
	        node = ep.Node;
	        if (node != null)
		        return node;

	        ep = new MinExpressionParser(_state);
	        _state = ep.State;
	        node = ep.Node;
	        if (node != null)
		        return node;

	        ep = new AvgExpressionParser(_state);
	        _state = ep.State;
	        node = ep.Node;
	        if (node != null)
		        return node;

	        ep = new ExtractExpressionParser(_state);
	        _state = ep.State;
	        node = ep.Node;
	        if (node != null)
		        return node;

	        return null;
        }
        
        // TODO: Try to fix: obtain the correct assembly when called from tests projects
        private IExpressionNode ExpressionWithReflection()
        {
	        ExpressionParser ep;
	        IExpressionNode node;
	        
	        List<string> expressionParsers = new List<string>()
	        {
		        "SetExpressionParser",
		        "VariableExpressionParser",
		        "CreationExpressionParser",
		        "ShowExpressionParser",
		        "MaxExpressionParser",
		        "MinExpressionParser",
		        "AvgExpressionParser",
		        "ExtractExpressionParser"
	        };

	        foreach (string expressionClassName in expressionParsers)
	        {
		        var assembly = Assembly.GetExecutingAssembly();
		        var type = assembly.GetTypes().First(t => t.Name == expressionClassName);

		        if (expressionClassName == "VariableExpressionParser")
		        {
			        ep = new VariableExpressionParser(_state, Expression);
			        _state = ep.State;
			        node = ep.Node;
			        if (node != null)
				        return node;
		        }
		        else
		        {
			        ep = (ExpressionParser)Activator.CreateInstance(type, _state);
			        _state = ep.State;
			        node = ep.Node;
			        if (node != null)
				        return node;
		        }
	        }

	        return null;
        }
    }
}
