using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson16 : MonoBehaviour
{
    public PlayerInput input;
    // Start is called before the first frame update
    void Start()
    {
        string json = Resources.Load<TextAsset>("PlayerInputTest").text;
        input.actions = InputActionAsset.FromJson(json);
        input.onActionTriggered += Input_onActionTriggered;
    }

    private void Input_onActionTriggered(InputAction.CallbackContext context) {
        if(context.phase == InputActionPhase.Performed) {
            switch(context.action.name) {
                case "Move":
                    print("Move");
                    break;
                case "Look":
                    print("Look");
                    break;
                case "Fire":
                    print("Fire");
                    break;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
