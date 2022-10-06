using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    Rigidbody2D rb;  
    Animator anim;
    public float speed = 10;
    public float rotationspeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
       float vertical = Input.GetAxis("Vertical");
        if ( vertical > 0)
        {
            
            rb.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("impulsing",true);
        }
        else
        {
            anim.SetBool("impulsing", false);
        }

        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles += new Vector3(0, 0,horizontal*rotationspeed* Time.deltaTime);

    }
}
