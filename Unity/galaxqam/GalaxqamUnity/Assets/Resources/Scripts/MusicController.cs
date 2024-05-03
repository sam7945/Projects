using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource musicAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        PlayForScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Init(){
        musicAudioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        LoadMusicAudioSource();
    }

    public void LoadMusicAudioSource() {
        musicAudioSource.volume = GameSettings._musicVolume;
    }

    public void PlayForScene() {
        if (GetCurrentScene().Contains("Menu")) {
            AudioClip mainMenuClip = SoundFactory.GetAudioClip(SoundFactory.MUSIC_MAIN_MENU);
            SetAndStartMusic(mainMenuClip);
            Debug.Log("Playing :" + mainMenuClip);
        }
        if (GetCurrentScene() == Constants.SCENE_CLASSIC_GAME) {
            AudioClip classicGameClip = SoundFactory.GetAudioClip(SoundFactory.MUSIC_HOLDER_CLASSIC_SCENE);
            SetAndStartMusic(classicGameClip);
            Debug.Log("Playing :" + classicGameClip);
        }
    }

    public void PlayForScene(string scene){
        if(scene == Constants.SCENE_CLASSIC_GAME){
            AudioClip classicGameClip = SoundFactory.GetAudioClip(SoundFactory.MUSIC_HOLDER_CLASSIC_SCENE);
            SetAndStartMusic(classicGameClip);
        }
    }


    void SetAndStartMusic(AudioClip ac){
        musicAudioSource.clip = ac;
        musicAudioSource.Play();
        musicAudioSource.loop = true;
    }

    string GetCurrentScene() {
        Scene current = SceneManager.GetActiveScene();
        Debug.Log("Active scene :" + current.name);
        return current.name;
    }

}
