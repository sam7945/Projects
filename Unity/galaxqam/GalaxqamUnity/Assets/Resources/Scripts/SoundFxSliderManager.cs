using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class SoundFxSliderManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        Load();
    }

    public void ChangeSoundFxVolume()
    {
        Save();
    }

    private void Load()
    {
        volumeSlider.value = GameSettings._soundEffectsVolume;
    }

    private void Save()
    {
        AudioSource[] sounds = GameObject.Find("GameController").GetComponents<AudioSource>();
        GameSettings._soundEffectsVolume = volumeSlider.value;
        sounds[1].volume = volumeSlider.value;
    }
}
