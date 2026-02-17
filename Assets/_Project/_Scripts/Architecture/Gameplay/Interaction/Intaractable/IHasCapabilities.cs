using UnityEngine;

public interface IHasCapabilities
{
    bool TryGetCapability<T>(out T cap) where T : class;
}
