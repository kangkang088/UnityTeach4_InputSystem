using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Gamepad gamepad = Gamepad.current;
        if(gamepad == null)
            return;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
