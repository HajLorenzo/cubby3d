using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Animator btnAnim;
    [SerializeField] private Animator fadeAnim;
    [SerializeField] private GameObject musicObject;
    public void PlayButton()
    {
        btnAnim.SetTrigger("play");
        AudioManager.Instance.Play(0);
        Destroy(musicObject);
        EventManager.Instance.levelToLoad = "GameLevel";
        fadeAnim.SetTrigger("out");
    }
    public void YoutubeClick()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCZ-UbBc0qRAW8ghp4wNFeNA"); // my youtube channel :| subscribe :|
    }
    public void InstagramClick()
    {
        Application.OpenURL("https://www.instagram.com/_unityfast_/");
    }
}
