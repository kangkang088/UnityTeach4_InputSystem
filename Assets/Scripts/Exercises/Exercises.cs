using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Exercises : MonoBehaviour
{
    private GameObject obj = null;
    private int scaleFactor = 1;
    public Material redMaterial;
    private Material normalMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(obj != null) {
            if(Keyboard.current.numpadPlusKey.wasPressedThisFrame || Keyboard.current.equalsKey.wasPressedThisFrame) {
                scaleFactor += 1;

                obj.transform.localScale = scaleFactor * Vector3.one;
            }
            if(Keyboard.current.numpadMinusKey.wasPressedThisFrame || Keyboard.current.minusKey.wasPressedThisFrame) {
                scaleFactor -= 1;
                if(scaleFactor < 1)
                    scaleFactor = 1;
                obj.transform.localScale = scaleFactor * Vector3.one;
            }
        }
        if(Mouse.current.leftButton.wasPressedThisFrame) {
            RaycastHit raycastHit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()),out raycastHit)) {
                obj = raycastHit.collider.gameObject;
                normalMaterial = obj.GetComponent<MeshRenderer>().material;
                obj.GetComponent<MeshRenderer>().material = redMaterial;
            }
            else {
                if(obj != null) {
                    obj.GetComponent<MeshRenderer>().material = normalMaterial;
                }
                normalMaterial = null;
                obj = null;
            }
        }
        
    }
}
