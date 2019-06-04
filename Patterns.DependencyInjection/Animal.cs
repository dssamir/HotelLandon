using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.DependencyInjection
{
    public class Animal : IAnimal
    {
        public string Origin { get; set; }
        public void Run()
        {
            Console.WriteLine("Je cours");
        }
        public static explicit operator Human(Animal animal)
            => new Human
            {
                Origin = animal.Origin
            };
    }
}
