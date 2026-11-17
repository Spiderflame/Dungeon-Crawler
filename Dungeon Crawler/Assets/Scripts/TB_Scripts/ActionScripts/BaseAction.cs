using UnityEngine;

public class BaseAction
{
    public string actionName;

    public string desc;

    public BaseAction(string actionName, string desc)
    {
        this.actionName = actionName;
        this.desc = desc;
    }

    public virtual void Execute(BaseChar user, BaseChar target)
    {
        Debug.Log(user.name + " -> " + target.name);
    }
}
