using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Lesson7 : MonoBehaviour {
    [Header("Move")]
    public InputAction moveInputAction;
    [Header("1D Axis")]
    public InputAction axis;
    [Header("2D Axis")]
    public InputAction vector2D;
    [Header("3D Axis")]
    public InputAction vector3D;
    [Header("Button With One")]
    public InputAction buttonWithOne;
    // Start is called before the first frame update
    void Start() {
        moveInputAction.Enable();
        moveInputAction.started += TestFunc;
        moveInputAction.performed += (context) => {
            //    print("触发事件调用");
            //    print(context.phase);
            print(context.action.name);
            print(context.control.name);
            //    print(context.ReadValue<float>());
            //};
            //moveInputAction.canceled += (context) => {
            //    print("结束事件调用");
        };

        axis.Enable();

        vector2D.Enable();

        buttonWithOne.Enable();
        buttonWithOne.performed += (context) => {
            print("组合键触发");
        };


    }
    private void TestFunc(CallbackContext callback) {
        print("开始事件调用");
    }

    // Update is called once per frame
    void Update() {
        print(vector2D.ReadValue<Vector2>());


        //print(axis.ReadValue<float>());
    }
}
