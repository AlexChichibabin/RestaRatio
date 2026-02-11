using System.Collections.Generic;
using UnityEngine;

public interface IActionProvider
{
    IEnumerable<IGameAction> GetActionsByCapability();
}
