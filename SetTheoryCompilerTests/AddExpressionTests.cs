using System;
using SetTheoryCompiler.Parser;
using Xunit;

namespace SetTheoryCompilerTests
{
    public class AddExpressionTests
    {
        [Fact]
        public void Test_AddExpression_Success_AddsAnElementToASets()
        {
        	String code = "k = [6,2]";
        	code += "a = add k,9 ";
        	code += "show a ";

        	Parser p = new Parser();
        	p.Parse(code);

        	string got = p.GetResults();
        	string want = "[6,2,9]\n";

        	Assert.Equal(want, got);
        }

        [Fact]
        public void Test_AddExpression_Fails_WrongParameter()
        {
	        String code = "k = [6,2]";
	        code += "a = add k,[ ";
	        code += "show a ";


        	Parser p = new Parser();
        	try {
        		p.Parse(code);
        		// The assert should fail because no exception was thrown
        		Assert.False(true);
        	} catch (Exception e) {
        		string got = e.Message;
        		string want = "AddExpressionParser - Syntax error. Expected 2 argument, only 1 given.";
        		Assert.Equal(want, got);
        	}
        }
        
        [Fact]
        public void Test_AddExpression_Fails_MissingBothParameter()
        {
	        String code = "k = [6,2]";
	        code += "a = add ";
	        code += "show a ";

	        Parser p = new Parser();
	        try {
		        p.Parse(code);
		        // The assert should fail because no exception was thrown
		        Assert.False(true);
	        } catch (Exception e) {
		        string got = e.Message;
		        string want = "AddExpressionParser - Syntax error. Expected 2 arguments.";
		        Assert.Equal(want, got);
	        }
        }

        [Fact]
        public void Test_AddExpression_Fails_MissingCommaAfterFirstParameter()
        {
	        String code = "k = [6,2]";
	        code += "a = add k ";
	        code += "show a ";

        	Parser p = new Parser();
        	try {
        		p.Parse(code);
        		// The assert should fail because no exception was thrown
        		Assert.False(true);
        	} catch (Exception e) {
        		string got = e.Message;
        		string want = "AddExpressionParser - Syntax error. Expected comma after variable.";
        		Assert.Equal(want, got);
        	}
        }
        
        [Fact]
        public void Test_AddExpression_Fails_MissingOneParameter()
        {
	        String code = "k = [6,2]";
	        code += "a = add k, ";
	        code += "show a ";

	        Parser p = new Parser();
	        try {
		        p.Parse(code);
		        // The assert should fail because no exception was thrown
		        Assert.False(true);
	        } catch (Exception e) {
		        string got = e.Message;
		        string want = "AddExpressionParser - Syntax error. Expected 2 argument, only 1 given.";
		        Assert.Equal(want, got);
	        }
        }
    }
}