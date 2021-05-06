using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Zenject;

namespace Arkham.Services
{
    public class NameConventionFactory : IConventionFactory
    {
        [Inject] private readonly DiContainer diContainer;

        /*******************************************************************/
        public T CreateInstance<T>(string typeNameSufix)
        {
            string typeNameToInstantiate = ResolvingTypeName<T>(typeNameSufix);
            var instance = Activator.CreateInstance(null, typeof(T).Namespace + "." + typeNameToInstantiate).Unwrap();
            InjectingDependency(instance);
            return (T)instance;
        }

        private string ResolvingTypeName<T>(string typeNameSufix)
        {
            List<string> typesNameInNamespace = Assembly.GetExecutingAssembly().GetTypes()
                      .Where(t => t.Namespace == typeof(T).Namespace).Select(t => t.Name).ToList();

            return typesNameInNamespace.Contains(typeof(T).Name + typeNameSufix)
                ? typeof(T).Name + typeNameSufix
                : typeof(T).Name;
        }

        private void InjectingDependency(object instance) => diContainer.Inject(instance);
    }
}
