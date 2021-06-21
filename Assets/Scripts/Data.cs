using System.Collections.Generic;

[System.Serializable]
public class DataPlayer
{
    public int score;
    public string name;
}
[System.Serializable]
public class DataPlayerList
{
    public List<DataPlayer> allPlayer;
}