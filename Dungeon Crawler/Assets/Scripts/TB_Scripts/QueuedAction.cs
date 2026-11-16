using UnityEngine;

[System.Serializable]
public class QueuedAction
{
    public BaseChar user;
    public BaseAttack attack;
    public BaseChar target;

    public QueuedAction(BaseChar user, BaseAttack attack, BaseChar target)
    {
        this.user = user;
        this.attack = attack;
        this.target = target;
    }
}