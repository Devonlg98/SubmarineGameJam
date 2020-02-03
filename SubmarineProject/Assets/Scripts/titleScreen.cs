using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScreen : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Button_P1") || Input.GetButtonDown("Button_P2") || Input.GetButtonDown("Button_P3") || Input.GetButtonDown("Button_P4"))
        {
            loadGame();
            Debug.Log("WORK");
        }
        if (Input.GetButtonDown("Cancel"))
        {
            quitGame();
            Debug.Log("WORK2");
        }
        if (Input.GetButtonDown("Option"))
        {
            loadCredits();
            Debug.Log("WORK2");
        }
    }
    public void loadGame()
    {
        SceneManager.LoadScene("MainMan", LoadSceneMode.Single);
    }

    public void loadCredits()
    {
        SceneManager.LoadScene("CreditScene", LoadSceneMode.Single);
    }

    public void quitGame() 
    {
        Debug.Log("editorrrr");
        Application.Quit();
    }
}
