using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void TryAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
