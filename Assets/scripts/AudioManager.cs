using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource sfx;


    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;

            music.volume = PlayerPrefs.GetFloat("MusicVolume",1);
            sfx.volume = PlayerPrefs.GetFloat("SFXVolume", 1);

        }
        else Destroy(gameObject);

    }

    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }

    public void SetMusicVolume(float volume)
    {
        music.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }
    public void SetSFXVolume(float volume)
    {
        sfx.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }

    public float GetMusicVolume()
    {
        return music.volume;
    }
    public float GetSFXVolume()
    {
        return sfx.volume;
    }

}
