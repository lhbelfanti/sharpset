using System;
using SetTheoryCompiler.Parser;
using Xunit;

namespace SetTheoryCompilerTests
{
	public class ExtractExpressionTests
	{
		[Fact]
		public void Test_ExtractExpression_Success_RemovesAnElementFromTheSet()
		{
			String code = "a = [6,2]";
			code += "e = ext a,0 ";
			code += "show e ";

			Parser p = new Parser();
			p.Parse(code);

			string got = p.GetResults();
			string want = "[2]\n";

			Assert.Equal(want, got);
		}

		[Fact]
		public void Test_ExtractExpression_Fails_WrongParameter()
		{
			String code = "a = [6,2]";
			code += "e = ext a,[ ";
			code += "show e ";

			Parser p = new Parser();
			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "ExtractExpressionParser - Syntax error. Expected 2 argument, only 1 given.";
				Assert.Equal(want, got);
			}
		}
		
		[Fact]
		public void Test_ExtractExpression_Fails_MissingBothParameter()
		{
			String code = "a = [6,2]";
			code += "e = ext ";
			code += "show e ";

			Parser p = new Parser();
			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "ExtractExpressionParser - Syntax error. Expected 2 arguments.";
				Assert.Equal(want, got);
			}
		}
		
		[Fact]
		public void Test_ExtractExpression_Fails_MissingCommaAfterFirstParameter()
		{
			String code = "a = [6,2]";
			code += "e = ext a ";
			code += "show e ";

			Parser p = new Parser();
			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "ExtractExpressionParser - Syntax error. Expected comma after variable.";
				Assert.Equal(want, got);
			}
		}
		
		[Fact]
		public void Test_ExtractExpression_Fails_MissingOneParameter()
		{
			String code = "a = [6,2]";
			code += "e = ext a, ";
			code += "show e ";

			Parser p = new Parser();
			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "ExtractExpressionParser - Syntax error. Expected 2 argument, only 1 given.";
				Assert.Equal(want, got);
			}
		}
	}
}
