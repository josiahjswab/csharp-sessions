using System;


namespace ClassLibrary1
{
    public class MessageProvider
    {
        public string GetMessage()
        {
            var foo = new ClassLibrary1.OtherNameSpace.MySecondClass();
            return "Hello Library";
        }
    }

    public class MySecondClass
    {
        public static string GetMessage(string message)
        {

            return message + "!";
        }

        public static int MakeInteger(double num)
        {
            return (int)Math.Ceiling(num);
        }
    }

}

namespace ClassLibrary1.OtherNameSpace
{
    public class MySecondClass
    {

    }
}