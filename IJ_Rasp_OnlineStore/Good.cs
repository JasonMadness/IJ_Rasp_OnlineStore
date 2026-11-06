using System;

namespace IJ_Rasp_OnlineStore
{
    internal class Good
    {
        public string Name { get; private set; }

        public Good(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));

            Name = name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Good other && Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
