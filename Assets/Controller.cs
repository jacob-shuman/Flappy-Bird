using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flapAudio;

    [SerializeField]
    private AudioClip hitAudio;

    [SerializeField]
    private AudioClip deathAudio;

    [SerializeField]
    private Rigidbody2D rigidBody;

    [SerializeField]
    private int flapStrength = 10;

    private LogicScript logic;

    private bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (birdIsAlive)
        {
            if (transform.position.y > 5 || transform.position.y < -5)
            {
                EndGame();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidBody.velocity = Vector2.up * flapStrength;
                audioSource.PlayOneShot(flapAudio);
            }
        }
    }

    private void OnCollisionEnter2D()
    {
        audioSource.PlayOneShot(hitAudio);
        EndGame();
    }

    void EndGame()
    {
        birdIsAlive = false;
        logic.EndGame();
        audioSource.PlayOneShot(deathAudio);
    }
}
