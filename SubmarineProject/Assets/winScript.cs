using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("winScene", LoadSceneMode.Single);
    }

    public void loadLose()
    {
        SceneManager.LoadScene("LoseScene", LoadSceneMode.Single);
    }
}
