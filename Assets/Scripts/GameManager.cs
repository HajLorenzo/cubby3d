using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    [SerializeField] private Animator FadeAnim;
    [SerializeField] private GameObject ResultPanel;
    [SerializeField] private GameObject musicObject;
    private int score;
    [SerializeField] private Text scoreTXT,resultScoreTXT;
    public bool loseGame;
    private void Awake()
    {
        score = 0;
        loseGame = false;
        _instance = this;
    }
    public void LoseGame()
    {
        loseGame = true;
        Invoke("ShowPanel", 1.5f);
    }
    private void ShowPanel()
    {
        ResultPanel.SetActive(true);
        int maxScore = score;
        if (PlayerPrefs.GetInt("cubbyMaxScore") > score)
            maxScore = PlayerPrefs.GetInt("cubbyMaxScore");

        else
            PlayerPrefs.SetInt("cubbyMaxScore", maxScore);
        resultScoreTXT.text = "High Score : " + maxScore.ToString();
        ResultPanel.transform.DOScale(1, 0.5f);
    }
    public void ScorePlus()
    {
        AudioManager.Instance.Play(3);
        score++;
        scoreTXT.text = "Score : "+score.ToString();
        scoreTXT.transform.DOScale(1.1f, 0.2f).SetLoops(2, LoopType.Yoyo);
    }
    public void RestartBtn()
    {
        EventManager.Instance.levelToLoad = "GameLevel";
        FadeAnim.SetTrigger("out");
    }
    public void MenuBtn()
    {
        EventManager.Instance.levelToLoad = "MainMenu";
        Destroy(GameObject.Find("Music"));
        FadeAnim.SetTrigger("out");
    }
}
