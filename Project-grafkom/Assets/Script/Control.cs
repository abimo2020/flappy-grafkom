using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public GameObject instruksi,asteroid,text, gameover;
    public AudioSource suaraScore, suaraJatuh, suaraTouch;
    Rigidbody2D Rb;
    public float jumpForce;
    float score;    
    public Text scoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Rb.gravityScale = 0;
        asteroid.SetActive(false);
        text.SetActive(false);
        gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "Score : " + score;
        if (Input.GetMouseButtonDown(0))
        {
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
        if(collision.gameObject.tag == "asteroid" || collision.gameObject.tag=="bottom")
        {
            suaraJatuh.Play();
            Destroy(gameObject);
            gameover.SetActive(true);
            asteroid.SetActive(false);
        }
    }
}
