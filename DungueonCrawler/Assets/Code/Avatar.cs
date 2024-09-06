using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SotomaYorch.FiniteStateMachine {
    #region Enums

    public enum PlayerIndex {
        ONE = 0,  //Player Input start with index 0
        TWO = 1,
        THREE = 2,
        FOUR = 3
    }

    #endregion

    public class Avatar : MonoBehaviour {
        #region Knobs

        public PlayerIndex playerIndex;

        #endregion

        #region RuntimeVariables

        protected Rigidbody _rigidbody;
        protected Vector3 _moveDirection;

        #endregion

        #region UnityMethods

        void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void Update() {
            _rigidbody.velocity = _moveDirection;
        }

        #endregion

        #region PublicMethods

        public void OnMOVE(InputAction.CallbackContext value) {
            //Input.GetKeyDown(KeyCode.A);
            if (value.performed) {
                //It could be wether WASD, arrows, numpad, left thumbstick or right thumbstick
                _moveDirection = new Vector3(
                    value.ReadValue<Vector2>().x,
                    0.0f,
                    value.ReadValue<Vector2>().y
                    );
            }
            //Input.GetKeyUp(KeyCode.A);
            else if (value.canceled) {
                _moveDirection = Vector3.zero;
            }
        }

        #endregion
    }
}

