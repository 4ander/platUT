using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float JumpForce;
    private Boolean canJump=true;

    private Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        jump();
    }

    private void jump()
    {
        if (Input.GetButtonDown("Jump") && canJump==true)
        {
            rig.AddForce(Vector3.up * JumpForce,ForceMode.Impulse);
        }
    }

    private void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(xInput, 0, zInput) * 5;
        rig.velocity = dir;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="ground")
        {
            canJump = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            canJump = false;
        }
    }
}
