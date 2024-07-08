using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public AudioManager audioM;
    public bool OnStair;
    public GameObject gm;
    public bool grounded;
    public Animator anim;
    public Transform t;
    public float horizontal;
    public float speed;
    public Rigidbody2D rb;

    private void Awake()
    {

    }
    void Start()
    {
        OnStair = false;
        speed = 10f;
    }


    void Update()
    {
        //lateral mvmt

        horizontal = Input.GetAxis("Horizontal");
        if (horizontal>0f && !OnStair)
        {
            t.localScale = new Vector2(3, 3);
        }
        else if (horizontal< 0f && !OnStair)
        {
            t.localScale = new Vector2(-3, 3);
        }
        if (!OnStair)
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (Input.GetKeyDown("space") && grounded == true)
        {
            Jump();
        }
        anim.SetBool("Running", horizontal != 0 && !OnStair);
    }

    //jump

    private void Jump()
    {
        grounded = false;
        rb.velocity = new Vector2(rb.velocity.x, speed);
        anim.SetTrigger("Jump");
        audioM.Play("JumpSound");
    }

    //on trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Unlockable")
        {
            gm.GetComponent<GameManager>().ShowText(collision.gameObject);
            gm.GetComponent<GameManager>().UnLockable(collision.gameObject);
        }
        if (collision.gameObject.tag == "Pickable")
        {
            gm.GetComponent<GameManager>().ShowText(collision.gameObject);
            gm.GetComponent<GameManager>().CanPick(collision.gameObject);
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            audioM.Play("LoseSound");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Unlockable")
        {
            gm.GetComponent<GameManager>().HideText(collision.gameObject);
            gm.GetComponent<GameManager>().CantUnlock(collision.gameObject);
        }
        if (collision.gameObject.tag == "Pickable")
        {
            gm.GetComponent<GameManager>().HideText(collision.gameObject);
            gm.GetComponent<GameManager>().UnPickable(collision.gameObject);
        }
    }

    //on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Band")
        {
            anim.SetBool("Grounded", true);
            grounded = true;
        }
    }

}
