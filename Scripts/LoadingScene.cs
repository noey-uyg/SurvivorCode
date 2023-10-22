using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public Slider loadingBar;
    public Text loadingtext;
    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    //코루틴 함수
    IEnumerator LoadScene()
    {
        yield return null;
        //GameScene 비동기식으로 부르기
        AsyncOperation operation = SceneManager.LoadSceneAsync("GameScene");

        //AsyncOperation 함수 중 allowSceneActivation은 장면 준비 즉시 활성화 허용 여부 true = 허용, false = 비허용
        //false시 progress가 0.9f에서 멈춤
        operation.allowSceneActivation = false;

        //AsyncOperation 함수 중 isDone은 해당 동작이 준비되었는지의 여부를 bool형으로 반환
        float time = 0f;
        while (!operation.isDone)
        {
            yield return null;
            time += Time.deltaTime;

            loadingtext.text = string.Format("{0:F0}%", loadingBar.value * 100);

            //AsyncOperation 함수 중 progress는 작업의 진행 정도를 0 ~ 1 값으로 반환
            if (operation.progress < 0.9f)
            {
                //숫자 간 선형 보간법으로 부드러운 값 변경
                loadingBar.value = Mathf.Lerp(loadingBar.value, operation.progress, time);
                if (loadingBar.value >= operation.progress)
                {
                    time = 0f;
                }
            }
            else
            {
                //allowSceneActivation이 false이기 때문에 progress가 0.9f에서 멈추므로 1f값을 넣어줌
                loadingBar.value = Mathf.Lerp(loadingBar.value, 1f, time);
                if (loadingBar.value == 1f)
                {
                    //LoadingBar가 끝까지 도달했을 때 씬 전환이 이루어지도록 하고 반환없이 코루틴 종료시킴
                    operation.allowSceneActivation = true;
                    yield break;
                }
            }
        }

    }
}
