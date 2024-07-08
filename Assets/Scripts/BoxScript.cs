using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    Vector2 bandForce = new Vector2(1, 0);
    bool onBand;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        onBand = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (onBand)
        {
            rb.AddForce(bandForce, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Band")
        {
            onBand = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Band")
        {
            onBand = false;
        }
    }
}
