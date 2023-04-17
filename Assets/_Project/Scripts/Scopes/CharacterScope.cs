using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public class CharacterScope : LifetimeScope
    {
        [SerializeField] private GeneralCharacterController generalCharacterController;
        [SerializeField] private CharacterDragController characterDragController;


        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(generalCharacterController);
            builder.RegisterComponent(characterDragController);
        }
    }
}
