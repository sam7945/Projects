using System.Collections.Generic;
using UnityEngine;

public class SoundFactory : MonoBehaviour
{
    public const string MUSIC_HOLDER_CLASSIC_SCENE = "MusicHolderClassicScene";
    public const string MUSIC_MAIN_MENU = "MusicMainMenu";
    public const string SOUND_3 = "Sound3";

    public static Dictionary<string, AudioClip> audioClips;

    public void setAudioClips(Dictionary<string, AudioClip> audios)    {
	    audioClips = audios;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        audioClips = new Dictionary<string, AudioClip>();
        audioClips[MUSIC_HOLDER_CLASSIC_SCENE] = Resources.Load<AudioClip>("Sounds/" + MUSIC_HOLDER_CLASSIC_SCENE);
        audioClips[MUSIC_MAIN_MENU] = Resources.Load<AudioClip>("Sounds/" + MUSIC_MAIN_MENU);
        audioClips[SOUND_3] = Resources.Load<AudioClip>("Sounds/" + SOUND_3);
    }

    public static AudioClip GetAudioClip(string soundName)
    {
        if (audioClips.ContainsKey(soundName))
        {
            return audioClips[soundName];
        }

        Debug.LogWarning("SoundFactory: audio clip not found for sound name " + soundName);
        return null;
    }

    public AudioSource GetAudioSource(string soundName)
    {
        AudioClip audioClip = GetAudioClip(soundName);
        if (audioClip != null)
        {
            return CreateAudioSource(audioClip);
        }

        return null;
    }

    public AudioSource GetAudioSource(string soundName, bool loop, float volume)
    {
        AudioClip audioClip = GetAudioClip(soundName);
        if (audioClip != null)
        {
            AudioSource audioSource = CreateAudioSource(audioClip);
            audioSource.loop = loop;
            audioSource.volume = volume;
            return audioSource;
        }

        return null;
    }

    public void PlaySound(string soundName)
    {
        AudioClip audioClip = GetAudioClip(soundName);
        if (audioClip != null)
        {
            AudioSource.PlayClipAtPoint(audioClip, Vector3.zero);
        }
    }

    private AudioSource CreateAudioSource(AudioClip audioClip)
    {
        GameObject go = new GameObject("AudioSource");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        return audioSource;
    }
}
