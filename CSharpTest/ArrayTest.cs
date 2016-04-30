using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    //In C#, arrays are actually objects, and not just addressable regions of contiguous memory as in C and C++. Array is the abstract base type of all array types.
    //You can use the properties, and other class members, that Array has.
    public class ArrayTest
    {

        public void CallArrayTestMethod()
        {

        }

        void ArrayIntialization()
        {
            // Declare and initialize an array:
                int[,] theArray = new int[5, 10];
                System.Console.WriteLine("The array has {0} dimensions.", theArray.Rank);

            // a single-dimensional array of five integers
                //int[] array = new int[5];

            //An array that stores string elements can be declared in the same way
                //string[] stringArray = new string[6];

            //Value Type and Reference Type Arrays
                //SomeType[] array4 = new SomeType[10];
                //The result of this statement depends on whether SomeType is a value type or a reference type.
                //If it is a value type, the statement creates an array of 10 elements, each of which has the type SomeType.
                //If SomeType is a reference type, the statement creates an array of 10 elements, each of which is initialized to a null reference.


            //Jagged Arrays
            //A jagged array is an array whose elements are arrays. 
            //The elements of a jagged array can be of different dimensions and sizes. A jagged array is sometimes called an "array of arrays." 
                //int[][] jaggedArray = new int[3][];
                //jaggedArray[0] = new int[5];
                //jaggedArray[1] = new int[4];
                //jaggedArray[2] = new int[2];

                //jaggedArray[0] = new int[] { 1, 3, 5, 7, 9 };
                //jaggedArray[1] = new int[] { 0, 2, 4, 6 };
                //jaggedArray[2] = new int[] { 11, 22 };

                //int[][] jaggedArray2 = new int[][] 
                //{
                //    new int[] {1,3,5,7,9},
                //    new int[] {0,2,4,6},
                //    new int[] {11,22}
                //};

            //Implicitly Typed Arrays
                //You can create an implicitly-typed array in which the type of the array instance is inferred from the elements specified in the array initializer. 
                var a = new[] { 1, 10, 100, 1000 }; // int[]
                var b = new[] { "hello", null, "world" }; // string[]
            //Implicitly-typed Arrays in Object Initializers
                //When you create an anonymous type that contains an array, the array must be implicitly typed in the type's object initializer. 
                //In the following example, contacts is an implicitly-typed array of anonymous types, each of which contains an array named PhoneNumbers.
                //Note that the var keyword is not used inside the object initializers.
                var contacts = new[] 
                {
                    new {
                            Name = " Eugene Zabokritski",
                            PhoneNumbers = new[] { "206-555-0108", "425-555-0001" }
                        },
                    new {
                            Name = " Hanying Feng",
                            PhoneNumbers = new[] { "650-555-0199" }
                        }
                };
        }

        void forLoopTest()
        {
            int[] numbers = { 4, 5, 6, 1, 2, 3, -2, -1, 0 };
            foreach (int i in numbers)
            {
                System.Console.Write("{0} ", i);
            }
            // Output: 4 5 6 1 2 3 -2 -1 0

            int[,] numbers2D = new int[3, 2] { { 9, 99 }, { 3, 33 }, { 5, 55 } };
            // Or use the short form:
            // int[,] numbers2D = { { 9, 99 }, { 3, 33 }, { 5, 55 } };

            foreach (int i in numbers2D)
            {
                System.Console.Write("{0} ", i);
            }
            // Output: 9 99 3 33 5 55
        }

        void ArgumentTest()
        {
            //Passing Single-Dimensional Arrays As Arguments
            int[] theArray = { 1, 3, 5, 7, 9 };
            PrintArray(theArray);

            //Passing Multidimensional Arrays As Arguments
            int[,] theArray2d = { { 1, 2 }, { 2, 3 }, { 3, 4 } };
            Print2DArray(theArray2d);
        }

        void PrintArray(int[] arr)
        {
            // Method code.
        }

        void Print2DArray(int[,] arr)
        {
            // Method code.
        }
        void paasingArrayUsingOutAndRef()
        {
            int[] theArray; // Initialization is not required

            // Pass the array to the callee using out:
            FillArrayOut(out theArray);


            // Initialize the array:
            int[] theArrayRef = { 1, 2, 3, 4, 5 };

            // Pass the array using ref:
            FillArrayRef(ref theArrayRef);
        }

        //In this example, the array theArray is declared in the caller (the paasingArrayUsingOutAndRef method), and initialized in the FillArrayOut method. 
        //Then, the array elements are returned to the caller and displayed.
        //Like all out parameters, an out parameter of an array type must be assigned before it is used; that is, it must be assigned by the callee.
        static void FillArrayOut(out int[] arr)
        {
            // Initialize the array:
            arr = new int[5] { 1, 2, 3, 4, 5 }; // definite assignment of arr
        }

        //In this example, the array theArrayRef is initialized in the caller (the paasingArrayUsingOutAndRef method), and passed to the FillArrayRef method by using the ref parameter.
        //Some of the array elements are updated in the FillArrayRef method. Then, the array elements are returned to the caller and displayed.

        //Like all ref parameters, a ref parameter of an array type must be definitely assigned by the caller. 
        //Therefore, there is no need to be definitely assigned by the callee. A ref parameter of an array type may be altered as a result of the call.
        //For example, the array can be assigned the null value or can be initialized to a different array.
        static void FillArrayRef(ref int[] arr)
        {
            // Create the array on demand:
            if (arr == null)
            {
                arr = new int[10]; // arr initialized to a different array
            }
            // Fill the array:
            arr[0] = 1111;
            arr[4] = 5555;
        }


    }
}
