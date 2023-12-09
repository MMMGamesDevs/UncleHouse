using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		// Voy a esconderlos al inspector porque no le veo utilidad mostrarlos, más que para ver sus movimientos y controles
		[Header("Character Input Values")]
        [HideInInspector] public Vector2 move;
        [HideInInspector] public Vector2 look;
        [HideInInspector] public bool jump;
        [HideInInspector] public bool sprint;
        [HideInInspector] public bool isAiming;
        [HideInInspector] public bool isShooting;
        [HideInInspector] public bool isCrouch;
		[HideInInspector] public bool reload;
		[HideInInspector] public bool pickup;

        [Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;			// Esconde el curso en escena
		public bool cursorInputForLook = true;		// Activa el mouse para mirar sin girar al personaje

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

        public void OnAiming(InputValue value)
        {
			//isAiming = value.isPressed;
			isAiming = !isAiming;
        }

        public void OnShooting(InputValue value)
        {
            isShooting = value.isPressed;
        }

        public void OnCrouch(InputValue value)
        {
            isCrouch = !isCrouch;
        }

		public void OnReload(InputValue value)
		{
			reload = value.isPressed;
        }

		public void OnPickup(InputValue value)
		{
			pickup = value.isPressed;
		}
#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}