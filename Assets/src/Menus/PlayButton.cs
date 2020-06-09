using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Play button was clicked.");
        UnityEngine.SceneManagement.SceneManager.LoadScene("HealthBarScene");
    }
}
