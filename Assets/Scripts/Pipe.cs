using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameManager gm;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(-4, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameActive)
        {
            timer += Time.deltaTime;
            if (timer > 4)
            {
                Destroy(gameObject);
            }
        }
        else if (!gm.gameActive)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
