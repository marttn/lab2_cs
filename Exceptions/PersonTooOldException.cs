using System;

namespace lab2_cs.Exceptions
{
    class PersonTooOldException : Exception
    {
        private static readonly string DefaultMessage = "person is already dead. birthday";
        public string Birthday { get; private set; }
        
        public PersonTooOldException(DateTime dt) : base(DefaultMessage)
        {
            Birthday = Convert.ToDateTime(dt).ToShortDateString();
        }
    }
}
