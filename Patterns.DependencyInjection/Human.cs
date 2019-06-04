using System;

namespace Patterns.DependencyInjection
{
    public class Human
    {
        public DateTime BirthDate { get; set; }
        public string FullName { get; set; }
        public string Origin { get; set; }
        public static implicit operator Animal(Human human)
            => new Animal
            {
                Origin = human.Origin
            };
    }
}
