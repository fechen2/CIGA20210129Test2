using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3;
    public float gravity = 20.0f;
    public float jumpSpeed = 8.0f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController cc;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();//获取角色控制组件

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");//左右
        float v = Input.GetAxis("Vertical");//上下
                                            //按照长度进行移动，会模拟重力直接掉到地面上
                                            //  cc.SimpleMove(new Vector3(h, 0, v) * speed);
                                            //按照向量进行移动，不模拟重力不会掉到地面上，必须*Time.deltaTime
        moveDirection = new Vector3(h, 0, v);
        moveDirection *= speed;

        if (Input.GetButton("Jump"))
            moveDirection.y = jumpSpeed;
        moveDirection.y -= gravity * Time.deltaTime;
        cc.Move(moveDirection * Time.deltaTime);
      //  Debug.Log(cc.isGrounded);//角色是否在地面上
    }

    //移动时碰到别的碰撞器时触发，会一直触发
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
     //   Debug.Log(hit.collider);//输出碰撞到的对象
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");

    }



}
