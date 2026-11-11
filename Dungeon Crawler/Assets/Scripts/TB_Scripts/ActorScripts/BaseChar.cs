using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class BaseChar : MonoBehaviour
{
    public string charName;
    
    //Total and current HP/MP
    public float baseHP;
    public float currHP;
    public float baseMP;
    public float currMP;

    //Charcter stats
    public float mind; //related to magic, healing, and crit chance
    public float body; //related to physical attacks and taking hits
    public float speed; //related to accuracy, evasion, turn order, and escape chance

    public float level;

    public string status = "STATUS";//only used for Heros

    // Buff stages
    public int attackBuffStage = 0;
    public int defenseBuffStage = 0;
    public int speedBuffStage = 0; //buffs accuracy, evasion, turn order, and escape chance

    //key ex: BaseAttack.DamageType.FIRE
    //Able to change an enemies damage resistances
    public Dictionary<BaseAttack.DamageType, float> resistances = new Dictionary<BaseAttack.DamageType, float>(){
        { BaseAttack.DamageType.PHYS, 1f},
        { BaseAttack.DamageType.FIRE, 1f},
        { BaseAttack.DamageType.ICE, 1f}
    };

    public List<BaseAttack> attacks = new List<BaseAttack>();

    public void takeDamage(float damageAmount)
    {
        currHP -= damageAmount;
    }

    public void heal(float healAmount)
    {
        currHP += healAmount;
    }

    public bool isDead()
    {
        return currHP <= 0;
    }

    public float getResistance(BaseAttack.DamageType element)
    {
        if (resistances.ContainsKey(element))
        {
            return resistances[element];
        }
        
        return 1f;
    }

    public float getBuffMultipler(int stage)
    {
        if(stage > 0f)
        {
            return (stage + 2f) / 2f;
        }
        else if(stage < 0f)
        {
            return 2f / (stage + 2f);
        }
        else
        {
            return 1f;
        }
        
    }

    
}
