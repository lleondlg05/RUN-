using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ResetGameplay(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void LoadScene (string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public GameObject mainMenu;
    public GameObject settingsMenu;

    public void Youtube()
    {
        Application.OpenURL("https://youtube.com");
    }

    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/LuisNoComunica");
    }

    public void Instagram()
    {
        Application.OpenURL("https://instagram.com/lleondlg05._/");
    }
}
