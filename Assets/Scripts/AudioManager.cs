using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private bool musicMuted;
    private bool sfxMuted;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (musicSource == null || clip == null)
            return;
        musicSource.clip = clip;
        musicSource.loop = loop;
        if (!musicMuted)
            musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource == null || clip == null || sfxMuted)
            return;
        sfxSource.PlayOneShot(clip);
    }

    public void SetMusicMute(bool mute)
    {
        musicMuted = mute;
        if (musicSource != null)
            musicSource.mute = mute;
    }

    public void SetSFXMute(bool mute)
    {
        sfxMuted = mute;
        if (sfxSource != null)
            sfxSource.mute = mute;
    }
}
