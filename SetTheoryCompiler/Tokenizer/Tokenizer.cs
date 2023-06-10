using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SetTheoryCompiler.Tokenizer
{
	public class Tokenizer
	{
		private readonly List<TokenInfo> _tokenInfo;
		private readonly List<Token> _tokens;

		public Tokenizer()
		{
			_tokenInfo = new List<TokenInfo>();
			_tokens = new List<Token>();
		}

		public void Add(String regex, int token)
		{
			_tokenInfo.Add(new TokenInfo(new Regex("^(" + regex + ")"), token));
		}

		public void Tokenize(String str)
		{
			String text = str.Trim();
			_tokens.Clear();
			while (!text.Equals(""))
			{
				bool match = false;
				foreach (TokenInfo info in _tokenInfo)
				{
					var m = info.Regex.Match(text);
					if (m.Success)
					{
						match = true;
						String tok = m.Value.Trim();
						text = text.Remove(m.Index, m.Length).Trim();
						_tokens.Add(new Token(info.Token, tok));
						break;
					}
				}

				if (!match)
					throw new Exception("Unexpected character in input: " + text);
			}
		}

		public List<Token> GetTokens()
		{
			return _tokens;
		}
	}
}
