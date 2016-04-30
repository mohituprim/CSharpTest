using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    //A string is an object of type String whose value is text. 
    //Internally, the text is stored as a sequential read-only collection of Char objects. 
    //There is no null-terminating character at the end of a C# string; therefore a C# string can contain any number of embedded null characters ('\0').
    //The Length property of a string represents the number of Char objects it contains, not the number of Unicode characters.
    //To access the individual Unicode code points in a string, use the StringInfo object.

    //string vs. System.String
    //In C#, the string keyword is an alias for String. Therefore, String and string are equivalent, and you can use whichever naming convention you prefer. 
    //The String class provides many methods for safely creating, manipulating, and comparing strings. 
    //In addition, the C# language overloads some operators to simplify common string operations.
    class StringTest
    {
        public void callStringTest()
        {
            // Declare without initializing.
            string message1;

            // Initialize to null.
            string message2 = null;

            // Initialize as an empty string.
            // Use the Empty constant instead of the literal "".
            string message3 = System.String.Empty;

            //Initialize with a regular string literal.
            string oldPath = "c:\\Program Files\\Microsoft Visual Studio 8.0";

            // Initialize with a verbatim string literal.
            string newPath = @"c:\Program Files\Microsoft Visual Studio 9.0";

            // Use System.String if you prefer.
            System.String greeting = "Hello World!";

            // In local variables (i.e. within a method body)
            // you can use implicit typing.
            var temp = "I'm still a strongly-typed System.String!";

            // Use a const string to prevent 'message4' from
            // being used to store another string value.
            const string message4 = "You can't get rid of me!";

            // Use the String constructor only when creating
            // a string from a char*, char[], or sbyte*. See
            // System.String documentation for details.
            char[] letters = { 'A', 'B', 'C' };
            //Note that you do not use the new operator to create a string object except when initializing the string with an array of chars.
            string alphabet = new string(letters);


            //Immutability of String Objects
                //String objects are immutable: they cannot be changed after they have been created.
                //All of the String methods and C# operators that appear to modify a string actually return the results in a new string object. 

            //Format Strings
                //A format string is a string whose contents can be determined dynamically at runtime.
                //You create a format string by using the static Format method and embedding placeholders in braces that will be replaced by other values at runtime. 
            // Write a different string each iteration.
            string s;
            int j = 5;
            for (int i = 0; i < 10; i++)
            {
                // A simple format string with no alignment formatting.
                s = System.String.Format("{0} times {1} = {2}", i, j, (i * j));
                System.Console.WriteLine(s);
            }
        }

        //Because strings are immutable, it is not possible (without using unsafe code) to modify the value of a string object after it has been created.\
        //However, there are many ways to modify the value of a string and store the result in a new string object.
        //The System.String class provides methods that operate on an input string and return a new string object.
        //In many cases, you can assign the new object to the variable that held the original string.
        //The System.Text.RegularExpressions.Regex class provides additional methods that work in a similar manner.
        //The System.Text.StringBuilder class provides a character buffer that you can modify "in-place."
        //You call the StringBuilder.ToString method to create a new string object that contains the current contents of the buffer.

        //The following example is provided for those very rare situations in which you may want to modify a string in-place by using unsafe code in a manner similar to C-style char arrays.
        //The example shows how to access the individual characters "in-place" by using the fixed keyword.
        //It also demonstrates one possible side effect of unsafe operations on strings that results from the way that the C# compiler stores (interns) strings internally.
        //In general, you should not use this technique unless it is absolutely necessary.

        //main should be unsafe if you want to compile this
            //unsafe static void unSafeModifyString()
            //{
            //    // Compiler will store (intern) 
            //    // these strings in same location.
            //    string s1 = "Hello";
            //    string s2 = "Hello";

            //    // Change one string using unsafe code.
            //    fixed (char* p = s1)
            //    {
            //        p[0] = 'C';
            //    }

            //    //  Both strings have changed.
            //    Console.WriteLine(s1);
            //    Console.WriteLine(s2);

            //    // Keep console window open in debug mode.
            //    Console.WriteLine("Press any key to exit.");
            //    Console.ReadKey();
            //}

        void stringComparisonExample()
        {
            // Internal strings that will never be localized.
            string root = @"C:\users";
            string root2 = @"C:\Users";

            // Use the overload of the Equals method that specifies a StringComparison.
            // Ordinal is the fastest way to compare two strings.
            bool result = root.Equals(root2, StringComparison.Ordinal);

            Console.WriteLine("Ordinal comparison: {0} and {1} are {2}", root, root2,
                                result ? "equal." : "not equal.");

            // To ignore case means "user" equals "User". This is the same as using
            // String.ToUpperInvariant on each string and then performing an ordinal comparison.
            result = root.Equals(root2, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine("Ordinal ignore case: {0} and {1} are {2}", root, root2,
                                 result ? "equal." : "not equal.");

            // A static method is also available.
            bool areEqual = String.Equals(root, root2, StringComparison.Ordinal);


            // String interning. Are these really two distinct objects?
            string a = "The computer ate my source code.";
            string b = "The computer ate my source code.";

            // ReferenceEquals returns true if both objects
            // point to the same location in memory.
            if (String.ReferenceEquals(a, b))
                Console.WriteLine("a and b are interned.");
            else
                Console.WriteLine("a and b are not interned.");

            // Use String.Copy method to avoid interning.
            string c = String.Copy(a);

            if (String.ReferenceEquals(a, c))
                Console.WriteLine("a and c are interned.");
            else
                Console.WriteLine("a and c are not interned.");

            // Output:
            // Ordinal comparison: C:\users and C:\Users are not equal.
            // Ordinal ignore case: C:\users and C:\Users are equal.
            // a and b are interned.
            // a and c are not interned.
        }

        void stringSplitExample()
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string text = "one\ttwo three:four,five six seven";
            System.Console.WriteLine("Original text: '{0}'", text);

            string[] words = text.Split(delimiterChars);
            System.Console.WriteLine("{0} words in text:", words.Length);

            foreach (string s in words)
            {
                System.Console.WriteLine(s);
            }

            //By default, String.Split returns empty strings when two separating characters appear contiguously in the target string.
            //You can pass an optional StringSplitOptions.RemoveEmptyEntries parameter to exclude any empty strings in the output.


            //char[] separatingChar = { "<<", '....' }; 
            char[] separatingChars = {'<', '.'};

            string text1 = "one<<two......three<four";
            System.Console.WriteLine("Original text: '{0}'", text1);

            string[] words1 = text.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);
            System.Console.WriteLine("{0} substrings in text:", words1.Length);

            foreach (string s in words1)
            {
                System.Console.WriteLine(s);
            }
        }

        void patternMatchingExample()
        {
            string[] numbers = 
        {
            "123-555-0190", 
            "444-234-22450", 
            "690-555-0178", 
            "146-893-232",
            "146-555-0122",
            "4007-555-0111", 
            "407-555-0111", 
            "407-2-5555", 
        };

            string sPattern = "^\\d{3}-\\d{3}-\\d{4}$";

            foreach (string s in numbers)
            {
                System.Console.Write("{0,14}", s);

                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern))
                {
                    System.Console.WriteLine(" - valid");
                }
                else
                {
                    System.Console.WriteLine(" - invalid");
                }
            }

        }

    }
}
