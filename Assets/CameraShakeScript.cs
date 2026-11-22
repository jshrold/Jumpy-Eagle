using System.Collections;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    public float shakeDuration = 0.3f;
    public float offScreenMargin = 1f;   // how far past the screen edge before it's game over
    private Camera cam;
    public float shakeMagnitude = 0.2f;

    private Vector3 originalPosition;
    void Start()
    {
       originalPosition = transform.localPosition;
    }

    public void ShakeCamera()
    {
        StopAllCoroutines();
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = originalPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
    void Update()
    {
        
    }
}
