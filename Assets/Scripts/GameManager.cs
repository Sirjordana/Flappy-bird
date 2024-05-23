using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pipe;
    public int score;
    public int hiScore;

    public float timer;

    public TextMeshProUGUI ScoreTxt;
    public TextMeshProUGUI HiScoreTxt;
    public TextMeshProUGUI StartTxt;

    public bool gameActive;

    public GameObject birb;
    public Rigidbody2D birbRb;

    // Start is called before the first frame update
    void Start()
    {
        birbRb = birb.GetComponent<Rigidbody2D>();
        PlayerPrefs.GetInt("HiScore");
        ChangeScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive)
        {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                float y = Random.Range(-4f, 4f);
                Instantiate(pipe, new Vector3(8, y, 0), Quaternion.identity);
                timer = 0;
            }
        }
        else if (!gameActive)
        {
            StartTxt.enabled = true;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                score = 0;

                var pipes = GameObject.FindGameObjectsWithTag("Pipe");
                foreach (var pipe in pipes)
                {
                    Destroy(pipe);
                }

                birb.transform.position = new Vector3(0, 0, 0);
                birbRb.gravityScale = 1;
                birbRb.freezeRotation = false;
                gameActive = true;
                StartTxt.enabled = false;
                score = 0;
                ScoreTxt.text = "Score: " + score.ToString();
            }
        }
    }

    public void ChangeScore(int n)
    {
        score += n;
        ScoreTxt.text = "Score: " + score.ToString();

        if (score >= hiScore)
        {
            hiScore = score;
            HiScoreTxt.text = "High Score: " + hiScore.ToString();
            PlayerPrefs.SetInt("HiScore", hiScore);
        }
    }
}
