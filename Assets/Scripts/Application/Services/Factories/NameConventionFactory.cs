using System;
using System.Linq;
using System.Reflection;
using Zenject;

namespace Arkham.Application
{
    public class NameConventionFactory
    {
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
                .Where(type => type.Namespace == instanceType.Namespace).Select(type => type.Name)
                .Contains(instanceNameComplete) ? instanceNameComplete : instanceType.Name;

            void InjectingDependency() => diContainer.Inject(instance);
        }
    }
}
