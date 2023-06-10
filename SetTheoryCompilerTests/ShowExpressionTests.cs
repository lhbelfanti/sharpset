using System;
using SetTheoryCompiler.Parser;
using Xunit;

namespace SetTheoryCompilerTests
{
	public class ShowExpressionTests
	{
		[Fact]
		public void Test_ShowExpression_Success_ShowsValueOfVariablesAndPrintsItInConsole()
		{
			String code = "a = [6,2] ";
			code += "show a ";

			Parser p = new Parser();
			p.Parse(code);

			string got = p.GetResults();
			string want = "[6,2]\n";

			Assert.Equal(want, got);
		}

		[Fact]
		public void Test_ShowExpression_Fails_VariableNameMissing()
		{
			String code = "a = [6,2] ";
			code += "show ";

			Parser p = new Parser();
			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "ShowExpressionParser - Syntax error. Variable name missing.";
				Assert.Equal(want, got);
			}
		}
	}
}
