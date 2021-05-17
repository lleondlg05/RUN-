using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    public AudioSource effects;
    public AudioSource music;
    public Toggle musicMutedToggle;
    public Toggle effectsMutedToggle;

    public static MusicSettings globalMusicSettings;

    void Awake()
    {
        if(globalMusicSettings != null)
        {
            Destroy(gameObject);
        }
        else
        {
            globalMusicSettings = this;
            DontDestroyOnLoad(this);
        }

        int musicMutedInt = PlayerPrefs.GetInt("BackgroundMusicMuted", 0);
        if(musicMutedInt == 1)
        {
            music.mute = true;
            musicMutedToggle.isOn = true;
        }
        else
        {
            music.mute = false;
            musicMutedToggle.isOn = false;
        }

        int effectsMutedInt = PlayerPrefs.GetInt("EffectsSounds", 0);
        if(effectsMutedInt == 1)
        {   
            effects.mute = true;
            effectsMutedToggle.isOn = true;
        }
        else
        {
            effects.mute = false;
            effectsMutedToggle.isOn = false;
        }
    }

    void Start()
    {
        
    }

    public void MusicMute(bool musicMuted)
    {
        music.mute = musicMuted;
        if(musicMuted)
        {
            PlayerPrefs.SetInt("BackgroundMusicMuted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("BackgroundMusicMuted", 0);
        }
    }

    public void EffectsMute(bool effectsMuted)
    {
        effects.mute = effectsMuted;
        if(effectsMuted)
        {
            PlayerPrefs.SetInt("EffectsSounds", 1);
        }
        else
        {
            PlayerPrefs.SetInt("EffectsSounds", 0);
        }

    }

}
