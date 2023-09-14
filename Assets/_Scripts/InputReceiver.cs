using System;
using UnityEngine;

namespace _Scripts
{
    public class InputReceiver : MonoBehaviour
    {
        private float _lastMovementX;
        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                OnJump?.Invoke();
            }
            
            _lastMovementX = Input.GetAxis("Horizontal");
        }

        public float GetMovementX()
        {
            return _lastMovementX;
        }

        public event Action OnJump;
    }
}