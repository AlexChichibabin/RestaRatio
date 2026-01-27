using UnityEngine;
using Zenject;

public class HeroInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
		//BindActions();

		BindActionRunner();
        BindActionResolver();


    }
    private void BindActions()
    {
        Container.Bind<TakeFromAction>().FromNew().AsSingle().NonLazy();
        Container.Bind<PutDownOnAction>().FromNew().AsSingle().NonLazy();
        Container.Bind<ChopHoldAction>().FromNew().AsSingle().NonLazy();
    }
  
    private void BindActionRunner() =>
        Container.Bind<ActionRunner>().AsSingle();
    private void BindActionResolver() =>
        Container.Bind<IActionResolver>().To<ActionResolver>().AsSingle();
}