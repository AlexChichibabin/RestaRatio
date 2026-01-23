using System.Collections.Generic;

public interface IInteractable
{
    IEnumerable<IGameAction> GetActions(ActionContext ctx);
}
