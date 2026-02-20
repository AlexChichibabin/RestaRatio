using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IGameFactory
{
	UniTask<GameObject> CreateHeroAsync(Vector3 position, Quaternion rotation);
	GameObject HeroObject { get; }
}