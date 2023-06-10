using System.Text.RegularExpressions;

namespace SetTheoryCompiler.Tokenizer
{
	class TokenInfo
	{
		public readonly Regex Regex;
		public readonly int Token;

		public TokenInfo(Regex regex, int token)
		{
			Regex = regex;
			Token = token;
		}
	}
}
