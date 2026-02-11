public struct ResolvedAction
{
	public IInteractable Target;
	public IGameAction Action;

	public ResolvedAction(IInteractable target, IGameAction action)
	{
		Target = target;
		Action = action;
	}
}

public class ActionResolver : IActionResolver
{
	public ResolvedAction? Resolve(ActionContext ctx)
	{
		ResolvedAction? best = null;
		int bestActionPrio = int.MinValue;
		int bestTargetPrio = int.MinValue;
		float bestDist = float.PositiveInfinity;

		foreach (var target in ctx.Candidates)
		{
			if (target == null) continue;

			foreach (var action in target.GetActions())
			{
				if (action == null) continue;
				if (!action.CanExecute(ctx, target)) continue;

				int ap = action.Priority;
				int tp = target.Priority;
				float d = (target.Position - ctx.Actor.transform.position).sqrMagnitude;

				bool better =
					ap > bestActionPrio ||
					(ap == bestActionPrio && tp > bestTargetPrio) ||
					(ap == bestActionPrio && tp == bestTargetPrio && d < bestDist);

				if (!better) continue;

				best = new ResolvedAction(target, action);
				bestActionPrio = ap;
				bestTargetPrio = tp;
				bestDist = d;
			}
		}

		return best;
	}
}





