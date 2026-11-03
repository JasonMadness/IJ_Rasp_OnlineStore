using System;

namespace IJ_Rasp_OnlineStore
{
    internal class Good
    {
        private string _name;

        public Good(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));

            _name = name;
        }

        public string Name => _name;
    }
}
