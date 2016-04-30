using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    //A delegate is a type that represents references to methods with a particular parameter list and return type. 
    //When you instantiate a delegate, you can associate its instance with any method with a compatible signature and return type.
    //You can invoke (or call) the method through the delegate instance.

    //Delegates are used to pass methods as arguments to other methods.
    //Event handlers are nothing more than methods that are invoked through delegates.
    //You create a custom method, and a class such as a windows control can call your method when a certain event occurs.
        //The following example shows a delegate declaration:
            //public delegate int PerformCalculation(int x, int y);
    //Any method from any accessible class or struct that matches the delegate type can be assigned to the delegate. The method can be either static or an instance method.
    //This makes it possible to programmatically change method calls, and also plug new code into existing classes

    //In the context of method overloading, the signature of a method does not include the return value.
    //But in the context of delegates, the signature does include the return value. In other words, a method must have the same return type as the delegate.

    //This ability to refer to a method as a parameter makes delegates ideal for defining callback methods. 
    //For example, a reference to a method that compares two objects could be passed as an argument to a sort algorithm.
    //Because the comparison code is in a separate procedure, the sort algorithm can be written in a more general way.
    //Delegates Overview
        //Delegates have the following properties:
            //Delegates are like C++ function pointers but are type safe.
            //Delegates allow methods to be passed as parameters.
            //Delegates can be used to define callback methods.
            //Delegates can be chained together; for example, multiple methods can be called on a single event.
                //Methods do not have to match the delegate type exactly. For more information, see Using Variance in Delegates (C# and Visual Basic).
                //C# version 2.0 introduced the concept of Anonymous Methods, which allow code blocks to be passed as parameters in place of a separately defined method.
                //C# 3.0 introduced lambda expressions as a more concise way of writing inline code blocks.
                //Both anonymous methods and lambda expressions (in certain contexts) are compiled to delegate types. Together, these features are now known as anonymous functions.
    class Delegates
    {

        //A delegate object is normally constructed by providing the name of the method the delegate will wrap, or with an anonymous Method.
        //Once a delegate is instantiated, a method call made to the delegate will be passed by the delegate to that method. 
        //The parameters passed to the delegate by the caller are passed to the method, and the return value, if any, from the method is returned to the caller by the delegate.
        //This is known as invoking the delegate. An instantiated delegate can be invoked as if it were the wrapped method itself. For example:
        public delegate void Del(string message);
        // Create a method for a delegate.
        public static void DelegateMethod(string message)
        {
            System.Console.WriteLine(message);
        }

        public void useDelegates()
        {
            // Instantiate the delegate.
            Del handler = DelegateMethod;

            // Call the delegate.
            handler("Hello World");

            //output: The number is: 3
            //Using the delegate as an abstraction, MethodWithCallback does not need to call the console directly—it does not have to be designed with a console in mind.
            //What MethodWithCallback does is simply prepare a string and pass the string to another method.
            //This is especially powerful since a delegated method can use any number of parameters.
            MethodWithCallback(1, 2, handler);
        }

        //Delegate types are derived from the Delegate class in the .NET Framework.
        //Delegate types are sealed—they cannot be derived from— and it is not possible to derive custom classes from Delegate.
        //Because the instantiated delegate is an object, it can be passed as a parameter, or assigned to a property.
        //This allows a method to accept a delegate as a parameter, and call the delegate at some later time.
        //This is known as an asynchronous callback, and is a common method of notifying a caller when a long process has completed.
        //When a delegate is used in this fashion, the code using the delegate does not need any knowledge of the implementation of the method being used.
        //The functionality is similar to the encapsulation interfaces provide.

        //Another common use of callbacks is defining a custom comparison method and passing that delegate to a sort method.
        //It allows the caller's code to become part of the sort algorithm. The following example method uses the Del type as a parameter:
        public void MethodWithCallback(int param1, int param2, Del callback)
        {
            callback("The number is: " + (param1 + param2).ToString());
        }

       

        //When a delegate is constructed to wrap an instance method, the delegate references both the instance and the method.
        //A delegate has no knowledge of the instance type aside from the method it wraps, 
        //so a delegate can refer to any type of object as long as there is a method on that object that matches the delegate signature.
        //When a delegate is constructed to wrap a static method, it only references the method. Consider the following declarations:

        public class MethodClass
        {
            public void Method1(string message) { }
            public void Method2(string message) { }
        }
        //Along with the static DelegateMethod shown previously, we now have three methods that can be wrapped by a Del instance.
        public void exampleForInstanceMethod()
        {
            MethodClass obj = new MethodClass();
            Del d1 = obj.Method1;
            Del d2 = obj.Method2;
            Del d3 = DelegateMethod;

            //Both types of assignment are valid.
            Del allMethodsDelegate = d1 + d2;
            allMethodsDelegate += d3;

            //At this point allMethodsDelegate contains three methods in its invocation list—Method1, Method2, and DelegateMethod.
            //The original three delegates, d1, d2, and d3, remain unchanged. When allMethodsDelegate is invoked, all three methods are called in order.
            //If the delegate uses reference parameters, the reference is passed sequentially to each of the three methods in turn, 
            //and any changes by one method are visible to the next method.
            //When any of the methods throws an exception that is not caught within the method, 
            //that exception is passed to the caller of the delegate and no subsequent methods in the invocation list are called. 
            //If the delegate has a return value and/or out parameters, it returns the return value and parameters of the last method invoked.
            //To remove a method from the invocation list, use the decrement or decrement assignment operator ('-' or '-='). For example:

            //remove Method1
            allMethodsDelegate -= d1;

            // copy AllMethodsDelegate while removing d2
            Del oneMethodDelegate = allMethodsDelegate - d2;

            //Because delegate types are derived from System.Delegate, the methods and properties defined by that class can be called on the delegate.
            //For example, to find the number of methods in a delegate's invocation list, you may write:
            int invocationCount = d1.GetInvocationList().GetLength(0);

            //Comparing delegates of two different types assigned at compile-time will result in a compilation error.
            //If the delegate instances are statically of the type System.Delegate, then the comparison is allowed, but will return false at run time. For example:
            // Compile-time error.
            //Console.WriteLine(d1 == e2);

            // OK at compile-time. False if the run-time type of f 
            // is not the same as that of d.
            System.Console.WriteLine(d1 == d2);
        }

        //Delegates with Named vs. Anonymous Methods
           //1- A delegate can be associated with a named method. When you instantiate a delegate by using a named method, the method is passed as a parameter.
           //Delegates constructed with a named method can encapsulate either a static method or an instance method. 
           //Although the delegate can use an out parameter, we do not recommend its use with multicast event delegates because you cannot know which delegate will be called.
           //2- However, in a situation where creating a new method is unwanted overhead, 
           //C# enables you to instantiate a delegate and immediately specify a code block that the delegate will process when it is called.
           //The block can contain either a lambda expression or an anonymous method.
    }
}
