using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine;

public class MenuUIHandler : MonoBehaviour
{
    public InputField playerName;
    public Text bestScoreText;
    // Start is called before the first frame update
    private void Start()
    {
        playerName.text = "Name";
        if(DataManager.Instance.highscoreEntryList.allPlayer.Count != 0)
        {
            bestScoreText.text = "Best Score : " + DataManager.Instance.highscoreEntryList.allPlayer[0].name + " : " + DataManager.Instance.highscoreEntryList.allPlayer[0].score;
        }
    }

    public void StartNew()
    {
        DataManager.Instance.currentPlayer = new DataPlayer();
        DataManager.Instance.currentPlayer.name = playerName.text;
        DataManager.Instance.currentPlayer.score = 0;
        SceneManager.LoadScene(1);
    }

    public void ToHighscore()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        if (Application.isEditor)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit(); // original code to quit Unity player
        }
    }
}
