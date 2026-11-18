using System.Net;
using JetBrains.Annotations;
using NUnit.Framework;
using Unity.VectorGraphics;
using UnityEngine;

public class BaseAttack : BaseAction
{
    public enum DamageType
    {
        BASH,
        SLASH,
        PIERCE,
        FIRE,
        ICE
    }
    public DamageType damageType;
    public float potency; //1-normal, 1.5-light, 2-medium, 2.5-heavy, 3-massive

    public float cost;

    public BaseAttack(string actionName, string desc, DamageType damageType, float potency, float cost) :base(actionName, desc)
    {
        this.damageType = damageType;
        this.potency = potency;
        this.cost = cost;
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
                    - d.body / 1.5f * d.getBuffMultipler(d.defenseBuffStage))) 
                        * potency * d.getResistance(damageType);
        damageCalc = Mathf.Ceil(damageCalc * Random.Range(0.9f, 1.1f));
        if(damageCalc <= 0)
        {
            damageCalc = 1f;
        }
        return damageCalc;
    }

    //Calculates damage for a magic attack
    public float CalculateMagAttackDamage(BaseChar attacker, BaseChar defender)
    {   
        float damageCalc = 
            ((attacker.level + 
                (attacker.mind * attacker.getBuffMultipler(attacker.attackBuffStage) 
                    - defender.body / 1.5f * defender.getBuffMultipler(defender.defenseBuffStage))) 
                        * potency * defender.getResistance(damageType));
        damageCalc = Mathf.Ceil(damageCalc * Random.Range(0.8f, 1.2f));
        if(damageCalc <= 0)
        {
            damageCalc = 1f;
        }
        return damageCalc;
    }

    public override void Execute(BaseChar user, BaseChar target)
    {
        base.Execute(user, target);

        float damage = CalculatePhysAttackDamage(user, target);
        Debug.Log("Damage: " + damage);
        target.takeDamage(damage);
        Debug.Log("Target HP Left: " + target.currHP);
    }
}
