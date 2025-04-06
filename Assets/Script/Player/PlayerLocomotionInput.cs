using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace toNYXA.PlayerCharacterController
{
    [DefaultExecutionOrder(-2)]
    public class PlayerLocomotionInput : MonoBehaviour, PlayerControls.IPlayerActions
    {
        #region Class Variables
        [SerializeField] private bool holdToSprint = true;

        public bool SprintToggledOn { get; private set; }
        public PlayerControls PlayerControls { get; private set; }
        public Vector2 MovementInput { get; private set; }
        public Vector2 LookInput { get; private set; }
        public bool JumpPressed { get; private set; }
        #endregion

        #region Late Update Logic
        //private void LateUpdate()
        //{
        //    JumpPressed = false;
        //}
        #endregion

        #region Startup
        private void OnEnable()
        {
            PlayerControls = new PlayerControls();
            PlayerControls.Enable();

            PlayerControls.Player.Enable();
            PlayerControls.Player.SetCallbacks(this);
        }

        private void OnDisable()
        {
            PlayerControls.Player.Disable();
            PlayerControls.Player.RemoveCallbacks(this);
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            LookInput = context.ReadValue<Vector2>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
            print(MovementInput);
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            
            if (context.performed)
            {
                JumpPressed = true;
            }
            else if (context.canceled)
            {
                JumpPressed = false;
            }
        }

        public void OnPrevious(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnNext(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                SprintToggledOn = holdToSprint || !SprintToggledOn;
            }
            else if (context.canceled)
            {
                SprintToggledOn = !holdToSprint && SprintToggledOn;
            }
            Debug.Log("sprint");
        }
        #endregion
    }
}