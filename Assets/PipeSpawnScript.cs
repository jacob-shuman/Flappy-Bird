using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipe;

    [SerializeField]
    private float spawnRate = 2;

    [SerializeField]
    private float heightOffset = 0.1f;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        // SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = spawnRate;
            SpawnPipe();
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        float y = Random.Range(lowestPoint, highestPoint);

        Instantiate(
            pipe,
            new Vector3(transform.position.x, y, transform.position.z),
            transform.rotation
        );
    }
}
