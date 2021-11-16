using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public GameObject instruksi,asteroid,text, credit, gameover,scoreAkhir,highscore;
    public AudioSource suaraScore, suaraJatuh, suaraTouch;
    Rigidbody2D Rb;
    public float jumpForce;
    int score;    
    public Text scoreTxt,scoreTxt2, scoreTxt3;
    // Start is called before the first frame update
    void Start()
    {
        scoreAkhir.SetActive(false);
        Rb = GetComponent<Rigidbody2D>();
        Rb.gravityScale = 0;
        asteroid.SetActive(false);
        text.SetActive(false);
        gameover.SetActive(false);
        highscore.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "Score : " + score;
        scoreTxt2.text = "Score : " + score;
        scoreTxt3.text = "Highscore : " + PlayerPrefs.GetInt("highscore");
        if (Input.GetMouseButtonDown(0))
        {
            credit.SetActive(false);
            suaraTouch.Play();
            text.SetActive(true);
            Rb.gravityScale=3;
            asteroid.SetActive(true);
            instruksi.SetActive(false);
            Rb.velocity = Vector2.up * jumpForce;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "point")
        {
            suaraScore.Play();
            score++;
        }
        if (score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        if (collision.gameObject.tag == "score")
        {
            score++;
        }
        else if(collision.gameObject.tag == "highscore")
        {
            score = PlayerPrefs.GetInt("highscore");
        }
        if(collision.gameObject.tag == "asteroid" || collision.gameObject.tag=="bottom")
        {
            suaraJatuh.Play();
            Destroy(gameObject);
            gameover.SetActive(true);
            asteroid.SetActive(false);
            text.SetActive(false);
            scoreAkhir.SetActive(true);
            highscore.SetActive(true);
        }
    }
}
