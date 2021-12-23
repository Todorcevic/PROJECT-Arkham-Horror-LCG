using System;
using System.Linq;
using System.Reflection;
using Zenject;

namespace Arkham.Application
{
    public class NameConventionFactoryService
    {
        private const string NULL_SUFFIX = "Null";
        [Inject] private readonly DiContainer diContainer;

        /*******************************************************************/
        public T CreateInstance<T>(string typeNameSufix)
        {
            Type instanceType = typeof(T);
            Assembly assembly = Assembly.GetAssembly(instanceType);
            string instanceNameComplete = instanceType.Name + typeNameSufix;
            object instance = Activator.CreateInstance(assembly.FullName, instanceType.Namespace + "." + ResolvingTypeName()).Unwrap();
            InjectingDependency();
            return (T)instance;

            string ResolvingTypeName() => assembly.GetTypes()
                .Where(type => type.Namespace == instanceType.Namespace && !type.IsInterface).Select(type => type.Name)
                .Contains(instanceNameComplete) ? instanceNameComplete : instanceType.Name + NULL_SUFFIX;

            void InjectingDependency() => diContainer.Inject(instance);
        }
    }
}
