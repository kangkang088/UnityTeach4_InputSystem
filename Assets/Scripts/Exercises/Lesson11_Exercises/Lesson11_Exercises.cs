using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson11_Exercises : MonoBehaviour {
    public GameObject bullet;
    public Rigidbody rigidBody;
    private RaycastHit raycastHit;
    private Vector3 dir;
    public PlayerInput input;
    void Start() {
        //rigidBody = this.GetComponent<Rigidbody>();
        input.onActionTriggered += Input_onActionTriggered;
    }
    void Update() {
        rigidBody.AddForce(dir * 10);
    }
    #region SendMessage/BroadcastMessage
    public void OnJump(InputValue value) {
        rigidBody.AddForce(Vector3.up * 150);
    }
    public void OnFire(InputValue value) {
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()),out raycastHit)) {
            //得到子弹飞出的向量
            Vector3 point = raycastHit.point;
            point.y = this.transform.position.y;
            Vector3 dir = point - this.transform.position;
            Instantiate(bullet,this.transform.position,Quaternion.LookRotation(dir));
        }
    }
    public void OnMove(InputValue value) {
        dir = value.Get<Vector2>();
        dir.z = dir.y;
        dir.y = 0;
    }
    #endregion
    #region Invoke Unity Event
    public void OnJump(InputAction.CallbackContext context) {
        rigidBody.AddForce(Vector3.up * 150);
    }
    public void OnFire(InputAction.CallbackContext context) {
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()),out raycastHit)) {
            //得到子弹飞出的向量
            Vector3 point = raycastHit.point;
            point.y = this.transform.position.y;
            Vector3 dir = point - this.transform.position;
            Instantiate(bullet,this.transform.position,Quaternion.LookRotation(dir));
        }
    }
    public void OnMove(InputAction.CallbackContext context) {
        dir = context.ReadValue<Vector2>();
        dir.z = dir.y;
        dir.y = 0;
    }
    #endregion
    #region Invoke C Sharp Event
    private void Input_onActionTriggered(InputAction.CallbackContext context) {
        switch(context.action.name) {
            case "Move":
                dir = context.ReadValue<Vector2>();
                dir.z = dir.y;
                dir.y = 0;
                break;
            case "Jump":
                if(context.phase == InputActionPhase.Performed)
                    rigidBody.AddForce(Vector3.up * 150);
                break;
            case "Fire":
                if(context.phase != InputActionPhase.Performed)
                    return;
                if(Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()),out raycastHit)) {
                    //得到子弹飞出的向量
                    Vector3 point = raycastHit.point;
                    point.y = this.transform.position.y;
                    Vector3 dir = point - this.transform.position;
                    Instantiate(bullet,this.transform.position,Quaternion.LookRotation(dir));
                }
                break;
            default:
                break;
        }
    }
    #endregion
}
