using System;
using System.Collections.Generic;

namespace Patterns.DependencyInjection
{
    public static class ServiceCollection
    {
        private static readonly Dictionary<Type, Lazy<dynamic>> _collection
            = new Dictionary<Type, Lazy<dynamic>>();

        public static void Register(Type type, Func<dynamic> func)
        {
            _collection.Add(type, func());
        }

        public static dynamic Resolve(Type type)
        {
            if (_collection.TryGetValue(type, out Lazy<dynamic> service))
            {
                return service.Value;
            }
            throw new Exception("Service not found!");
        }

        public static T Resolve<T>()
            where T : class
        {
            if (_collection.TryGetValue(typeof(T), out Lazy<dynamic> service))
            {
                return service.Value as T;
            }
            throw new Exception("Service not found!");
        }
    }
}
