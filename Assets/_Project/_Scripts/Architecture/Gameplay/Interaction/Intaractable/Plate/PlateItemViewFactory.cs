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
        throw new System.NotImplementedException();
    }
}
