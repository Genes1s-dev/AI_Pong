using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //SignalBusInstaller.Install(Container);
        //Container.DeclareSignal<BallEnteredSignal>();

        //Container.Bind<GameManager>().AsSingle();
    }
}