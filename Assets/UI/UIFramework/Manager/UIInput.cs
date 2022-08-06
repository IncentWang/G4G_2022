using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif
namespace UIFramework
{


	public class UIInput : MonoBehaviour
	{
		[Header("Character Input Values")]


		[Header("Movement Settings")]
		public bool analogMovement;

#if !UNITY_IOS || !UNITY_ANDROID
		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
#endif

#if ENABLE_INPUT_SYSTEM

		public void OnPause(InputValue value)
		{
			if (value.isPressed)
			{
				if (!PauseSetting._isPause)
				{
					SetCursorState(false);
					UIManager.Instance.PushPanel(UIPanelType.PauseSetting);
				}
				else if (PauseSetting._isPause)
				{
					SetCursorState(true);
					UIManager.Instance.PopPanel();
				}
			}
		}
		public void OnBag(InputValue value)
		{
			if (value.isPressed)
			{
				if (!Bag._isPause)
				{
					SetCursorState(false);
					UIManager.Instance.PushPanel(UIPanelType.Bag);
				}
				else if (Bag._isPause)
				{
					SetCursorState(true);
					UIManager.Instance.PopPanel();
				}
			}
		}

#else
		// old input sys if we do decide to have it (most likely wont)...
#endif





#if !UNITY_IOS || !UNITY_ANDROID

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

#endif

	}
}


