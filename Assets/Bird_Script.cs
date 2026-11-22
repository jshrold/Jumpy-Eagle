using System.ComponentModel.Design;
using UnityEngine;

public class Bird_Script : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public Collider2D myCollider;
    public CameraShakeScript cameraShake;
    public float tiltSpeed = 5f;
    public float tiltFactor = 5f;
    public float maxUpTilt = 30f;
    public float maxDownTilt = -60f;
    public Animator birdAnimator;
    public bool gameStarted = false;
    private float startingGravityScale;
    public GameObject startText;
    public float offScreenMargin = 1f;   // how far past the screen edge before it's game over
    private Camera cam;

    void Start()
    {
        startingGravityScale = myRigidbody.gravityScale;
        myRigidbody.gravityScale = 0f;
        startText.SetActive(true);
        cam = Camera.main;
    }



    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
            {
                gameStarted = true;
                AudioManager.Instance.PlayBGM();
                AudioManager.Instance.PlayFlap();
                if (AudioManager.Instance != null)
                    AudioManager.Instance.PlayBGM();


                myRigidbody.gravityScale = startingGravityScale;
                myRigidbody.linearVelocity = Vector2.up * flapStrength;
                startText.SetActive(false);
            }

            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
            AudioManager.Instance.PlayFlap();
        }

        if (birdIsAlive)
        {
            BirdTilt();
            CheckOutOfBounds();
        }
    }

    void CheckOutOfBounds()
    {
        float top = cam.transform.position.y + cam.orthographicSize + offScreenMargin;
        float bottom = cam.transform.position.y - cam.orthographicSize - offScreenMargin;
        float y = transform.position.y;

        if (y > top || y < bottom)
        {
            Die(false);
        }
    }

    void BirdTilt()
    {
        float targetAngle = myRigidbody.linearVelocity.y * tiltFactor;

        targetAngle = Mathf.Clamp(targetAngle, maxDownTilt, maxUpTilt);

        myRigidbody.MoveRotation(
            Mathf.LerpAngle(myRigidbody.rotation, targetAngle, tiltSpeed * Time.deltaTime)
        );
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die(true);
    }

    void Die(bool bounce)
    {
        if (!birdIsAlive) return;

        birdIsAlive = false;
        AudioManager.Instance.PlayDeath();
        logic.gameOver();
        birdAnimator.speed = 0f;
        cameraShake.ShakeCamera();
        myCollider.enabled = false;

        if (bounce)
        {
            myRigidbody.linearVelocity = new Vector2(3f, 8f);
            myRigidbody.angularVelocity = 600f;
        }
    }
}