using Unity.VisualScripting;
using UnityEngine;

public static class ActionDatabase
{
    public static BaseAttack basicSlash = new BaseAttack("Normal Attack", " slashes ", BaseAttack.DamageType.SLASH, 1f, 0);

    public static BaseAttack basicBash = new BaseAttack("Normal Attack", " basehes ", BaseAttack.DamageType.BASH, 1f, 0);

    public static BaseAttack basicPierce = new BaseAttack("Normal Attack", " piereces ", BaseAttack.DamageType.PIERCE, 1f, 0);
    
    public static BaseAttack hotBreath = new BaseAttack("Hot Breath", "'s breath burns ", BaseAttack.DamageType.FIRE, 1.5f, 15);

    public static BaseAttack coldTouch = new BaseAttack("Cold Touch", "'s cold touch freezes ", BaseAttack.DamageType.ICE, 1.5f, 15);
}
