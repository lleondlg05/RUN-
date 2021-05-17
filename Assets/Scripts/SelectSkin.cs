using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkin : MonoBehaviour
{   
    public void ChooseSkinPlayer(int skinInt)
    {
        PlayerPrefs.SetInt("PlayerSkin", skinInt);
    }
}
