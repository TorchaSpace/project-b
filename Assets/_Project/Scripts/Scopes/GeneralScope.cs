using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public class GeneralScope : LifetimeScope
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private GameStateManager gameStateManager;


        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(inputManager).AsImplementedInterfaces();
            builder.RegisterComponent(gameStateManager).AsImplementedInterfaces();
        }
    }

}