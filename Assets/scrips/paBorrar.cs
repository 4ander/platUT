using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paBorrar : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float jumpForce;

    public CharacterController controller;
    public Rigidbody rigidbody;

    public Vector3 moveDir;
    public Vector3 faceDir;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        if (Input.GetButton("Jump"))
        {
            if (Physics.Raycast(transform.position, Vector3.down, 0.5f))
            {
                moveDir.y += jumpForce;
            }
        }
        moveDir.y -= gravity;
    }

    void FixedUpdate()
    {
        if (moveDir.magnitude > 0)
        {
            rigidbody.velocity = moveDir;
        }
    }
    private void move()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(xInput, 0, zInput).normalized;
        moveDir *= speed;
    }

    private void tryJump()
    {
       
    }
}
