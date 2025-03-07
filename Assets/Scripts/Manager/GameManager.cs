using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public PrepareUI prepareUI; 
    public CardListUI cardListUI;
    public FailUI failUI;
    public WinUI winUI;
    private bool IsGameEnd=false;
    private void Awake()
    {
        Instance = this; 
    }

    private void Start()
    {
        GameStart();
    }
    void GameStart() 
    {
        Vector3 currentPosition =Camera.main.transform.position;
        Camera.main.transform.DOPath(new Vector3[] { currentPosition, new Vector3(5, 0, -10), currentPosition }, 4,PathType.Linear).OnComplete(OnCameraMoveBack);
    }


    public void GameEndFail() 
    {
        if(IsGameEnd == true)return;
        IsGameEnd = true;
        failUI.Show();
        ZombieManager.Instance.Pause();
        cardListUI.DisableCardList();
        SunManager.Instance.StopProduece();

        AudioManager.Instance.PlayClip(Config.lose_music);
    }

    public void GameEndSuccess() 
    {
        if (IsGameEnd == true) return;
        IsGameEnd = true;
        winUI.Show();  
        cardListUI.DisableCardList();
        SunManager.Instance.StopProduece();

        AudioManager.Instance.PlayClip(Config.win_music);
    }

    void OnCameraMoveBack() 
    {
        prepareUI.Show(OnPrepareUIComplete);
    }

    void OnPrepareUIComplete() 
    {
        SunManager.Instance.StartProduce();
        ZombieManager.Instance.StartSpawn();
        cardListUI.ShowCardList();
        AudioManager.Instance.PlayBgm(Config.bgm1);
    }
}
