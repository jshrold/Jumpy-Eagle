
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Sources")]
    public AudioSource bgm;
    public AudioSource sfx;

    [UnitHeaderInspectable("SFX Clips")]
    public AudioClip scoreClip;
    public AudioClip flapClip;
    public AudioClip deathClip;

    [Range(0f, 1f)] public float sfxVolume = 1f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayBGM()
    {
        if (bgm != null && !bgm.isPlaying)
        {
            bgm.Play();
        }
    }
    public void PlayScore() => PlaySFX(scoreClip);
    public void PlayFlap() => PlaySFX(flapClip);
    public void PlayDeath() => PlaySFX(deathClip);

    void PlaySFX(AudioClip clip)
    {
        if (sfx != null && clip != null)
            sfx.PlayOneShot(clip, sfxVolume);
    }
}

