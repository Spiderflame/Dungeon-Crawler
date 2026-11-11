using System.Net;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;

public class BaseAttack
{
    public string attackName;
    public enum DamageType
    {
        PHYS,
        FIRE,
        ICE
    }
    public DamageType damageType;
    public float potency; //1-normal, 1.5-light, 2-medium, 2.5-heavy, 3-massive

    public BaseAttack(string name, DamageType type, float power)
    {
        attackName = name;
        damageType = type;
        potency = power;
    }

    //Checks if an attack will hit (using player accuracy vs enemy evasion) if so returns true
    public bool attackHits()
    {
        
        return true;
    }

    //Calculates damage for a physical attack
    public float CalculatePhysAttackDamage(BaseChar a, BaseChar d)
    {   
        float damageCalc = 
            (a.level + 
                (a.body * a.getBuffMultipler(a.attackBuffStage) 
                    - d.body * d.getBuffMultipler(d.defenseBuffStage))) 
                        * potency * d.getResistance(damageType);
        damageCalc = Mathf.Ceil(damageCalc);
        return damageCalc;
    }

    //Calculates damage for a magic attack
    public float CalculateMagAttackDamage(BaseChar attacker, BaseChar defender)
    {   
        float damageCalc = 
            ((attacker.level + 
                (attacker.mind * attacker.getBuffMultipler(attacker.attackBuffStage) 
                    - defender.body * defender.getBuffMultipler(defender.defenseBuffStage))) 
                        * potency * defender.getResistance(damageType));
        damageCalc = Mathf.Ceil(damageCalc);
        return damageCalc;
    }
}
