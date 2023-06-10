using System;

namespace SetTheoryCompiler.Tokenizer
{
	public class Token
	{
		public const int Maximum = 0;
		public const int Minimum = 1;
		public const int Mean = 2;
		public const int Intersection = 3;
		public const int Union = 4;
		public const int Extract = 5;
		public const int Create = 6;
		public const int Length = 7;
		public const int Add = 8;
		public const int Delete = 9;

		public const int OpenBracket = 10;
		public const int CloseBracket = 11;
		public const int Variable = 12;
		public const int Number = 13;
		public const int Comma = 14;
		public const int Assign = 15;
		public const int OpenParenthesis = 16;
		public const int CloseParenthesis = 17;
		public const int Show = 18;

		public readonly int TokenId;
		public readonly String Sequence;

		public Token(int token, String sequence)
		{
			TokenId = token;
			Sequence = sequence;
		}
	}
}
