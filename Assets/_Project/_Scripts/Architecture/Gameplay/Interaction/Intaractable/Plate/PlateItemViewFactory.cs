using UnityEngine;
using Zenject;
public class PlateItemViewFactory : IPlateItemViewFactory
{
    private IConfigProvider configProvider;
    public PlateItemViewFactory(IConfigProvider configProvider)
    {
        this.configProvider = configProvider;
    }

    public GameObject CreateView(ItemData data)
    {
        var config = configProvider.GetItem(data.Id);
        if(!config.TryGetView(data.StateFlags, out var viewPrefab, false)) return null;

		GameObject view = GameObject.Instantiate(viewPrefab);
		view.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

		return view;
    }
}
