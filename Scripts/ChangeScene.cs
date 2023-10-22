using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void GameExit()
    {
        SoundManager.instance.PlaySfx(SoundManager.Sfx.Click);

        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            GameManager.instance.SavePlayerDataToJson();
        }
        Application.Quit();
    }

    public void GameStart()
    {
        SoundManager.instance.PlaySfx(SoundManager.Sfx.Click);
        SceneManager.LoadScene("LoadingScene");
    }
}
