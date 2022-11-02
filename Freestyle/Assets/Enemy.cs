using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    // Variables
    public AudioClip hitsound;
    private AudioSource audioS;

    static private float enemySpeed = 0.5f;
    static private int waveNumber = 1;
    static private int waveCap = 5;

    private float enemyjitter = 0.05f;
    private float jitterCap = 80;
    private bool firstJitter = true;
    private float jitterCounter = 0;
    private int jitterDir = 1;

    private bool dropping = false;
    private int dropCounter = 0;
    private int dropSplit = 10;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    void Destruct()
    {
        Destroy(gameObject);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dropping)
        {
            Vector3 pos = transform.position;

            // Jitter
            pos.x += jitterDir * enemyjitter;

            if (jitterCounter == jitterCap)
            {

                if (firstJitter == true)
                {
                    jitterCap *= 2;
                    firstJitter = false;
                }
                
                // Set for drop
                dropping = true;

                // Change Direction
                jitterDir *= -1;
                jitterCounter = 0;
            }
            else
            {
                jitterCounter += 1;
            }

            transform.position = pos;
        } else
        {
            Vector3 pos = transform.position;

            if (dropCounter == dropSplit) {
                dropping = false;
                dropCounter = 0;
            }
            pos.y -= enemySpeed / dropSplit;
            dropCounter += 1;

            transform.position = pos;
        }
    }

    static public void spawnNewWave()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        enemySpeed *= 1.25f;

        if (waveNumber == waveCap)
        {
            SceneManager.LoadScene("Win Scene");
        }
        else
        {
            waveNumber += 1;
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            audioS.PlayOneShot(hitsound, 0.5f);
            Invoke("Destruct", 0.05f);
            ScoreKeeper.ScorePoints(1);

        } else if ((collision.collider.tag == "Player") || (collision.collider.tag == "Floor")) {
            SceneManager.LoadScene("Loss Scene");
        }
    }
}
