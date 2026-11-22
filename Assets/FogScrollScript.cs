using UnityEngine;

public class FogScrollScript : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public SpriteRenderer otherFog;

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
        if (bird == null || !bird.birdIsAlive) return;

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (myRenderer.bounds.max.x <= cameraLeftEdge)
        {
            float newX = otherFog.bounds.max.x
                + (myRenderer.bounds.size.x / 2f);

            transform.position = new Vector3(
                newX,
                transform.position.y,
                transform.position.z
            );
        }
    }
}