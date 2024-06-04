using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson9 : MonoBehaviour {
    public Lesson9Input input;
    // Start is called before the first frame update
    void Start() {
        input = new Lesson9Input();
        input.Enable();
        input.Action1.Fire.performed += (context) => {
            print("Action : Fire has triggered");
        };
    }

    // Update is called once per frame
    void Update() {
        print(input.Action1.Move.ReadValue<Vector2>());
    }
}
