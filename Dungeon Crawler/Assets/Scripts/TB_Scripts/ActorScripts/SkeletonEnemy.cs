using UnityEngine;

public class SkeletonEnemy : BaseChar
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialize();
    }

    public void initialize()
    {
        charName = "Skeleton";
        mind = 3;
        body = 3;
        speed = 3;
        level = 1;
        baseHP = 50;
        currHP = baseHP;
        baseMP = 10;
        currMP = baseMP;
        status = "wait";

        actions.Add(ActionDatabase.basicBash);
        actions.Add(ActionDatabase.hotBreath);
        actions.Add(ActionDatabase.coldTouch);
    }
}
