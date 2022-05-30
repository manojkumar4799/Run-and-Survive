using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pulpit : MonoBehaviour
{
    public GameObject pulpitInstance;
    public TextMeshPro timerText;

    private float timer=5;
    private float newXPos;
    private float newZPos;
    void Start()
    {
        StartCoroutine(StartTimer());
    }

    void Update()
    {
        timerText.text = "timer: " + timer;
        if (timer <= 0)
        {
            Destroy(gameObject);
            Debug.Log("pulpit destroyed");
            
        }
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(1);
        timer--;
        if (timer == 2)
        {
            CreateInstance();
        }
        StartCoroutine(StartTimer());
    }

    void GenerateNewPos()
    {
        int[] xPos = { -9, 0, 9 };
        int randomX = Random.Range(0, 3);
        newXPos = xPos[randomX];
        if (xPos[randomX] == 0)
        {
            int[] yPos = { -9, 9 };
            int randomZ = Random.Range(0, 2);
            newZPos = yPos[randomZ];

        }
        else
        {
            newZPos = 0;
        }
       
    }

    void CreateInstance()
    {
        GenerateNewPos();
        Vector3 newPos =new Vector3 (transform.position.x + newXPos, 0, transform.position.z + newZPos);

        pulpitInstance = Instantiate(pulpitInstance, newPos, Quaternion.identity);
    }
}
