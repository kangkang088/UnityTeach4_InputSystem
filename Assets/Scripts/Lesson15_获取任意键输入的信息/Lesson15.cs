using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Lesson15 : MonoBehaviour {
    public InputAction input;
    // Start is called before the first frame update
    void Start() {
        input.Enable();
        input.performed += (context) => {
            print("123");
            print(context.control.name);
        };
        //Keyboard.current.onTextInput += (c) => {
        //    print(c);
        //};

        InputSystem.onAnyButtonPress.CallOnce((control) => {
            print(control.path);
            print(control.name);
        });
    }

    // Update is called once per frame
    void Update() {

    }
}
