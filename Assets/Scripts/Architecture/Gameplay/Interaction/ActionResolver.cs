using System.Linq;
using UnityEngine;

public class ActionResolver : IActionResolver
{
    public IGameAction Resolve(ActionContext ctx)
    {
        if (ctx.Target == null) return null;

        return ctx.Target.GetActions(ctx)
            .Where(a => a.CanExecute(ctx))
            .OrderByDescending(a => a.Priority)
            .FirstOrDefault();
    }
}
