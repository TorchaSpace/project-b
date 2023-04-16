using System;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour,IInputData
    {
        public Action<Vector2> OnInputReleased { get; set; }

        [SerializeField] private GameState[] statesToSubscribe;

        private Vector3 _firstHitPos;
        private Vector3 _lastHitPos;
        private Vector2 _delta;

        private RaycastHit _hit;

        private bool _isButtonDown;
        

        private void OnEnable()
        {
            foreach (GameState gameState in statesToSubscribe)
            {
                gameState.OnGameStateUpdate += Tick;
            }
        }

        private void OnDisable()
        {
            foreach (GameState gameState in statesToSubscribe)
            {
                gameState.OnGameStateUpdate -= Tick;
            }
        }
        
        
        

        private void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isButtonDown = true;
                _firstHitPos = Input.mousePosition;
                IRaycastable objectSelected = GetRaycastable();
                objectSelected?.Execute();
            }
            
            else if (Input.GetMouseButtonUp(0))
            {
                if(!_isButtonDown) return;
                _isButtonDown = false;
                _lastHitPos = Input.mousePosition;
                OnInputReleased?.Invoke(_lastHitPos-_firstHitPos);
            }
            
            
        }



        private IRaycastable GetRaycastable()
        {
            IRaycastable raycastable = null;
            Ray ray = Camera.main.ScreenPointToRay(_firstHitPos); 
            if (Physics.Raycast(ray, out _hit))
            {
                raycastable = _hit.collider.GetComponent<IRaycastable>();
                
            }

            return raycastable;
        }
        
        
        
    }

}