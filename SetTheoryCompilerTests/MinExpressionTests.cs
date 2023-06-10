using System;
using SetTheoryCompiler.Parser;
using Xunit;

namespace SetTheoryCompilerTests
{
	public class MinExpressionTests
	{
		[Fact]
		public void Test_MinExpression_Success_ShowsTheMinElementOfTheSet()
		{
			String code = "a = [6,2]";
			code += "m = min a ";
			code += "show m ";

			Parser p = new Parser();
			p.Parse(code);

			string got = p.GetResults();
			string want = "[2]\n";

			Assert.Equal(want, got);
		}

		[Fact]
		public void Test_MinExpression_Fails_WrongParameters()
		{
			String code = "a = [6,2]";
			code += "m = min [ ";
			code += "show m ";

			Parser p = new Parser();
			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "MinExpressionParser - Syntax error. Variable name missing.";
				Assert.Equal(want, got);
			}
		}
	}
}
