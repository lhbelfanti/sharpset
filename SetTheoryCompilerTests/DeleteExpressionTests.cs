using System;
using SetTheoryCompiler.Parser;
using Xunit;

namespace SetTheoryCompilerTests
{
    public class DeleteExpressionTests
    {
        [Fact]
        public void Test_DeleteExpression_Success_DeletesAnElementFromASets()
        {
        	String code = "a = [6,2]";
        	code += "d = del a,2 ";
        	code += "show d ";

        	Parser p = new Parser();
        	p.Parse(code);

        	string got = p.GetResults();
        	string want = "[6]\n";

        	Assert.Equal(want, got);
        }
        
        [Fact]
        public void Test_DeleteExpression_Success_DeletesAnElementThatIsNotInTheSets()
        {
	        String code = "a = [6,2]";
	        code += "d = del a,9 ";
	        code += "show d ";

	        Parser p = new Parser();
	        p.Parse(code);

	        string got = p.GetResults();
	        string want = "[6,2]\n";

	        Assert.Equal(want, got);
        }

        [Fact]
        public void Test_DeleteExpression_Fails_WrongParameter()
        {
	        String code = "a = [6,2]";
	        code += "d = del a,[ ";
	        code += "show d ";


        	Parser p = new Parser();
        	try {
        		p.Parse(code);
        		// The assert should fail because no exception was thrown
        		Assert.False(true);
        	} catch (Exception e) {
        		string got = e.Message;
        		string want = "DeleteExpressionParser - Syntax error. Expected 2 argument, only 1 given.";
        		Assert.Equal(want, got);
        	}
        }
        
        [Fact]
        public void Test_DeleteExpression_Fails_MissingBothParameter()
        {
	        String code = "a = [6,2]";
	        code += "d = del ";
	        code += "show d ";

	        Parser p = new Parser();
	        try {
		        p.Parse(code);
		        // The assert should fail because no exception was thrown
		        Assert.False(true);
	        } catch (Exception e) {
		        string got = e.Message;
		        string want = "DeleteExpressionParser - Syntax error. Expected 2 arguments.";
		        Assert.Equal(want, got);
	        }
        }

        [Fact]
        public void Test_DeleteExpression_Fails_MissingCommaAfterFirstParameter()
        {
	        String code = "a = [6,2]";
	        code += "d = del a ";
	        code += "show d ";

        	Parser p = new Parser();
        	try {
        		p.Parse(code);
        		// The assert should fail because no exception was thrown
        		Assert.False(true);
        	} catch (Exception e) {
        		string got = e.Message;
        		string want = "DeleteExpressionParser - Syntax error. Expected comma after variable.";
        		Assert.Equal(want, got);
        	}
        }
        
        [Fact]
        public void Test_DeleteExpression_Fails_MissingOneParameter()
        {
	        String code = "a = [6,2]";
	        code += "d = del a, ";
	        code += "show d ";

	        Parser p = new Parser();
	        try {
		        p.Parse(code);
		        // The assert should fail because no exception was thrown
		        Assert.False(true);
	        } catch (Exception e) {
		        string got = e.Message;
		        string want = "DeleteExpressionParser - Syntax error. Expected 2 argument, only 1 given.";
		        Assert.Equal(want, got);
	        }
        }
    }
}