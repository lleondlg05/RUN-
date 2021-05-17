using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkin : MonoBehaviour
{
    public SpriteRenderer skin;
    public Sprite Skin0;
    public Sprite Skin1;
    public Sprite Skin2;
    public Sprite Skin3; 

    void Start()
    {
        int skinSelected = PlayerPrefs.GetInt("PlayerSkin", 0);
        if(skinSelected == 0)
        {
            skin.sprite = Skin0;
        }
        else if(skinSelected == 1)
        {
            skin.sprite = Skin1;
        }
        else if(skinSelected == 2)
        {
            skin.sprite = Skin2;
        }
        else
        {
            skin.sprite = Skin3;
        }
    }
}
