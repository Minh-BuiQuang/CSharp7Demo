using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp7Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            /////////////////////////////////////////////////////////////////////
            //Out variable
            //Before C# 7
            var numberString = "1";
            var number = 0M;
            decimal.TryParse(numberString, out number);
            //After
            decimal.TryParse(numberString, out var result);
            //NOTE: Previously, you would need to separate the declaration of the out variable and its initialization into two different statements



            /////////////////////////////////////////////////////////////////////
            //Value Tuple
            //Before
            var tuple = new Tuple<string, decimal>("string", 0M);
            var tupleData = tuple.Item1 + tuple.Item2.ToString();
            //After
            //ValueTuple provide simple syntax.
            var valueTuple = ("string", 0M);

            //You can name members of the tuple
            (string product, decimal price) productTuple = ("phone", 1000M);
            var productTupleData = productTuple.product + productTuple.price;

            //You can Deconstruct a ValueTuple and extract data into variables
            var (productName, productPrice) = productTuple;

            //ValueTuple is a different type than Tuple, you can convert a ValueTuple to a Tuple
            var oldTupleType = productTuple.ToTuple();



            /////////////////////////////////////////////////////////////////////
            //Discard
            Guid.TryParse(numberString, out _);



            /////////////////////////////////////////////////////////////////////
            //Pattern matching
            //New syntax for keyword "is", update syntax for switch statement with a new keyword "when".
            //Before
            object obj = new object();
            if (obj is int)
            {
                var i = (int) obj;
            }
            //After
            {
                if (obj is DateTime i) i.AddDays(1);
            }

            if (obj is string stringVariable) stringVariable += "This is a string";
            switch (obj)
            {
                case 0: break;
                case "1": break;
                case int i: break;
                case string s: break;
                case null: break;
                case List<int> list when list.Any(): break;
                case Guid guid when guid != default(Guid): break;
            }



            /////////////////////////////////////////////////////////////////////
            //Local functions
            //Many designs for classes include methods that are called from only one location. These additional private methods keep each method small and focused. However, they can make it harder to understand a class when reading it the first time. These methods must be understood outside of the context of the single calling location.

            GetCurrentTime();
            DateTime GetCurrentTime()
            {
                return DateTime.Now;
            }
            GetCurrentTime();
            //Note: Local functions can be declared anywhere in the function. They can also be async
        }
        /////////////////////////////////////////////////////////////////////
        //Demonstrate Async main



        /////////////////////////////////////////////////////////////////////
        //Ref return
        int originalVar = 0;
        ref int RefReturn(ref int input)
        {
            return ref input;
        }

        void ModifyBeforeInt()
        {
            var result = RefReturn(ref originalVar);
            result = 1;
        }

        //Ref local
        ref int RefLocal()
        {
            return ref originalVar;
        }

        void ModifyLocalBeforeInt()
        {
            var result = RefLocal();
            result = 2;
        }

    }

    public class ExampleClass
    {
        //Auto complete for generating Properties and Fields.
        ExampleClass(int a, string b)
        {

        }

        /////////////////////////////////////////////////////////////////////
        //Expression-bodied members
        // Expression-bodied constructor
        public ExampleClass(string label) => this.Label = label;

        // Expression-bodied finalizer
        ~ExampleClass() => Console.Error.WriteLine("Finalized!");

        private string label;

        // Expression-bodied get / set accessors.
        public string Label
        {
            get => this.label;
            set => this.label = value ?? "Default label";
        }




        /////////////////////////////////////////////////////////////////////
        //Throw expressions can now be throw in a conditional expression
        void ThrowExample()
        {
            string a = string.Empty;
            string b = a ?? throw new Exception();
        }



        /////////////////////////////////////////////////////////////////////
        //Numeric literal
        void NumberLiteralExample()
        {
            //Provide new constant "0b" to indicate the number is written in binary
            var a = 0b0011;

            //Provide "_" symbol to separate digit. Can be put anywhere and doesn't change value of the variable.
            var b = 0b_0000_0001;
            var c = 123_456_789;
        }
    }
}
