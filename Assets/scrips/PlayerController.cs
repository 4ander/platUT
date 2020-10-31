using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    CharacterController ct;
    private Rigidbody rb;
    public float speed = 3f;
    public float gravity = 20.0f;
    public float jumpSpeed = 8.0f;
    public float turnSmoothTime = 0.04f;
    float turnSmoothVelocity;

    private Vector3 dir=Vector3.zero;
    // Start is called before the first frame update
    
    void Start()
    {
        ct = gameObject.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ct.isGrounded)
        {
            dir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")).normalized;
            dir *= speed;

            if (Input.GetButton("Jump"))
            {
                dir.y = jumpSpeed;
            }
        }
      
            float targetangle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetangle,ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            ct.Move(dir * Time.deltaTime);

        
        dir.y -= gravity * Time.deltaTime;
       
    }

 
}
