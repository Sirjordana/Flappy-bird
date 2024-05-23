using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birb : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator Anim;

    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * 5);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Anim.SetTrigger("Flap");
            rb.velocity = Vector2.zero; // Reset the velocity
            rb.AddForce(Vector2.up * 6, ForceMode2D.Impulse); // Apply an upward force
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        gm.gameActive = false;
        rb.freezeRotation = true;
    }
}
