using System;

namespace CodeConvention.CustomExceptions
{
    public class MyOwnException : Exception
    {
        public MyOwnException() : base()
        {

        }

        public MyOwnException(string message) : base(message)
        {

        }

        public MyOwnException(string message, Exception ex) : base(message, ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine($"Its My Own Expcetion + {message}");


        }

    }
}
