using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson11 : MonoBehaviour {
    private PlayerInput input;
    // Start is called before the first frame update
    void Start() {
        input = this.GetComponent<PlayerInput>();
        input.onDeviceLost += OnDeviceLost;
        input.onDeviceRegained += OnDeviceRegained;
        input.onControlsChanged += OnControlsChanged;

        input.onActionTriggered += OnActionTrigger;
    }

    // Update is called once per frame
    void Update() {

    }
    #region SendMessage/Broadcast
    public void OnMove(InputValue value) {
        print("Move");
        print(value.Get<Vector2>());
    }
    public void OnLook(InputValue value) {
        print("Look");
        print(value.Get<Vector2>());
    }
    public void OnFire(InputValue value) {
        if(value.isPressed)
            print("Fire");
    }
    public void OnDeviceLost(PlayerInput playerInput) {
        print("Device has lost");
    }
    public void OnDeviceRegained(PlayerInput playerInput) {
        print("Device has registed");
    }
    public void OnControlsChanged(PlayerInput playerInput) {
        print("Control has changed");
    }
    #endregion
    #region Invoke Unity Event
    public void MyFire(InputAction.CallbackContext context) {
        print("Fire");
    }
    public void MyMove(InputAction.CallbackContext context) {
        print("Move");
    }
    public void MyLook(InputAction.CallbackContext context) {
        print("Look");
    }
    #endregion
    #region Invoke C Sharp Event
    private void OnActionTrigger(InputAction.CallbackContext context) {
        print("Triggered");
        print(context.action.name);
        print(context.control.name);
        switch(context.action.name) {
            case "Fire":
                if(context.phase == InputActionPhase.Performed)
                    print("Fire");
                break;
            case "Move":
                print("Move");
                print(context.ReadValue<Vector2>());
                break;
            case "Look":
                print("Look");
                print(context.ReadValue<Vector2>());
                break;
            default:
                break;
        }
    }
    #endregion
}
