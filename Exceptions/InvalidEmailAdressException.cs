using System;


namespace lab2_cs.Exceptions
{
    class InvalidEmailAdressException : Exception
    {
       
        public InvalidEmailAdressException(string message) : base($"invalid email adress: {message}")
        {
            
        }
        
    }
}
