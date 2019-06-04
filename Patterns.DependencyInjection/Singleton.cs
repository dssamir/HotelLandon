using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.DependencyInjection
{
    // Singleton<Animal>.Instance
    public sealed class Singleton<TSingleton>
        where TSingleton : new()
    {
        private static readonly Lazy<TSingleton> _instance
            = new Lazy<TSingleton>(() => new TSingleton(), true);

        /// <summary>
        /// Get the only thread safe instance of <typeparamref name="TSingleton"/>
        /// </summary>
        public static TSingleton Instance => _instance.Value;
        private Singleton() { }
    }
}
