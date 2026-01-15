using System;

public interface ISceneLoader
{
    void Load(string name, Action onLoaded = null);
}