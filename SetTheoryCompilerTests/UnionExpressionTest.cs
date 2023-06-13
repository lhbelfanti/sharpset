using System;
using SetTheoryCompiler.Parser;
using Xunit;

namespace SetTheoryCompilerTests
{
    public class UnionExpressionTest
    {
        [Fact]
        public void Test_UnionExpression_Success_ObtainsIntersectionBetweenTwoSets()
        {
        	String code = "a = [6,2]";
            code += "b = [6,3]";
        	code += "u = uni a,b ";
        	code += "show u ";

        	Parser p = new Parser();
        	p.Parse(code);

        	string got = p.GetResults();
        	string want = "[6,2,3]\n";

        	Assert.Equal(want, got);
        }

        [Fact]
        public void Test_UnionExpression_Fails_WrongParameter()
        {
	        String code = "a = [6,2]";
	        code += "b = [6,3]";
	        code += "u = uni a,[ ";
	        code += "show u ";


        	Parser p = new Parser();
        	try {
        		p.Parse(code);
        		// The assert should fail because no exception was thrown
        		Assert.False(true);
        	} catch (Exception e) {
        		string got = e.Message;
        		string want = "UnionExpressionParser - Syntax error. Expected 2 argument, only 1 given.";
        		Assert.Equal(want, got);
        	}
        }
        
        [Fact]
        public void Test_UnionExpression_Fails_MissingBothParameter()
        {
	        String code = "a = [6,2]";
	        code += "b = [6,3]";
	        code += "u = uni  ";
	        code += "show u ";

	        Parser p = new Parser();
	        try {
		        p.Parse(code);
		        // The assert should fail because no exception was thrown
		        Assert.False(true);
	        } catch (Exception e) {
		        string got = e.Message;
		        string want = "UnionExpressionParser - Syntax error. Expected 2 arguments.";
		        Assert.Equal(want, got);
	        }
        }

        [Fact]
        public void Test_UnionExpression_Fails_MissingCommaAfterFirstParameter()
        {
	        String code = "a = [6,2]";
	        code += "b = [6,3]";
	        code += "u = uni a ";
	        code += "show u ";

        	Parser p = new Parser();
        	try {
        		p.Parse(code);
        		// The assert should fail because no exception was thrown
        		Assert.False(true);
        	} catch (Exception e) {
        		string got = e.Message;
        		string want = "UnionExpressionParser - Syntax error. Expected comma after variable.";
        		Assert.Equal(want, got);
        	}
        }
        
        [Fact]
        public void Test_UnionExpression_Fails_MissingOneParameter()
        {
	        String code = "a = [6,2]";
	        code += "b = [6,3]";
	        code += "u = uni a, ";
	        code += "show u ";

	        Parser p = new Parser();
	        try {
		        p.Parse(code);
		        // The assert should fail because no exception was thrown
		        Assert.False(true);
	        } catch (Exception e) {
		        string got = e.Message;
		        string want = "UnionExpressionParser - Syntax error. Expected 2 argument, only 1 given.";
		        Assert.Equal(want, got);
	        }
        }
    }
}