using UnityEditor.Timeline.Actions;

public interface IGameAction
{
    string Id { get; }
    int Priority { get; }              // если несколько действий подходят
    bool CanExecute(ActionContext ctx, IInteractable inter);
    void Execute(ActionContext ctx, IInteractable inter);
}
