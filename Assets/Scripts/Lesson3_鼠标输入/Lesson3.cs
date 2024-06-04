using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mouse mouse = Mouse.current;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.isPressed) {
            print("Êó±ê×ó¼ü³¤°´");
        }
        print(Mouse.current.position.ReadValue());
        print(Mouse.current.delta.ReadValue());
    }
}
