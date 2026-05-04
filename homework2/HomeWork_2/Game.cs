using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_2
{
    internal class Game
    {
        public int Id { get; set; }

        public int PlatformId { get; set; }

        public string Name { get; set; }

        private int _rating;

        public int Rating
        {
            get => _rating;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Рейтинг не может быть отрицательным");
                if (value > 100)
                    throw new ArgumentException("Рейтинг не может превышать 100");
                _rating = value;
            }
        }

        public Game(int id, int platformId, string name, int rating)
        {
            Id = id;
            PlatformId = platformId;
            Name = name;
            Rating = rating;
        }

        public Game() : this(0, 0, "", 0) { }

        public override string ToString() => $"[{Id}] {Name}, платформа #{PlatformId}, рейтинг: {Rating}";
    }
}
