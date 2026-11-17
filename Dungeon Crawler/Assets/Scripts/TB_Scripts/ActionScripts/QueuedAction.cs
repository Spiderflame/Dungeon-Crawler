using UnityEngine;

[System.Serializable]
public class QueuedAction
{
    public BaseChar user;
    public BaseAction action;
    public BaseChar target;

    public QueuedAction(BaseChar user, BaseAction action, BaseChar target)
    {
        this.user = user;
        this.action = action;
        this.target = target;
    }
}