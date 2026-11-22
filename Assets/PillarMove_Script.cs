using UnityEngine;

public class PillarMove_Script : MonoBehaviour
{

    public float moveSpeed = 5;
    public float deadZone = -12;
    public LogicScript logic;
    public Bird_Script birdIsAlive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdIsAlive = FindAnyObjectByType<Bird_Script>();
    }

    // Update is called once per frame
    void Update()
    {
       if (birdIsAlive.birdIsAlive)
        {
            MovePillar();
        }
        else
        {
            StopPillar();
        }

    }

    void MovePillar()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }

    }
    void StopPillar()
    {
        moveSpeed = 0f;
    }
}
