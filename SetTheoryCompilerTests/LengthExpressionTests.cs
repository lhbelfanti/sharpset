using System;
using SetTheoryCompiler.Parser;
using Xunit;

namespace SetTheoryCompilerTests
{
    public class LengthExpressionTests
    {
        [Fact]
		public void Test_LengthExpression_Success_GetLengthOfASet()
		{
			String code = "a = [6,2,1]";
			code += "l = len a ";
			code += "show l ";

			Parser p = new Parser();
			p.Parse(code);

			string got = p.GetResults();
			string want = "[3]\n";

			Assert.Equal(want, got);
		}

		[Fact]
		public void Test_LengthExpression_Fails_WrongParameter()
		{
			String code = "a = [6,2,1]";
			code += "l = len [ ";
			code += "show l ";

			Parser p = new Parser();
			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "LengthExpressionParser - Syntax error. Expected variable.";
				Assert.Equal(want, got);
			}
		}
    }
}