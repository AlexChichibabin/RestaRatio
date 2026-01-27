using UnityEditor.Timeline.Actions;

public interface IGameAction
{
    string Id { get; }
    int Priority { get; }              // если несколько действий подходят
    bool CanExecute(ActionContext ctx);
    void Execute(ActionContext ctx);
}
