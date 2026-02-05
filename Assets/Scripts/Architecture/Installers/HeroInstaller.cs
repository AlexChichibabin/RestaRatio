using Zenject;

public class HeroInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
		BindActionRunner();
        BindActionResolver();
    }
  
    private void BindActionRunner() =>
        Container.Bind<ActionRunner>().AsSingle();
    private void BindActionResolver() =>
        Container.Bind<IActionResolver>().To<ActionResolver>().AsSingle();
}