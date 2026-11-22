
using UnityEngine;

public class PillarSpawn : MonoBehaviour
{
    public GameObject pillar;
    public float spawnRate = 2f;
    private float timer = 0f;
    public float heightOffset = 10f;
    public Bird_Script birdIsAlive;

    private bool firstSpawn = true;


   void Start()
    {
       
            birdIsAlive = FindAnyObjectByType<Bird_Script>();

            if (birdIsAlive == null)
            {
                Debug.LogError("Cannot find Bird_Script in the scene!");
            
        }
    }

    void Update()
    {
        // Wait until the player starts the game
        if (!birdIsAlive.gameStarted)
            return;

        // Stop spawning when the bird dies
        if (!birdIsAlive.birdIsAlive)
            return;

        PillarSpawnMain();
    }

    void PillarSpawnMain()
    {
        float currentSpawnRate = firstSpawn ? 0.5f : spawnRate;

        timer += Time.deltaTime;

        if (timer >= currentSpawnRate)
        {
            spawnPipe();
            timer = 0f;
            firstSpawn = false;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(
            pillar,
            new Vector3(
                transform.position.x,
                Random.Range(lowestPoint, highestPoint),
                0
            ),
            transform.rotation
        );
    }
}
