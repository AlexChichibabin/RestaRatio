//using CodeBase.Gameplay.Enemy;
//using CodeBase.Gameplay.Hero;
//using CodeBase.Infrastructure.DependencyInjection;
using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IGameFactory
{
	UniTask<GameObject> CreateHeroAsync(Vector3 position, Quaternion rotation);
	//UniTask<VirtualJoystick> CreateVirtualJoystickAsync();
	//UniTask<FollowCamera> CreateFollowCameraAsync();
	//UniTask<GameObject> CreateEnemy(EnemyId id, Vector3 position);
	//UniTask WarmUpAsync();


	//VirtualJoystick VirtualJoystick { get; }
	GameObject HeroObject { get; }
	//FollowCamera FollowCamera { get; }
	//HeroHealth HeroHealth { get; }
}