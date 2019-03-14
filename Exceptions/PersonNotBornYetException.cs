using System;

namespace lab2_cs.Exceptions
{
    class PersonNotBornYetException : Exception
    {
        private static readonly string DefaultMessage = "person hasn't born yet. birthday";
        public string Birthday { get; private set; }

        public PersonNotBornYetException(DateTime dt) : base(DefaultMessage)
        {
            Birthday = Convert.ToDateTime(dt).ToShortDateString();
        }
    }
}
