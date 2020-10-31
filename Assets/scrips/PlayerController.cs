using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    CharacterController ct;
    private Rigidbody rb;
    private float speed = 1f;
    public float gravity = 20.0f;

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
            dir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            dir *= speed;
        }
        dir.y -= gravity * Time.deltaTime;
           
        ct.Move(dir * Time.deltaTime);
    }

 
}
