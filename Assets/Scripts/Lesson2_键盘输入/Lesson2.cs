using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Keyboard keyboard = Keyboard.current;
        Keyboard.current.onTextInput += (c) => {
            print(c);
        };
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame) {
            print("空格键按下");
        }
        if(Keyboard.current.spaceKey.wasReleasedThisFrame) {
            print("空格键抬起"); 
        }
        if(Keyboard.current.spaceKey.isPressed) {
            print("空格键长按");
        }
        if(Keyboard.current.anyKey.wasPressedThisFrame) {
            print("任意键按下");
        }
    }
}
