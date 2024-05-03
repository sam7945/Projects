using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundFxController : MonoBehaviour
{
    public AudioSource soundEffectAudioSource;
    public SoundFactory soundFactory;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Init(){
        soundEffectAudioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        soundFactory = gameObject.GetComponent<SoundFactory>();
        LoadMusicAudioSource();
    }

    public void LoadMusicAudioSource() {
        soundEffectAudioSource.volume = GameSettings._soundEffectsVolume;
    }

    void SetAndStartSoundFx(AudioClip ac){
        soundEffectAudioSource.clip = ac;
        soundEffectAudioSource.Play();
        soundEffectAudioSource.loop = false;
    }

}
