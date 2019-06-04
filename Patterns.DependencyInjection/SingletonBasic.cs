using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.DependencyInjection
{
    // SingletonBasic<Animal>.Instance
    public class SingletonBasic<T> where T : new()
    {
        private static T _instance;
        private static readonly object toto = new object();

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (toto)
                    {
                        if (_instance == null)
                        {
                            _instance = new T();
                        }
                    }
                }
                return _instance;
            }
        }

        private SingletonBasic() { }
    }
}
