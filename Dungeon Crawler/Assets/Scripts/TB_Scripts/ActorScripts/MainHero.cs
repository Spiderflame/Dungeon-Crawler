using UnityEngine;

public class MainHero : BaseChar
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialize();
    }

    public void initialize()
    {
        charName = "Protag";
        mind = 1;
        body = 1;
        speed = 1;
        level = 1;
        baseHP = 50;
        currHP = baseHP;
        baseMP = 10;
        currMP = baseMP;

        basicAttack = ActionDatabase.basicBash;

        actions.Add(ActionDatabase.hotBreath);
        actions.Add(ActionDatabase.coldTouch);
    }
}
