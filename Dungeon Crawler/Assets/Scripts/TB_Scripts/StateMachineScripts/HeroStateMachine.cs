using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class HeroStateMachine : MonoBehaviour
{
    //Lists of Heros and Enemies
    public BattleStateMachine BSM;

    public BaseChar hero;

    public int heroIndex;

    public enum HeroPhase
    {
        PLANNING,
        DONE,
        EXECUTE,
        END
    }

    public HeroPhase currentPhase;

    public GameObject enemyGameObject;

    //
    public GameObject nameplatePrefab;
    public Transform nameplateParent;
    public List<PlayerNameplate> playerNameplates = new List<PlayerNameplate>();
    public List<QueuedAction> queuedActionList = new List<QueuedAction>();

    void Start()
    {
        heroIndex = 0;
        currentPhase = HeroPhase.PLANNING;
        for(int i = 0; i < BSM.heroList.Count; i++)
        {
            createNameplate(getHeroNamePlate(i));
        }
    }

    void Update()
    {
        switch (currentPhase)
        {
            case(HeroPhase.PLANNING):
                
            break;
            case(HeroPhase.DONE):
                heroTurn();
            break;
            case(HeroPhase.EXECUTE):
                //TODO: Remove Buttons
                queuedActionList.Sort((a, b) => a.user.speed.CompareTo(b.user.speed));
                queuedActionList.Reverse();
                while (queuedActionList.Count > 0)
                {
                    Debug.Log(queuedActionList[0].user.charName + "'s speed: " + queuedActionList[0].user.speed);
                    damageAction(queuedActionList[0].user, queuedActionList[0].attack, queuedActionList[0].target);
                    queuedActionList.RemoveAt(0);
                }
                currentPhase = HeroPhase.END;
                Debug.Log(currentPhase);
            break;
            case(HeroPhase.END):
                
            break;
        }
    }
    
    public void heroTurn()
    {   
        //list of heros
        //each time you go to
        if (heroIndex >= BSM.heroList.Count)
        {
            //Excute Hero actions
            //Then go to enemy turn or win/lose
            currentPhase = HeroPhase.EXECUTE;
            Debug.Log("Out of list");

        } else
        {
            //Activate Hero actions
            
            //after hero action set current phase to HeroPhase.DONE
            //currentPhase = HeroPhase.DONE;
            hero = BSM.heroList[heroIndex];
            Debug.Log(hero.charName + "'s turn!");
        }
    }

    public void attackButton()
    {
        Debug.Log("Attack Button");
        BaseAttack attack = new BaseAttack("Normal Attack", BaseAttack.DamageType.PHYS, 1f);
        BaseChar enemy = enemyGameObject.GetComponent<BaseChar>();
        
        //Adds basic attack to action queue which will run when all charcters have acted
        AddActionQueue(hero, attack, enemy, "ATTACK");

        //float damage = attack.CalculatePhysAttackDamage(hero, enemy);
        //Debug.Log(damage);
        //enemy.takeDamage(damage);
        //Debug.Log(enemy.currHP);
    }

    public void damageAction(BaseChar H, BaseAttack A, BaseChar T)
    {
        float damage = A.CalculatePhysAttackDamage(H, T);
        Debug.Log("Damage: " + damage);
        T.takeDamage(damage);
        Debug.Log("Target HP Left: " + T.currHP);
    }

    public void createNameplate(string newText)
    {
        GameObject newNameplate = Instantiate(nameplatePrefab, nameplateParent);

        TextMeshProUGUI text = newNameplate.GetComponent<TextMeshProUGUI>();
        text.text = newText;

        PlayerNameplate plate = new PlayerNameplate();
        plate.hero = this;
        plate.nameplate = text;

        playerNameplates.Add(plate);
    }

    public void updateNameplate()
    {
        playerNameplates[heroIndex].nameplate.text = getHeroNamePlate(heroIndex);
    }

    public string getHeroNamePlate(int x)
    {
        //<mspace=18px>1-CARSON*********-*99/*99-***-STATUS</mspace>
        string NAME = (BSM.heroList[x].charName.PadRight(15)).ToString();
        string C_HP = (BSM.heroList[x].currHP.ToString().PadLeft(3));
        string M_HP = (BSM.heroList[x].baseHP.ToString().PadLeft(3));
        string C_MP = (BSM.heroList[x].currMP.ToString()).PadLeft(3);
        string M_MP = BSM.heroList[x].status.ToString().PadLeft(6);
        string result = $"<mspace=18px>{x + 1}-{NAME}-{C_HP}/{M_HP}-{C_MP}-{M_MP}</mspace>";
        //text.text = $"<mspace=18px>{result}</mspace>";
        return result;
    }

    //Adds the target of the action, what the action is, the hero state machine, and a string to store for the status
    public void AddActionQueue(BaseChar H, BaseAttack A, BaseChar T, string S)
    {
        queuedActionList.Add(new QueuedAction(H, A, T));
        H.status = S;
        updateNameplate();
        heroIndex++;
        heroTurn();
    }
}
