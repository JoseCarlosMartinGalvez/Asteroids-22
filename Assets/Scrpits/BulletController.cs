using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 500;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       rb.AddForce(transform.up*speed);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroide")
        {
            collision.gameObject.GetComponent<Asteroide_Controller>().Muerte();
            Destroy(gameObject);
        }
    }
}
