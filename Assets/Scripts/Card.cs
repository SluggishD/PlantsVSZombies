using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


enum CardState
{
    Disable,
    Cooling,
    WaitingSun,
    Ready
}

public enum PlantType 
{
    Sunflower,
    PeaShooter
}
public class Card : MonoBehaviour
{
    public PlantType plantType=PlantType.Sunflower;
    private CardState cardState = CardState.Disable;

    public GameObject cardLight;
    public GameObject cardGray;
    public Image cardMask;

    [SerializeField]
    private float cdTime = 2;
    private float cdTimer = 0;

    [SerializeField]
    private int needSunPoint = 50;
    private void Update()
    {
        switch (cardState) 
        {
            case CardState.Cooling:
                CoolingUpdate();
                break;
            case CardState.WaitingSun:
                WaitingSunUpdate();
                break;
            case CardState.Ready:
                ReadyUpdate();
                break;
            default:
                break;
        }
    }  
    void CoolingUpdate()
    {
        cdTimer += Time.deltaTime;
        //剩余时间的比例
        cardMask.fillAmount = (cdTime - cdTimer) / cdTime;
        if (cdTimer >= cdTime) 
        {
            TransitionToWaitingSun();
        }
    }
    void WaitingSunUpdate() 
    {
        if (needSunPoint <= SunManager.Instance.SunPoint) 
        {
            TransitionToReady(); 
        }


    }
    void ReadyUpdate()   
    {
        if (needSunPoint > SunManager.Instance.SunPoint)
        {
            TransitionToWaitingSun(); 
        }
    }

    void TransitionToWaitingSun() 
    {
        cardState = CardState.WaitingSun;
        cardLight.SetActive(false);
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(false);
    }

    void TransitionToReady() 
    {
        cardState = CardState.Ready;
        cardLight.SetActive(true);
        cardGray.SetActive(false);
        cardMask.gameObject.SetActive(false);
    }

    void TransitionToCooling()
    {
        cardState = CardState.Cooling;
        cdTimer = 0;
        cardLight.SetActive(false); 
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(true);
    }

    public void OnClick()
    {
        AudioManager.Instance.PlayClip(Config.btn_click);
        if (cardState == CardState.Disable) return;
        if (needSunPoint > SunManager.Instance.SunPoint)
        {
            return;
        }

        bool isSuccess= HandManager.Instance.AddPlant(plantType);
        if (isSuccess) 
        {
            SunManager.Instance.SubSun(needSunPoint);
            TransitionToCooling();
        }
        
        
    }

    public void DisableCard() 
    {
        cardState = CardState.Disable;
    }

    public void EnableCard()
    {
        TransitionToCooling();
    }
}


