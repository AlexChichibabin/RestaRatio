//using CodeBase.Gameplay.Enemy;
//using CodeBase.Gameplay.Hero;
//using CodeBase.Infrastructure.DependencyInjection;
using System.Threading.Tasks;
using UnityEngine;

public interface IGameFactory
{
	Task<GameObject> CreateHeroAsync(Vector3 position, Quaternion rotation);
	//Task<VirtualJoystick> CreateVirtualJoystickAsync();
	//Task<FollowCamera> CreateFollowCameraAsync();
	//Task<GameObject> CreateEnemy(EnemyId id, Vector3 position);
	//Task WarmUp();


	//VirtualJoystick VirtualJoystick { get; }
	GameObject HeroObject { get; }
	//FollowCamera FollowCamera { get; }
	//HeroHealth HeroHealth { get; }
}