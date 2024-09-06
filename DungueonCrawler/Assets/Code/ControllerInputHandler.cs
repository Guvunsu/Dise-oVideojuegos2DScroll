using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SotomaYorch.FiniteStateMachine {
    public class ControllerInputHandler : MonoBehaviour {
        #region RuntimeVariables

        protected PlayerInput _playerInput;
        protected Avatar[] _allAvatarsInTheLevel;
        protected Avatar _avatarOfTheSameIndex;

        #endregion


        void Start() {
            _playerInput = GetComponent<PlayerInput>();
            //_playerInput.playerIndex;

            _allAvatarsInTheLevel = GameObject.FindObjectsOfType<Avatar>(true);
            foreach (Avatar value in _allAvatarsInTheLevel) {
                //Cast of a variable
                //PlayerIndex (enum) -> int
                //(int)value.playerIndex
                if ((int)value.playerIndex == _playerInput.playerIndex) {
                    //we found the avatar which has the same player index
                    //as of this Player Input's Controller
                    _avatarOfTheSameIndex = value;
                    _avatarOfTheSameIndex.gameObject.SetActive(true);
                }
            }
        }

        #region InputCallbackMethods

        public void OnMOVE(InputAction.CallbackContext value) {
            _avatarOfTheSameIndex.OnMOVE(value);
        }

        #endregion
    }
}