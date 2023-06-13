using System;

namespace SetTheoryCompiler
{
	static class Program
    {
        static void Main()
        {
	        VariablesDemo();
	        SetCreationExpressionDemo();
	        MaxFunctionDemo();
	        MinFunctionDemo();
	        AvgFunctionDemo();
	        IntFunctionDemo();
	        UniFunctionDemo();
	        ExtFunctionDemo();
	        LenFunctionDemo();
	        AddFunctionDemo();
	        DelFunctionDemo();
        }

        private static void VariablesDemo()
        {
	        Console.WriteLine("--- Variables Demo ---");
	        String code = "a = [6,2]";		// a = [6, 2]
	        code += "show a ";				// [6, 2]
	        code += "c = a ";				// c = [6, 2]
	        code += "show c ";				// [6, 2]
	        Parser.Parser p = new Parser.Parser();
	        p.Parse(code);
        }

        private static void SetCreationExpressionDemo()
        {
	        Console.WriteLine("--- Set Creation Expression Demo ---");
	        String code = "b = set(10,50,2) ";	// b = create a set from 10 to 50 with a jump of 2
	        code += "show b ";				// [10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48]
	        Parser.Parser p = new Parser.Parser();
	        p.Parse(code);
        }

        private static void MaxFunctionDemo()
        {
	        Console.WriteLine("--- Max Function Demo ---");
	        String code = "a = [6,2]";		// a = [6, 2]
	        code += "m = max a ";			// m = max([6,2]) -> m = 6
	        code += "show m ";				// [6]
	        Parser.Parser p = new Parser.Parser();
	        p.Parse(code);
        }

        private static void MinFunctionDemo()
        {
	        Console.WriteLine("--- Min Function Demo ---");
	        String code = "a = [6,2]";		// a = [6, 2]
	        code += "m = min a ";			// m = min([6,2]) -> m = 2
	        code += "show m ";				// [2]
	        Parser.Parser p = new Parser.Parser();
	        p.Parse(code);
        }

        private static void AvgFunctionDemo()
        {
	        Console.WriteLine("--- Avg Function Demo ---");
	        String code = "a = [6,2]";		// a = [6, 2]
	        code += "v = avg a ";			// v = avg([6,2]) -> v = (6+2)/2 = 4
	        code += "show v ";				// [4]
	        Parser.Parser p = new Parser.Parser();
	        p.Parse(code);
        }

        private static void IntFunctionDemo()
        {
	        Console.WriteLine("--- Int Function Demo ---");
	        String code = "a = [6,2]";		// a = [6, 2]
	        code += "b = [6,3]";			// b = [6, 3]
	        code += "i = int a,b ";			// i = int([6,2],[6,3])
	        code += "show i ";				// [6]
	        Parser.Parser p = new Parser.Parser();
	        p.Parse(code);
        }
        
        private static void UniFunctionDemo()
        {
	        Console.WriteLine("--- Uni Function Demo ---");
	        String code = "a = [6,2]";		// a = [6, 2]
	        code += "b = [6,3]";			// b = [6, 3]
	        code += "u = uni a,b ";			// i = int([6,2],[6,3])
	        code += "show u ";				// [6,2,3]
	        Parser.Parser p = new Parser.Parser();
	        p.Parse(code);
        }
        private static void ExtFunctionDemo()
        {
	        Console.WriteLine("--- Ext Function Demo ---");
	        String code = "a = [6,2]";		// a = [6, 2]
	        code += "e = ext a,0 ";			// e = ext([6, 2])
	        code += "show e ";				// [2]
	        Parser.Parser p = new Parser.Parser();
	        p.Parse(code);
        }
        
        private static void LenFunctionDemo()
        {
	        Console.WriteLine("--- Len Function Demo ---");

        }
        
        private static void AddFunctionDemo()
        {
	        Console.WriteLine("--- Add Function Demo ---");

        }
        
        private static void DelFunctionDemo()
        {
	        Console.WriteLine("--- Del Function Demo ---");

        }
    }
}
