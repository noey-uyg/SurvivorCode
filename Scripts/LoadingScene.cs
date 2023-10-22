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

    //�ڷ�ƾ �Լ�
    IEnumerator LoadScene()
    {
        yield return null;
        //GameScene �񵿱������ �θ���
        AsyncOperation operation = SceneManager.LoadSceneAsync("GameScene");

        //AsyncOperation �Լ� �� allowSceneActivation�� ��� �غ� ��� Ȱ��ȭ ��� ���� true = ���, false = �����
        //false�� progress�� 0.9f���� ����
        operation.allowSceneActivation = false;

        //AsyncOperation �Լ� �� isDone�� �ش� ������ �غ�Ǿ������� ���θ� bool������ ��ȯ
        float time = 0f;
        while (!operation.isDone)
        {
            yield return null;
            time += Time.deltaTime;

            loadingtext.text = string.Format("{0:F0}%", loadingBar.value * 100);

            //AsyncOperation �Լ� �� progress�� �۾��� ���� ������ 0 ~ 1 ������ ��ȯ
            if (operation.progress < 0.9f)
            {
                //���� �� ���� ���������� �ε巯�� �� ����
                loadingBar.value = Mathf.Lerp(loadingBar.value, operation.progress, time);
                if (loadingBar.value >= operation.progress)
                {
                    time = 0f;
                }
            }
            else
            {
                //allowSceneActivation�� false�̱� ������ progress�� 0.9f���� ���߹Ƿ� 1f���� �־���
                loadingBar.value = Mathf.Lerp(loadingBar.value, 1f, time);
                if (loadingBar.value == 1f)
                {
                    //LoadingBar�� ������ �������� �� �� ��ȯ�� �̷�������� �ϰ� ��ȯ���� �ڷ�ƾ �����Ŵ
                    operation.allowSceneActivation = true;
                    yield break;
                }
            }
        }

    }
}
