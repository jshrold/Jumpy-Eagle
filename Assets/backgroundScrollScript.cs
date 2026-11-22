using UnityEngine;

public class backgroundScrollScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    public SpriteRenderer otherBackground;

    private SpriteRenderer myRenderer;
    private float cameraLeftEdge;
    private Bird_Script bird;

    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        bird = FindAnyObjectByType<Bird_Script>();

        Camera cam = Camera.main;

        cameraLeftEdge = cam.transform.position.x
            - (cam.orthographicSize * cam.aspect);
    }

    void Update()
    {
        // Stop if the bird is dead
        if (bird == null || !bird.birdIsAlive)
            return;

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (myRenderer.bounds.max.x <= cameraLeftEdge)
        {
            float newX = otherBackground.bounds.max.x
                + (myRenderer.bounds.size.x / 2f);

            transform.position = new Vector3(
                newX,
                transform.position.y,
                transform.position.z
            );
        }
    }
}