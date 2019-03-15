using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public float speed;
    public Text ScoreText;
    public Text WinText;

    private Rigidbody rb;
    private int score;

    // Start is called
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        WinText.text = "";
    }

    // FixedUpdate is called before physics are applied
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, -0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
        }
    }

    private void SetScoreText()
    {
        ScoreText.text = "Score: " + score.ToString();
        if (score == 12)
        {
            WinText.text = "YOU WIN!";
        }
    }
}