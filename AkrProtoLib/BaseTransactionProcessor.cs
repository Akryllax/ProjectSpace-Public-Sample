using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetworkCore
{
    public abstract class BaseTransactionProcessor
    {
        public static List<T> GetInstances<T>()
        {
            List<T> objects = new List<T>();
            foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                objects.Add((T)Activator.CreateInstance(type));
            }

            return objects;
        }

        protected abstract void ProcessTransaction(BaseTransaction transaction);
    }
}
