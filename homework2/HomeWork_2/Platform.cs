using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_2
{
    internal class Platform
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Platform(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Platform() : this(0, "") { }

        public override string ToString() => $"[{Id}] {Name}";
      
    }
}
