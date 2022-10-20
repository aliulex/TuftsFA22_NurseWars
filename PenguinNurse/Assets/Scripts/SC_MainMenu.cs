using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject CreditsMenu;

    void Start()
    {
        CreditsMenu.SetActive(false);
    }

    public void PlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TestScene");
    }

    public void CreditsButton()
    {
        CreditsMenu.SetActive(true);
    }

    public void BackButton()
    {
        CreditsMenu.SetActive(false);
    }

    public void QuitButton(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
