using System;
using System.Reflection;
using Zenject;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace Arkham.Services
{
    public class NameConventionInstantiator : IInstantiatorAdapter
    {
        [Inject] private readonly DiContainer diContainer;

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
                      .Where(t => t.Namespace == typeof(T).Namespace).Select(t => t.Name)
                      .ToList();
            return typesNameInNamespace.Contains(typeof(T).Name + typeNameSufix)
                ? typeof(T).Name + typeNameSufix
                : typeof(T).Name;
        }

        private void InjectingDependency(object instance) => diContainer.Inject(instance);
    }
}
