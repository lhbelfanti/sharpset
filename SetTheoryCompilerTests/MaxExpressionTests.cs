using System;
using SetTheoryCompiler.Parser;
using Xunit;

namespace SetTheoryCompilerTests
{
	public class MaxExpressionTests
	{
		[Fact]
		public void Test_MaxExpression_Success_ShowsTheMaxElementOfTheSet()
		{
			String code = "a = [6,2]";
			code += "m = max a ";
			code += "show m ";

			Parser p = new Parser();
			p.Parse(code);

			string got = p.GetResults();
			string want = "[6]\n";

			Assert.Equal(want, got);
		}

		[Fact]
		public void Test_MaxExpression_Fails_WrongParameters()
		{
			String code = "a = [6,2]";
			code += "m = max [ ";
			code += "show m ";

			Parser p = new Parser();
			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "MaxExpressionParser - Syntax error. Variable name missing.";
				Assert.Equal(want, got);
			}
		}
	}
}
