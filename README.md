通过aotufac实现模块化依赖注入

我们只需在我们的类库中添加模块并继承DiModule类，将实现模块化注入！例如：

  [DependsOn(typeof(BLLModule))]
  public class StartupModule:DiModule
    {
        public override void PreInitialize()
        {
        }
        public override void Initialize()
        {
        }

        public override void PostInitialize()
        {
        }
    }
