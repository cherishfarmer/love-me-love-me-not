using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{

    private void Start()
    {

    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void TryAgain()
    {

    }
}
