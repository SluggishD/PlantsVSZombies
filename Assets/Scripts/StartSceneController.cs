using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    public void OnStartButtonClick() 
    {
        //SceneManager.GetActiveScene().buildIndex 得到的是当前场景，当前场景+1就是下一个场景，下面的语句就是加载下一个场景 
        AudioManager.Instance.PlayBgm(Config.btn_click);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


        
    }
}
