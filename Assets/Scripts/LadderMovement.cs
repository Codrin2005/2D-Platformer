using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    public GameManager gm;
    public BoxCollider2D tileCollider;
    float climbSpeed;
    float vertical;
    public Transform t;
    public Animator anim;
    public Rigidbody2D rb;
    public bool canClimb;
    public bool OnStair;
    // Start is called before the first frame update
    private void Awake()
    {
        t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        climbSpeed = 5f;
        anim.SetBool("OnStair", false);
        anim.SetBool("IsClimbing", false);
        canClimb = false;
        OnStair = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canClimb && Input.GetKeyDown("e"))
        {
            SetOnStair();
        }
    }
    private void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        if (OnStair)
        {
            anim.SetBool("IsClimbing", vertical != 0);
            rb.velocity = new Vector2(0, climbSpeed * vertical);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (OnStair)
            {
                ExitLadder();
                canClimb = false;
            }
        }
        if (collision.gameObject.tag == "Stair")
        {
            gm.ShowText(collision.gameObject);
            canClimb = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stair")
        {
            gm.HideText(collision.gameObject);
            canClimb = false;
            ExitLadder();
        }
    }
    void SetOnStair()
    {
        tileCollider.enabled = false;
        rb.velocity = new Vector2(0, 0);
        rb.gravityScale = 0;
        if (t.position.y > -2.5)
            t.position = new Vector3(4.331403f + 0.645f, t.position.y - 0.3f, -2f);
        else
            t.position = new Vector3(4.331403f + 0.645f, t.position.y + 0.3f, -2f);
        anim.SetBool("OnStair", true);
        OnStair = true;
        GetComponent<PlayerScript>().OnStair = true;
    }
    void ExitLadder()
    {
        tileCollider.enabled = true;
        rb.gravityScale = 5;
        anim.SetBool("IsClimbing", false);
        anim.SetBool("OnStair", false);
        OnStair = false;
        GetComponent<PlayerScript>().OnStair = false;
    }
}
