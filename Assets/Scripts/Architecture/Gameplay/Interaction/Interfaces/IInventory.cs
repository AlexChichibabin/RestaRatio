using UnityEngine;

public interface IInventory
{
    bool HasItem {  get; }
    Transform Drop();
}
