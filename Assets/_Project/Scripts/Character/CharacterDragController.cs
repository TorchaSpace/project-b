using System;
using System.Collections;
using System.Collections.Generic;
using Character.Movement;
using UnityEngine;
using VContainer;

namespace Character
{
    public class CharacterDragController : MonoBehaviour
    {
        [Inject] private IInputData _inputData;


        private void OnEnable()
        {
            _inputData.OnInputReleased += InputReleased;
        }

        private void OnDisable()
        {
            _inputData.OnInputReleased -= InputReleased;
        }


        private void InputReleased(Vector2 direction)
        {
            Vector3 targetPos = GetTarget(direction);
            CharacterMovementController c = new CharacterMovementController(transform);
            c.Move(targetPos);
        }

        
        
        
        
        
        private Vector3 GetTarget(Vector3 direction)
        {
            direction *= -1;
            Ray ray = new Ray(transform.position, direction);
            if (Physics.Raycast(ray,out RaycastHit hit,Mathf.Infinity))
            {
                Debug.Log(hit.point);
                return hit.point;
            }
            Debug.Log(hit.point);
            
            return transform.position;
        }
        
        
        
        
        
        
        
    }
}
