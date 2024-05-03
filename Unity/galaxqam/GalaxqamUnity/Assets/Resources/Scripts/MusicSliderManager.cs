using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSliderManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        Load();
    }

    public void ChangeMusicVolume()
    {
        Save();
    }

    private void Load()
    {
        volumeSlider.value = GameSettings._musicVolume;        
    }

    private void Save()
    {   
        AudioSource[] sounds = GameObject.Find("GameController").GetComponents<AudioSource>();
        GameSettings._musicVolume = volumeSlider.value;
        //todo fix
        sounds[0].volume = volumeSlider.value;
    }
}
