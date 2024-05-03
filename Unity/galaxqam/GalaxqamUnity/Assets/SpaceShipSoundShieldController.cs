using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipSoundShieldController : MonoBehaviour
{

    public float soundLevel = 0.0f;
    public GameObject shield;
    public float sensitivity = 100f;
    public float threshold = 0.5f;
    public int sampleWindow = 16;

    public AudioSource source;
    public AudioClip clip;
    public Microphone mic;
    public int startPosition;

    // Start is called before the first frame update
    void Start()
    {
        Init();

    }
    // Update is called once per frame
    void Update()
    {
        if ( Detector() * sensitivity > threshold ){
            shield.SetActive(true);
        } else {
            shield.SetActive(false);
        }


    }

    public float Detector()
    {
        soundLevel = GetLoudness(Microphone.GetPosition(Microphone.devices[0]), clip);
        return soundLevel;
    }

    public void MicrophoneToAudioClip()
    {
        string microphonename = Microphone.devices[0];
        clip = Microphone.Start(microphonename, true, 20, AudioSettings.outputSampleRate);
    }


    void Init()
    {
        shield = transform.Find("SpaceShip").transform.Find("SpaceShipShield").gameObject;
        shield.SetActive(false);
        MicrophoneToAudioClip();
    }

    public float GetLoudness(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;
        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        if (startPosition < 0)
        {
            startPosition = 0;
        }

        float totalLoudness = 0;

        for(int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        return totalLoudness / sampleWindow;
    }

}
