using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]private AudioSource swordSound;
    [SerializeField]private AudioSource bgSound;
    [SerializeField]private AudioClip[] bgMusic;
    public SaveDataScrObj soundVol;

    [SerializeField]private Slider musicSlider;
    [SerializeField]private Slider sfxSlider;

    void Awake()
    {
        instance=this;
    }

    private void Start()
    {
        bgSound.clip=bgMusic[Random.Range(0,2)];
        bgSound.Play();
        bgSound.volume=soundVol.musicVal*0.3f;
        swordSound.volume=soundVol.sfxVal*0.3f;
    }

    public void PlaySwordSound()
    {
        swordSound.Play();
    }

    public void SetSlider()
    {
        musicSlider.value=soundVol.musicVal;
        sfxSlider.value=soundVol.sfxVal;
    }
    public void SetMusicSlider()
    {
        soundVol.musicVal=musicSlider.value;
        bgSound.volume=soundVol.musicVal*0.3f;
    }
    public void SetSFXSlider()
    {
        soundVol.sfxVal=sfxSlider.value;
        swordSound.volume=soundVol.sfxVal*0.3f;
    }
}
