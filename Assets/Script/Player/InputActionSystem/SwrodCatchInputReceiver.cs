using UnityEngine;
using UnityEngine.InputSystem;

namespace SwordCatch.Player
{
    public class SwordCatchInputReceiver : MonoBehaviour    //  入力受付
    {
        private InputSystem_Actions inputActions;
        
        private void Awake()
        {
            inputActions = new InputSystem_Actions();
        }

        private void OnEnable()
        {
            inputActions.Player.Enable();
            inputActions.Player.Catch.started += OnCatchPressed;
        }

        private void OnDisable()
        {
            inputActions.Player.Catch.started -= OnCatchPressed;
            inputActions.Player.Disable();
        }

        private void OnCatchPressed(InputAction.CallbackContext ctx)    //  キャッチが押されたときBusに伝達
        {
            //SwordCatchEventBus.RaiseCatchPressed();
        }
    }
}