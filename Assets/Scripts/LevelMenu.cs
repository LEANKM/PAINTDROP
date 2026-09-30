using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Level01");
    }
    public void NextCourse()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
    public void GoBack()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
