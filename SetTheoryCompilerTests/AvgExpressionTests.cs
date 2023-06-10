using System;
using SetTheoryCompiler.Parser;
using Xunit;

namespace SetTheoryCompilerTests
{
	public class AvgExpressionTests
	{
		[Fact]
		public void Test_AvgExpression_Success_ShowsAvgNumberOfTheSet()
		{
			String code = "a = [6,2]";
			code += "v = avg a ";
			code += "show v ";

			Parser p = new Parser();
			p.Parse(code);

			string got = p.GetResults();
			string want = "[4]\n";

			Assert.Equal(want, got);
		}

		[Fact]
		public void Test_AvgExpression_Fails_WrongParameters()
		{
			String code = "a = [6,2]";
			code += "v = avg [ ";
			code += "show v ";

			Parser p = new Parser();
			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "AvgExpressionParser - Syntax error. Variable name missing.";
				Assert.Equal(want, got);
			}
		}
	}
}
