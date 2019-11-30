using System;

namespace DelegateUssing
{
    class Delegate
    {
        public delegate bool Match(string name, int number);
        private readonly string name;
        private readonly int phoneNumber;

        public Delegate(string name, int phoneNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
        }

        public bool IsThisPerson(string name, int phoneNumber)
        {
            if (string.Equals(this.name, name, StringComparison.InvariantCulture) && this.phoneNumber.Equals(phoneNumber))
                return true;
            return false;
        }
    }
}
