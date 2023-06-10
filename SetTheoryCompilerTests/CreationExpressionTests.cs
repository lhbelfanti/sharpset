using System;
using SetTheoryCompiler.Parser;
using Xunit;

namespace SetTheoryCompilerTests
{
	public class CreationExpressionTests
	{
		[Fact]
		public void Test_CreationExpression_Success_AssignsSetToAVariableBasedOnTheParameters()
		{
			String code = "b = set(10,50,2) ";
			code += "show b ";

			Parser p = new Parser();
			p.Parse(code);

			string got = p.GetResults();
			string want = "[10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48]\n";

			Assert.Equal(want, got);
		}

		[Fact]
		public void Test_CreationExpression_Fails_OpenParenthesisMissing()
		{
			String code = "b = set ";

			Parser p = new Parser();

			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "CreationExpressionParser - Syntax error. Open parenthesis missing.";
				Assert.Equal(want, got);
			}
		}

		[Fact]
		public void Test_CreationExpression_Fails_FromNumberMissing()
		{
			String code = "b = set( ";

			Parser p = new Parser();

			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "CreationExpressionParser - Syntax error. From number missing.";
				Assert.Equal(want, got);
			}
		}

		[Fact]
		public void Test_CreationExpression_Fails_FirstCommaMissing()
		{
			String code = "b = set(10 ";

			Parser p = new Parser();

			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "CreationExpressionParser - Syntax error. Comma after first parameter missing.";
				Assert.Equal(want, got);
			}
		}

		[Fact]
		public void Test_CreationExpression_Fails_ToNumberMissing()
		{
			String code = "b = set(10, ";

			Parser p = new Parser();

			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "CreationExpressionParser - Syntax error. To number missing.";
				Assert.Equal(want, got);
			}
		}

		[Fact]
		public void Test_CreationExpression_Fails_SecondCommaMissing()
		{
			String code = "b = set(10,50 ";

			Parser p = new Parser();

			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "CreationExpressionParser - Syntax error. Comma after second parameter missing.";
				Assert.Equal(want, got);
			}
		}

		[Fact]
		public void Test_CreationExpression_Fails_JumpNumberMissing()
		{
			String code = "b = set(10,50, ";

			Parser p = new Parser();

			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "CreationExpressionParser - Syntax error. Jump number missing.";
				Assert.Equal(want, got);
			}
		}

		[Fact]
		public void Test_CreationExpression_Fails_CloseParenthesisMissing()
		{
			String code = "b = set(10,50,1 ";

			Parser p = new Parser();

			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "CreationExpressionParser - Syntax error. Close parenthesis missing.";
				Assert.Equal(want, got);
			}
		}
	}
}
