using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Character.Movement
{
    public class CharacterMovementController
    {
        private Transform _character;

        private float _movementDuration = 0.1f;
        
        public CharacterMovementController(Transform characterTransform)
        {
            _character = characterTransform;
        }




        public void Move(Vector3 pos)
        {
            _character.DOMove(pos, _movementDuration * Vector3.Distance(_character.transform.position, pos));
        }




    }
}
