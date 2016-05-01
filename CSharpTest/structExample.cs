using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    //The struct type is suitable for representing lightweight objects such as Point, Rectangle, and Color.
    //Although it is just as convenient to represent a point as a class with Auto-Implemented Properties, a struct might be more efficient in some scenarios.
    //For example, if you declare an array of 1000 Point objects,
    //you will allocate additional memory for referencing each object; in this case, a struct would be less expensive. 
    public struct CoOrds
    {
        // Fields, properties, methods and events go here...
        public int x, y;

        public CoOrds(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }

    //Within a struct declaration, fields cannot be initialized unless they are declared as const or static.

    //A struct cannot declare a default constructor (a constructor without parameters) or a destructor.

    //Structs are copied on assignment. When a struct is assigned to a new variable, all the data is copied,
    //and any modification to the new copy does not change the data for the original copy.
    //This is important to remember when working with collections of value types such as Dictionary<string, myStruct>.

    //Structs are value types and classes are reference types.

    //Unlike classes, structs can be instantiated without using a new operator.

    //Structs can declare constructors that have parameters.

    //A struct cannot inherit from another struct or class, and it cannot be the base of a class.
    //All structs inherit directly from System.ValueType, which inherits from System.Object.

    //A struct can implement interfaces.

    //A struct can be used as a nullable type and can be assigned a null value.

    //Any private or otherwise inaccessible members can be initialized only in a constructor.

    //When you create a struct object using the new operator, it gets created and the appropriate constructor is called.
    //Unlike classes, structs can be instantiated without using the new operator. In such a case, there is no constructor call, which makes the allocation more efficient.
    //However, the fields will remain unassigned and the object cannot be used until all of the fields are initialized.

    //When a struct contains a reference type as a member, the default constructor of the member must be invoked explicitly,
    //otherwise the member remains unassigned and the struct cannot be used.
    class structExample
    {
    }
}
