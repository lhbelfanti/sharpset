using System;
using SetTheoryCompiler.Parser;
using Xunit;

namespace SetTheoryCompilerTests
{
	public class VariableExpressionTests
	{
		[Fact]
		public void Test_VariableExpression_Success_AssignsSetToAVariable()
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
		public void Test_VariableExpression_Success_AssignsVariableToAnotherVariable()
		{
			String code = "a = [6,2]";
			code += "c = a ";
			code += "show c ";

			Parser p = new Parser();
			p.Parse(code);

			string got = p.GetResults();
			string want = "[6,2]\n";

			Assert.Equal(want, got);
		}

		[Fact]
		public void Test_VariableExpression_Fails_MissingEqualsSymbol()
		{
			String code = "a";

			Parser p = new Parser();

			try {
				p.Parse(code);
				// The assert should fail because no exception was thrown
				Assert.False(true);
			} catch (Exception e) {
				string got = e.Message;
				string want = "VariableExpressionParser - Syntax error. Missing assignment symbol (=).";
				Assert.Equal(want, got);
			}
		}
	}
}
