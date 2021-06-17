using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    public Text bestScoreText;
    // Start is called before the first frame update
    private void Awake()
    {
        DataManager.Instance.LoadScore();
        bestScoreText.text = "Best Score : " + DataManager.Instance.bestPlayerName + " : " + DataManager.Instance.bestScore;
        Debug.Log("Best Player : " + DataManager.Instance.bestPlayerName);
        Debug.Log("Current Player : " + DataManager.Instance.currentPlayerName);
        Debug.Log("Best Score : " + DataManager.Instance.bestScore);
        Debug.Log("Current Score : " + DataManager.Instance.currentScore);
    }

}
