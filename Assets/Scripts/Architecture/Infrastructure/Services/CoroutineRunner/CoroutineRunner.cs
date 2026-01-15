using System.Collections;
using UnityEngine;

public class CoroutineRunner : ICoroutineRunner
{
    private MonoCoroutineRunner monoCoroutineRunner;

    public CoroutineRunner()
    {
        GameObject coroutineRunnerGameObject = new GameObject("Coroutine Runner");
        monoCoroutineRunner = coroutineRunnerGameObject.AddComponent<MonoCoroutineRunner>();

        GameObject.DontDestroyOnLoad(coroutineRunnerGameObject);
    }

    public Coroutine StartCoroutine(IEnumerator coroutine)
    {
        return monoCoroutineRunner.StartCoroutine(coroutine);
    }
}