using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Touchscreen ts = Touchscreen.current;
        if(ts == null)
            return;
        print(ts.touches.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
