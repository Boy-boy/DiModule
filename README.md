通过aotufac实现模块化依赖注入

我们只需在我们的类库中添加模块并继承DiModule类，将实现模块化注入！例如：

  [DependsOn(typeof(BLLModule))]</br>
  public class StartupModule:DiModule</br>
   {     
   }

最后通过在startup类里面的ConfigureServices方法里添加service.AddModule<StartupModule>()即可完成模块化注入;
  
  
