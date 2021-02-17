using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

sealed class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static UIManager instannce= new UIManager();
    private int presentScore;

    private void Awake()
    {
        GameActions.GAMEOVER += GameActions_GAMEOVER;
        ShowScore();
    }

    private void GameActions_GAMEOVER()
    {
        Debug.Log(PlayerPrefs.GetInt("HighScore") + " :  " + presentScore);


         //presentScore = 0;
        ShowScore();
        transform.GetChild(0).gameObject.SetActive(true);   
    }


    void ShowScore()
    {
        scoreText.text = "HighScore : "+PlayerPrefs.GetInt("HighScore");
    }

    public void loadLevel(int value)
    {
        GameActions.FIRELEVEL(value);
        GameActions.FIRESTARTGAME();
        transform.GetChild(1).gameObject.SetActive(false);

    }
    public void AddScore(int value)
    {
        presentScore += value;
        if (PlayerPrefs.GetInt("HighScore") < presentScore)
            PlayerPrefs.SetInt("HighScore", presentScore);

    }
    private void OnDestroy()
    {
        GameActions.GAMEOVER -= GameActions_GAMEOVER;

    }
}
