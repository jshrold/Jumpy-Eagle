using UnityEngine;

public class TopRandomSpriteAssigner : MonoBehaviour
{
    [Header("Assign your sprites in the Inspector")]
    public Sprite[] availableSprites;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        AssignRandomSprite();
    }

    public void AssignRandomSprite()
    {
        if (availableSprites.Length == 0) return;

        // Random.Range with integers is max-exclusive, so it safely picks from 0 to Length - 1
        int randomIndex = Random.Range(0, availableSprites.Length);
        spriteRenderer.sprite = availableSprites[randomIndex];
    }
}
