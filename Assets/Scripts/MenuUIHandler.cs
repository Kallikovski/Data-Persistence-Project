using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine;

public class MenuUIHandler : MonoBehaviour
{
    public InputField playerName;
    // Start is called before the first frame update
    private void Start()
    {
        playerName.text = "Name";
    }

    public void StartNew()
    {
        DataManager.Instance.currentPlayerName = playerName.text;
        SceneManager.LoadScene(1);
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
