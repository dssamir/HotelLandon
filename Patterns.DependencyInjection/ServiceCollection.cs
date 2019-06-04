using System;
using System.Collections.Generic;

namespace Patterns.DependencyInjection
{
    public static class ServiceCollection
    {
        static readonly Dictionary<Type, Lazy<dynamic>> _collection = new Dictionary<Type, Lazy<dynamic>>();
        public static void Register<T>(Type type, Func<dynamic> func)
        {
            _collection.Add(type, func());
        }
        public static dynamic Resolve(Type type)
        {
            if (_collection.TryGetValue(type, out Lazy<dynamic> service))
            {
                return service.Value;
            }
            throw new Exception("Servcie not found!");
        }
    }
}
