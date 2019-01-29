using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheep : MonoBehaviour
{
    public int count = 0;
    public float thrust;
    public float jumpPower = 3f;
    public Rigidbody rb;
    public int speed;
    public int distance;
    public GameObject panelGameOver;
    public int score = 0;
    public UnityEngine.UI.Text textScore;
    public UnityEngine.UI.Text textHighScore;
    public AudioSource audioScore;
    public AudioSource audioDie;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        textHighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = score.ToString();
        rb.velocity = transform.forward * speed;
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.right * thrust);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.transform.Translate(Vector3.right * distance);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.transform.Translate(-Vector3.right * distance);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Die")
        {
            panelGameOver.SetActive(true);
            audioDie.Play();
            this.enabled = false;
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Point")
        {
            score++;
           if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
                PlayerPrefs.Save();
            }
           
            other.gameObject.SetActive(false);
            audioScore.Play();
        }
    }
}