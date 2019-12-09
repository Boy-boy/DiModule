# ModularInjection
使用autofac实现模块化注入

## 使用方式
1.创建.net core 2.2项目，      
2.添加初始化模块类，此类需继承DiModule，如``` public class StartupDiModule: ModularInjection.DiModule```，若想实现跨类库注入,
请在初始化模块类添加此特性 ``` [DependsOn(typeof(模块化类))]```

## 代码演示

  1.在Startup类中添加如下代码片段
  ```
    public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            return  services.AddModule<StartupDiModule>();
        }
  ```
  2. 添加初始化模块类
 
    [DependsOn(typeof(模块化类))]
    public class StartupDiModule: ModularInjection.DiModule
    {
        public override void PreInitialize()
        {
            //预初始化
        }

        public override void Initialize()
        {
            //初始化
        }

        public override void PostInitialize()
        {
            //后初始化
        }
    }
    
  
