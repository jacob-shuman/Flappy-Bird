using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
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
        if (transform.position.y > 5 || transform.position.y < -5)
        {
            birdIsAlive = false;
            logic.EndGame();
        }

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            rigidBody.velocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D()
    {
        birdIsAlive = false;
        logic.EndGame();
    }
}
