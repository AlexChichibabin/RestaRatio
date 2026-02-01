using System.Collections.Generic;

public interface IActionResolver
{
	ResolvedAction? Resolve(ActionContext baseCtx/*, IReadOnlyList<IInteractable> candidates*/);
	//IGameAction Resolve(ActionContext ctx);
}