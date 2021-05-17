using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSettingsCommand : MonoBehaviour
{   
    public void MusicMute(bool musicMuted)
    {
        MusicSettings.globalMusicSettings.MusicMute(musicMuted);
    }

    public void EffectsMute(bool effectsMuted)
    {
        MusicSettings.globalMusicSettings.EffectsMute(effectsMuted);
    }
}
