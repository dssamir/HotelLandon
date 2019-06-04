using System;

namespace Patterns.DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection.Register(typeof(IAnimal), () => new Animal());

            //....

            var animalService = ServiceCollection.Resolve<IAnimal>();

            animalService.Run();
        }
    }
}
