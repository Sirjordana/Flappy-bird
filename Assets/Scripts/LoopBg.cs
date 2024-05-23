using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBg : MonoBehaviour
{
    public float speed = 0.1f;
    private Vector3 startPosition;
    private float tileSizeZ;
    public GameManager gm; // Referència al GameController

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        startPosition = transform.position;
        tileSizeZ = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (gm.gameActive)
        {
            float newPosition = Mathf.Repeat(Time.time * speed, tileSizeZ);
            transform.position = startPosition + Vector3.left * newPosition;
        }
    }
}
