public interface IActionResolver
{
    IGameAction Resolve(ActionContext ctx);
}