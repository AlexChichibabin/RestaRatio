using UnityEngine;
using Zenject;

public class HeroInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindActionRunner();
        BindActionResolver();

        BindActions();
    }
    private void BindActions()
    {
        Container.Bind<TakeFromCounterAction>().FromNew().AsSingle();
        Container.Bind<PutDownOnCounterAction>().FromNew().AsSingle();
        Container.Bind<ChopHoldAction>().FromNew().AsSingle();
    }
  
    private void BindActionRunner() =>
        Container.Bind<ActionRunner>().AsSingle();
    private void BindActionResolver() =>
        Container.Bind<IActionResolver>().To<ActionResolver>().AsSingle();
}