using System;
using SetTheoryCompiler.Parser;
using Xunit;

namespace SetTheoryCompilerTests
{
    public class IntersectionExpressionTests
    {
        [Fact]
        public void Test_IntersectionExpression_Success_ObtainsIntersectionBetweenTwoSets()
        {
        	String code = "a = [6,2]";
            code += "b = [6,3]";
        	code += "i = int a,b ";
        	code += "show i ";

        	Parser p = new Parser();
        	p.Parse(code);

        	string got = p.GetResults();
        	string want = "[6]\n";

        	Assert.Equal(want, got);
        }

        [Fact]
        public void Test_IntersectionExpression_Fails_WrongParameter()
        {
	        String code = "a = [6,2]";
	        code += "b = [6,3]";
	        code += "i = int a,[ ";
	        code += "show i ";


        	Parser p = new Parser();
        	try {
        		p.Parse(code);
        		// The assert should fail because no exception was thrown
        		Assert.False(true);
        	} catch (Exception e) {
        		string got = e.Message;
        		string want = "IntersectionExpressionParser - Syntax error. Expected 2 argument, only 1 given.";
        		Assert.Equal(want, got);
        	}
        }
        
        [Fact]
        public void Test_IntersectionExpression_Fails_MissingBothParameter()
        {
	        String code = "a = [6,2]";
	        code += "b = [6,3]";
	        code += "i = int  ";
	        code += "show i ";

	        Parser p = new Parser();
	        try {
		        p.Parse(code);
		        // The assert should fail because no exception was thrown
		        Assert.False(true);
	        } catch (Exception e) {
		        string got = e.Message;
		        string want = "IntersectionExpressionParser - Syntax error. Expected 2 arguments.";
		        Assert.Equal(want, got);
	        }
        }

        [Fact]
        public void Test_IntersectionExpression_Fails_MissingCommaAfterFirstParameter()
        {
	        String code = "a = [6,2]";
	        code += "b = [6,3]";
	        code += "i = int a ";
	        code += "show i ";

        	Parser p = new Parser();
        	try {
        		p.Parse(code);
        		// The assert should fail because no exception was thrown
        		Assert.False(true);
        	} catch (Exception e) {
        		string got = e.Message;
        		string want = "IntersectionExpressionParser - Syntax error. Expected comma after variable.";
        		Assert.Equal(want, got);
        	}
        }
        
        [Fact]
        public void Test_IntersectionExpression_Fails_MissingOneParameter()
        {
	        String code = "a = [6,2]";
	        code += "b = [6,3]";
	        code += "i = int a, ";
	        code += "show i ";

	        Parser p = new Parser();
	        try {
		        p.Parse(code);
		        // The assert should fail because no exception was thrown
		        Assert.False(true);
	        } catch (Exception e) {
		        string got = e.Message;
		        string want = "IntersectionExpressionParser - Syntax error. Expected 2 argument, only 1 given.";
		        Assert.Equal(want, got);
	        }
        }
    }
}