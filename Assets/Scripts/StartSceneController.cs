using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    public void OnStartButtonClick() 
    {
        //SceneManager.GetActiveScene().buildIndex �õ����ǵ�ǰ��������ǰ����+1������һ������������������Ǽ�����һ������ 
        AudioManager.Instance.PlayBgm(Config.btn_click);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


        
    }
}
