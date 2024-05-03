using System.Collections.Generic;
using UnityEngine;

public class SoundFactory : MonoBehaviour
{
    public const string SOUND_1 = "Sound1";
    public const string SOUND_2 = "Sound2";
    public const string SOUND_3 = "Sound3";

    private Dictionary<string, AudioClip> audioClips;

    public void setAudioClips(Dictionary<string, AudioClip> audios)    {
	audioClips = audios;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        audioClips = new Dictionary<string, AudioClip>();
        audioClips[SOUND_1] = Resources.Load<AudioClip>("Sounds/" + SOUND_1);
        audioClips[SOUND_2] = Resources.Load<AudioClip>("Sounds/" + SOUND_2);
        audioClips[SOUND_3] = Resources.Load<AudioClip>("Sounds/" + SOUND_3);
    }

    public AudioClip GetAudioClip(string soundName)
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
