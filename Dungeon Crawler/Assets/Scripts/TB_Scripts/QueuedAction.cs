using UnityEngine;

[System.Serializable]
public class QueuedAction
{
    public BaseAttack attack;
    public BaseChar target;

    public QueuedAction(BaseAttack attack, BaseChar target)
    {
        this.attack = attack;
        this.target = target;
    }
}