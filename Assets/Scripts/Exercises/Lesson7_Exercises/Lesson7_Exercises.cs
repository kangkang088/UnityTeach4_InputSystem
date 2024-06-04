using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson7_Exercises : MonoBehaviour
{
    public GameObject bullet;
    //[Header("Move")]
    //public InputAction move;
    //[Header("Fire")]
    //public InputAction fire;
    //[Header("Jump")]
    //public InputAction jump;
    private Rigidbody rigidBody;
    private Vector3 dir;
    private RaycastHit raycastHit;

    private PlayerTest playerTest;

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        playerTest = new PlayerTest();
        playerTest.Enable();
        //move.Enable();
        //jump.Enable();
        //jump.performed += (context) => {
        //    rigidBody.AddForce(Vector3.up * 20);
        //};
        playerTest.Player.Jump.performed += (context) => {
            rigidBody.AddForce(Vector3.up * 150);
        };
        playerTest.Player.Fire.performed += (context) => {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()),out raycastHit)) {
                //得到子弹飞出的向量
                Vector3 point = raycastHit.point;
                point.y = this.transform.position.y;
                Vector3 dir = point - this.transform.position;
                Instantiate(bullet,this.transform.position,Quaternion.LookRotation(dir));
            }
        };
        //fire.Enable();
        //fire.performed += (context) => {
        //    if(Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()),out raycastHit)) {
        //        //得到子弹飞出的向量
        //        Vector3 point = raycastHit.point;
        //        point.y = this.transform.position.y;
        //        Vector3 dir = point - this.transform.position;
        //        Instantiate(bullet,this.transform.position,Quaternion.LookRotation(dir));
        //    }
        //};
    }
    void Update()
    {
        //dir = move.ReadValue<Vector2>();
        dir = playerTest.Player.Move.ReadValue<Vector2>();
        dir.z = dir.y;
        dir.y = 0;
        rigidBody.AddForce(dir * 10);
    }
}
