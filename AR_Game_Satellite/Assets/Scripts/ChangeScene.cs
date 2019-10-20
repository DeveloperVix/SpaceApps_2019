using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject loadUI;

    public void LoadThisScene(int index)
    {
        Debug.Log("Cambio escena: " + index);
        loadUI.SetActive(true);
        loadUI.GetComponent<Animator>().Play("Fade_In");
        StartCoroutine(LoadSceneGame(index));
    }
    IEnumerator LoadSceneGame(int indexScene)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(indexScene);

        while (!async.isDone)
        {
            yield return null;
        }
    }
}
