using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetProvider : IAssetProvider
{
	private Dictionary<string, AsyncOperationHandle> cacheHandle = new Dictionary<string, AsyncOperationHandle>();
	private Dictionary<string, List<AsyncOperationHandle>> allHandles = new Dictionary<string, List<AsyncOperationHandle>>();

	public T GetPrefab<T>(string prefabPath) where T : Object
	{
		return Resources.Load<T>(prefabPath);
	}
	public T Instantiate<T>(string prefabPath) where T : Object
	{
		T obj = Resources.Load<T>(prefabPath);
		return GameObject.Instantiate(obj);
	}
	public async UniTask<TType> LoadAsync<TType>(AssetReference assetReference) where TType : class
	{
		if (cacheHandle.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle handle) == true)
		{
			return handle.Result as TType;
		}
		AsyncOperationHandle<TType> LoadOperationHandle = Addressables.LoadAssetAsync<TType>(assetReference);

		LoadOperationHandle.Completed += (h) =>
		{
			cacheHandle[assetReference.AssetGUID] = h;
		};
		AddHandle(assetReference.AssetGUID, LoadOperationHandle);

		return await LoadOperationHandle.Task;
	}
	public void Cleanup()
	{
		foreach (List<AsyncOperationHandle> asyncOperationHandles in allHandles.Values)
		{
			foreach (AsyncOperationHandle handle in asyncOperationHandles)
				Addressables.Release(handle);
		}
		allHandles.Clear();
		cacheHandle.Clear();
	}
	private void AddHandle<TType>(string assetGUID, AsyncOperationHandle<TType> operationHandle) where TType : class
	{
		if (allHandles.TryGetValue(assetGUID, out List<AsyncOperationHandle> handleList) == false)
		{
			handleList = new List<AsyncOperationHandle>();
			allHandles[assetGUID] = handleList;
		}
		handleList.Add(operationHandle);
	}
}