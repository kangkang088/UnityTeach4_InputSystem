using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson12 : MonoBehaviour
{
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnMove(InputAction.CallbackContext context) {
        dir = context.ReadValue<Vector2>();
        dir.z = dir.y;
        dir.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(dir * 10 * Time.deltaTime);
    }
}
