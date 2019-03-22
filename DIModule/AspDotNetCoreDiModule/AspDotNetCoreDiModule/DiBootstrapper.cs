using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace AspDotNetCoreDiModule
{
    public class DiBootstrapper
    {
        public Type StartupModule { get; }

        public IServiceCollection ServiceDescriptors { get; }

        public List<DiModule> Instances { get; }

        public DiBootstrapper(Type startupModule, IServiceCollection serviceDescriptors)
        {
            StartupModule = startupModule;
            ServiceDescriptors = serviceDescriptors;
            Instances = new List<DiModule>();
        }

        public virtual void Initialize()
        {
            var moduleTypes = FindAllModuleTypes();
            RegisterModules(moduleTypes);
            CreateModules(moduleTypes);
            StartModules();
        }
        private List<Type> FindAllModuleTypes()
        {
            var modules = DiModule.FindDependedModuleTypesRecursivelyIncludingGivenModule(StartupModule);
            return modules;
        }
        private void RegisterModules(ICollection<Type> moduleTypes)
        {
            foreach (var moduleType in moduleTypes)
            {
                ServiceDescriptors.AddTransient(moduleType);
            }
        }

        private void CreateModules(ICollection<Type> moduleTypes)
        {
            var provider = ServiceDescriptors.BuildServiceProvider();
            foreach (var moduleType in moduleTypes)
            {
                var instance = provider.GetRequiredService(moduleType) as DiModule;
                Instances.Add(instance);
            }
        }

        private void StartModules()
        {
            Instances.ForEach(module => module.PreInitialize());
            Instances.ForEach(module => module.Initialize());
            Instances.ForEach(module => module.PostInitialize());
        }
    }
}
