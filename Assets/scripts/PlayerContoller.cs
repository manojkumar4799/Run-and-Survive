using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerContoller : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI scoreText;    
    public LayerMask groundLayer;
    public Transform groundChecker;
    public GameObject GameOverUI;
    public AudioSource audioSource;
    public AudioClip clip;
    public AudioClip BGM;

    private bool isGrounded = true;
    private int score = 0;

    void Start()
    {
        audioSource.loop = true;
        audioSource.PlayOneShot(BGM);
        scoreText.text = "Score: " + score;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("pulpit"))
        {
            score++;
        }
    }
    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, 2f, groundLayer);
        float horizontal = Input.GetAxis("Horizontal")*speed;
        float forward = Input.GetAxis("Vertical") * speed; ;
        transform.Translate(horizontal, 0, forward);
    }


    private void GameOver()
    {
        GameOverUI.SetActive(true);
        audioSource.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        

        scoreText.text = "Score: " + score;
        if (isGrounded == false)
        {
            audioSource.loop = false;
            audioSource.PlayOneShot(clip);            
            this.enabled = false;            
            Invoke("GameOver",3);

        }
    }
}
