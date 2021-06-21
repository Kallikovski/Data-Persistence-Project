using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreUIHandler : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    private int maxScoreEntries = 10;

    private void Awake()
    {
        entryContainer = transform.Find("BodyContainer");

        entryTemplate = entryContainer.Find("BodyBodyContainer");

        entryTemplate.gameObject.SetActive(false);

        highscoreEntryTransformList = new List<Transform>();

        //Best 10 players

        int index = maxScoreEntries;

        if(maxScoreEntries > DataManager.Instance.highscoreEntryList.allPlayer.Count)
        {
            index = DataManager.Instance.highscoreEntryList.allPlayer.Count;
        }

        for (int i = 0; i < index; i++)
        {
            CreateHightscoreEntryTransform(DataManager.Instance.highscoreEntryList.allPlayer[i], entryContainer, highscoreEntryTransformList);
        }

        //All Players

        //foreach (DataPlayer highscoreEntry in DataManager.Instance.highscoreEntryList.allPlayer)
        //{
        //    CreateHightscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        //}
    }

    private void CreateHightscoreEntryTransform(DataPlayer highscore, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryRectTransform.gameObject.SetActive(true);

        int score = highscore.score;

        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();

        string name = highscore.name;

        entryTransform.Find("PlayerName").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
