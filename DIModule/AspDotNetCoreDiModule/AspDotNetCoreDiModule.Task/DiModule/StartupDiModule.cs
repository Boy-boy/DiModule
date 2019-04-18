using AspDotNetCoreDiModule.Task.Interface;
using Autofac;

namespace AspDotNetCoreDiModule.Task.DiModule
{
    public class StartupDiModule: AspDotNetCoreDiModule.DiModule
    {
        public override void PreInitialize()
        {
            ContainerBuilder.RegisterType<Student>().As<IStudents>();
        }

        public override void Initialize()
        {
        }

        public override void PostInitialize()
        {
        }
    }
}
