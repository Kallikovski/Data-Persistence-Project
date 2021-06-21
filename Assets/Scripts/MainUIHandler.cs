using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[DefaultExecutionOrder(1000)]
public class MainUIHandler : MonoBehaviour
{
    public Text bestScoreText;

    private void Awake()
    {
        DataManager.Instance.LoadScore();
        Debug.Log(DataManager.Instance.highscoreEntryList.allPlayer.Count);

        if (DataManager.Instance.highscoreEntryList.allPlayer.Count != 0)
        {
            DataManager.Instance.orderHighscoreEntryList();
            bestScoreText.text = "Best Score : " + DataManager.Instance.highscoreEntryList.allPlayer[0].name + " : " + DataManager.Instance.highscoreEntryList.allPlayer[0].score;
        }

    }
}
