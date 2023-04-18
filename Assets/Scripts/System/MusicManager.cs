using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    float musicVolume = 0.5f;
    AudioSource musicSource;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat("volume");
        musicSource.volume = musicVolume;
        if (volumeSlider != null)
            volumeSlider.value = musicVolume;
    }

    void Update()
    {
        musicSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }

    public void VolumeUpdater()
    {
        musicVolume = volumeSlider.value;
    }
}
