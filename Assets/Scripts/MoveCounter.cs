using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MoveCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextCount;
    private int totalBounces = 0;
    public int targetNumber;
    public TextMeshProUGUI HighScore;
    public GameObject EndPanel;
    public GameObject PerfectMessage;
    private bool stageClear = false;
    private string LevelRecord;
    private int ScoreNumber = 0;
    void Start()
    {
        LevelRecord = "Highscore:" + SceneManager.GetActiveScene().name;
        HighScore.text = PlayerPrefs.GetInt(LevelRecord, 9999).ToString();
        UpdateInterface();
        EndPanel.SetActive(false);
        PerfectMessage.SetActive(false);
    }
    public void JumpRegister()
    {
        if (stageClear) return;
        totalBounces++;
        UpdateInterface();
    }
    void UpdateInterface()
    {
        TextCount.text = "Moves: " + totalBounces.ToString();
        if (ScoreNumber < 9999)
        {
            HighScore.text = "Highscore: " + ScoreNumber;
            HighScore.text = ScoreNumber.ToString();
        }
        else
        {
            HighScore.text = "Highscore: --";
        }
    }
    public void Complete()
    {
        stageClear = true;
        EndPanel.SetActive(true);
        if (totalBounces <= ScoreNumber)
        {
            HighScore.text = totalBounces.ToString();
            PlayerPrefs.SetInt(LevelRecord, totalBounces);
            PlayerPrefs.Save();
        }
        if (totalBounces <= targetNumber)
        {
            PerfectMessage.SetActive(true);
        }
        else
        {
            PerfectMessage.SetActive(false);
        }
    }
}
