using Unity.VisualScripting;
using UnityEngine;

public static class ActionDatabase
{
    public static BaseAttack basicSlash = new BaseAttack("Normal Attack", "x slashes y", BaseAttack.DamageType.SLASH, 1f, 0);

    public static BaseAttack basicBash = new BaseAttack("Normal Attack", "x basehes y", BaseAttack.DamageType.BASH, 1f, 0);

    public static BaseAttack basicPierce = new BaseAttack("Normal Attack", "x piereces y", BaseAttack.DamageType.PIERCE, 1f, 0);
    
    public static BaseAttack hotBreath = new BaseAttack("Hot Breath", "x's breath burns y", BaseAttack.DamageType.FIRE, 1.5f, 15);

    public static BaseAttack coldTouch = new BaseAttack("Cold Touch", "x's cold touch freezes y", BaseAttack.DamageType.ICE, 1.5f, 15);
}
