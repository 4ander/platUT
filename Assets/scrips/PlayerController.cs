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
    public float jumpSpeed = 10.0f;
    public float turnSmoothTime = 0.04f;
    private Vector3 facingdir;
    float turnSmoothVelocity;

    private Vector3 dir=Vector3.zero;
    // Start is called before the first frame update
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //nota: el personaje hacia cosas raras con el salto por que la linea en la que declaras cual es la Y del vector estaba abajo,
        //al parecer hay que declarar la "velocity" y la "Y" del rb cuanto antes posible para que no haga cosas raras
            dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"))*speed;
            facingdir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            dir.y = rb.velocity.y;
            rb.velocity = dir;


        if (Input.GetButtonDown("Jump"))
            {
            Ray ray1 = new Ray(transform.position + new Vector3(0.5f, 0, 0.5f), Vector3.down);
            Ray ray2 = new Ray(transform.position + new Vector3(-0.5f, 0, 0.5f), Vector3.down);
            Ray ray3 = new Ray(transform.position + new Vector3(0.5f, 0, -0.5f), Vector3.down);
            Ray ray4 = new Ray(transform.position + new Vector3(-0.5f, 0, -0.5f), Vector3.down);

            bool cast1 = Physics.Raycast(ray1, 0.7f);
            bool cast2 = Physics.Raycast(ray2, 0.7f);
            bool cast3 = Physics.Raycast(ray3, 0.7f);
            bool cast4 = Physics.Raycast(ray4, 0.7f);


            if (cast1 || cast2 || cast3 || cast4)
            {
                // add force upwards
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            }
           // dir.y = jumpSpeed;
            }
        
      
            float targetangle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetangle,ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
       
    }

 
}
