using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        base.InstallBindings();
        this.Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.BindFactory<MainMenu, MainMenuFactory>();
    }
}
