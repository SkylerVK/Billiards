﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text scoreText;
    public Text winText;

    private Rigidbody rb;
    private int score;
    public string targetTag = "Pocket";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        setScoreText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            score++;
            setScoreText();
        }
    }

    void setScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 8)
        {
            winText.text = "You Win!";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag(targetTag))
        {
            winText.text = "You Lose...";
            Destroy(gameObject);
        }
    }

    // private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag(targetTag))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
