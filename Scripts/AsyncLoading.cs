using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncLoading : MonoBehaviour
{
    private AsyncOperation async;
    public string sceneName = "";

    private void Start()
    {
        sceneName = "Sand_1";
        Debug.Log("Scene ASYNC - " + sceneName);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        if (sceneName == "")
            yield break;

        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        Debug.Log("start loading");

        yield return async;
    }

    private void SwitchScene()
    {
        Debug.Log("switching");

        if (async != null)
            async.allowSceneActivation = true;
    }

}