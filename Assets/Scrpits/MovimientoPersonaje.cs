using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class MovimientoPersonaje : MonoBehaviour
{
    public GameObject bala;
    public GameObject boquilla;
    public GameObject ParticulaMuerte;
    Rigidbody2D rb;  
    Animator anim;
    CircleCollider2D collider;
    SpriteRenderer sprite;
    public float speed = 10;
    public float rotationspeed = 10;
    public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == false)
        {
            float vertical = Input.GetAxis("Vertical");
            if (vertical > 0)
            {

                rb.AddForce(transform.up * vertical * speed * Time.deltaTime);
                anim.SetBool("Impulsing", true);
            }
            else
            {
                anim.SetBool("Impulsing", false);
            }

            float horizontal = Input.GetAxis("Horizontal");
            transform.eulerAngles += new Vector3(0, 0, horizontal * rotationspeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump"))
            {
                GameObject temp = Instantiate(bala, boquilla.transform.position, transform.rotation);
                Destroy(temp, 1.5f);
            }
        }
    }

    public void Muerte()
    {
        GameObject temp= Instantiate(ParticulaMuerte, transform.position, transform.rotation);
        Destroy(temp, 2.5f);

        if (GameManager.instance.vidas<=0)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(Respawn_Coroutine());
        }
    }

    IEnumerator Respawn_Coroutine()
    {
        dead = true;
        collider.enabled = false;
        sprite.enabled = false;
        yield return new WaitForSeconds(2);
        collider.enabled = true;
        sprite.enabled = true;

        GameManager.instance.vidas -= 1;
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);
        dead = false;
    }
}
