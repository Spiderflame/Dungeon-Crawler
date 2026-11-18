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
        START,
        PLANNING,
        DONE,
        EXECUTE,
        END
    }

    public HeroPhase currentPhase;

    public GameObject enemyGameObject;

    public GameObject ABPanel;


    void Start()
    {
        heroIndex = 0;
        currentPhase = HeroPhase.PLANNING;
        for(int i = 0; i < BSM.heroList.Count; i++)
        {
            createNameplate(BSM.getHeroNamePlate(i));
        }
    }

    void Update()
    {
        if(BSM.battleState == BattleStateMachine.BattleStates.HERO){
            switch (currentPhase)
            {
                case(HeroPhase.START):
                    heroIndex = 0;
                    hero = BSM.heroList[heroIndex];
                    foreach(BaseChar H in BSM.heroList)
                    {
                        H.status = "";
                    }
                    BSM.updateNameplate();
                    ABPanel.SetActive(true);
                    currentPhase = HeroPhase.PLANNING;
                break;
                case(HeroPhase.PLANNING):
                
                break;
                case(HeroPhase.DONE):
                    heroTurn();
                break;
                case(HeroPhase.EXECUTE):
                    ABPanel.SetActive(false);
                    //BSM.dialougeBoxBG.SetActive(true);

                    /*BSM.queuedActionList.Sort((a, b) => a.user.speed.CompareTo(b.user.speed));
                    BSM.queuedActionList.Reverse();
                    while (BSM.queuedActionList.Count > 0)
                    {
                        Debug.Log(BSM.queuedActionList[0].user.charName + "'s speed: " + BSM.queuedActionList[0].user.speed);
                        BSM.queuedActionList[0].action.Execute(BSM.queuedActionList[0].user, BSM.queuedActionList[0].target);
                        BSM.queuedActionList.RemoveAt(0);
                    }*/
                    BSM.StartCoroutine(BSM.ExecuteActions());
                    
                    currentPhase = HeroPhase.END;
                break;
                case(HeroPhase.END):
                    BSM.battleState = BattleStateMachine.BattleStates.ENEMY;
                    Debug.Log(currentPhase);
                    currentPhase = HeroPhase.START;
                break;
            }
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

    #region Buttons
    public void attackButton()
    {
        Debug.Log("Attack Button");
        
        BaseChar enemy = enemyGameObject.GetComponent<BaseChar>();
        
        //Adds basic attack to action queue which will run when all charcters have acted
        AddActionQueue(hero, hero.basicAttack, enemy, "ATTACK");
    }

    public void defendButton()
    {
        Debug.Log("Defend Button");
        
        //TODO: add defend functionality
        AddActionQueue(hero, null, hero, "DEFEND");
    }

    public void runButton()
    {
        Debug.Log("Run Button");
        
        //TODO: add run functionality
        AddActionQueue(hero, null, hero, "ESCAPE");
    }
    #endregion
    
    public void createNameplate(string newText)
    {
        GameObject newNameplate = Instantiate(BSM.nameplatePrefab, BSM.nameplateParent);

        TextMeshProUGUI text = newNameplate.GetComponent<TextMeshProUGUI>();
        text.text = newText;

        PlayerNameplate plate = new PlayerNameplate();
        plate.hero = this;
        plate.nameplate = text;

        BSM.playerNameplates.Add(plate);
    }


    //Adds the target of the action, what the action is, the hero state machine, and a string to store for the status
    public void AddActionQueue(BaseChar H, BaseAction A, BaseChar T, string S)
    {
        BSM.queuedActionList.Add(new QueuedAction(H, A, T));
        H.status = S;
        BSM.updateNameplate();
        heroIndex++;
        heroTurn();
    }
}
