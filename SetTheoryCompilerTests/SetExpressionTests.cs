using System;
using SetTheoryCompiler.Parser;
using Xunit;

namespace SetTheoryCompilerTests
{
	public class SetExpressionTests
	{
		[Fact]
		public void Test_SetExpression_Success_AssignsShortSetToAVariable()
		{
			String code = "a = [6,2]";
			code += "show a ";

			Parser p = new Parser();
			p.Parse(code);

			string got = p.GetResults();
			string want = "[6,2]\n";

			Assert.Equal(want, got);
		}

		[Fact]
		public void Test_SetExpression_Success_AssignsLongSetToAVariable()
		{
			String code = "a = [1,2,3,4,5,6,7,8,9]";
			code += "show a ";

			Parser p = new Parser();
			p.Parse(code);

			string got = p.GetResults();
			string want = "[1,2,3,4,5,6,7,8,9]\n";

			Assert.Equal(want, got);
		}

		[Fact]
		public void Test_SetExpression_Fails_MissingComma()
		{
			String code = "a = [1";
			code += "show a ";

			Parser p = new Parser();
			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "SetExpressionParser - Syntax error. Missing comma.";
				Assert.Equal(want, got);
			}
		}
	}
}
