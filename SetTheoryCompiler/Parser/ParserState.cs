using System;
using System.Collections.Generic;
using SetTheoryCompiler.Tokenizer;

namespace SetTheoryCompiler.Parser
{
	public class ParserState
	{
		private LinkedList<Token> _tokens;
		private Token _lookahead;
		private string _results;

		private readonly Dictionary<String, List<int>> _variables = new Dictionary<string, List<int>>();

		public ParserState(List<Token> tokens)
		{
			_results = "";
			_tokens = new LinkedList<Token>();
			foreach (var item in tokens)
				_tokens.AddLast(item);

			NextToken();
		}

		public void NextToken()
		{
			if (_tokens.First != null)
			{
				_lookahead = _tokens.First.Value;
				_tokens.RemoveFirst();
			}
			else
				_lookahead = null;
		}

		public Token Lookahead => _lookahead;
		public string Results => _results;

		public void AppendToResult(string data)
		{
			_results += data;
		}

		public void SaveVariable(String variableName, List<int> variable)
		{
			_variables.Add(variableName, variable);
		}

		public List<int> GetVariableValue(String variableName)
		{
			if (_variables.ContainsKey(variableName))
				return _variables[variableName];
			return null;
		}
	}
}
