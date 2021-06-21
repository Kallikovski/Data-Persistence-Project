using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    private string path;

    public static DataManager Instance;

    public DataPlayerList highscoreEntryList;

    public DataPlayer currentPlayer;

    private void Awake()
    {
        path = Application.persistentDataPath + "/savefile.json";
        LoadScore();
        if (highscoreEntryList == null)
        {
            highscoreEntryList = new DataPlayerList();
            highscoreEntryList.allPlayer = new List<DataPlayer>();
        }
        orderHighscoreEntryList();
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public int SortByScore(DataPlayer p1, DataPlayer p2)
    {
        return p2.score.CompareTo(p1.score);
    }

    public void orderHighscoreEntryList()
    {
        highscoreEntryList.allPlayer.Sort(SortByScore);
    }

    public void SaveScore()
    {
        highscoreEntryList.allPlayer.Add(currentPlayer);
        string json = JsonUtility.ToJson(highscoreEntryList);
        File.WriteAllText(path, json);
    }

    public void LoadScore()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataPlayerList data = JsonUtility.FromJson<DataPlayerList>(json);
            if(data != null)
            {
                highscoreEntryList = data;
            }
        }
        else
        {
            Debug.Log("Save file not found in " + path);
        }
    }

    //public void AllEntries()
    //{
    //    foreach (DataPlayer player in highscoreEntryList.allPlayer)
    //    {
    //        Debug.Log(player.score);
    //        Debug.Log(player.name);
    //    }
    //}
}
