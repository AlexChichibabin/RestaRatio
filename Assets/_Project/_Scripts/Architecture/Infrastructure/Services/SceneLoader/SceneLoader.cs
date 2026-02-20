using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : ISceneLoader
{
    private ICoroutineRunner coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner)
    {
        this.coroutineRunner = coroutineRunner;
    }

    public void Load(string name, Action onLoaded = null)
    {
        coroutineRunner.StartCoroutine(LoadAsync(name, onLoaded));
    }
    private IEnumerator LoadAsync(string name, Action onLoaded = null)
    {
        if (SceneManager.GetActiveScene().name == name)
        {
            yield return null;
            onLoaded?.Invoke();
            yield break;
        }

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);

        while (asyncOperation.isDone == false)
            yield return null;

        onLoaded?.Invoke();
    }
}