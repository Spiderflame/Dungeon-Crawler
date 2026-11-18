using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;
using TMPro;

public class BattleStateMachine : MonoBehaviour
{
    public enum BattleStates
    {
        HERO,
        ENEMY,
        WIN,
        LOSE
    }
    
    public BattleStates battleState;

    //Lists of Heros and Enemies
    public List<BaseChar> heroList = new List<BaseChar>();
    public List<BaseChar> enemyList = new List<BaseChar>();

    //
    public GameObject nameplatePrefab;
    public Transform nameplateParent;
    public List<PlayerNameplate> playerNameplates = new List<PlayerNameplate>();

    void Start()
    {
        //TODO: Change the battle start to allow for enemy ambush encounters
        battleState = BattleStates.HERO;

        //TODO: Add heros and enemies in battle to a list
        //
        

    }

    public void handle_states(BattleStates new_state)
    {
        battleState = new_state;
        
        switch (battleState)
        {
            case(BattleStates.HERO):
                //Hero turn
            break;
            case(BattleStates.ENEMY):
                //Enemy turn
                Debug.Log("Enemy Turn");
            break;
            case(BattleStates.WIN):
                //Win Screen
            break;
            case(BattleStates.LOSE):
                //Game Over
            break;
        }
    }

    public string getHeroNamePlate(int x)
    {
        //<mspace=18px>1-CARSON*********-*99/*99-***-STATUS</mspace>
        string NAME = heroList[x].charName.PadRight(15).ToString();
        string C_HP = heroList[x].currHP.ToString().PadLeft(3);
        string M_HP = heroList[x].baseHP.ToString().PadLeft(3);
        string C_MP = heroList[x].currMP.ToString().PadLeft(3);
        string St = heroList[x].status.ToString().PadLeft(6);
        string result = $"<mspace=50px>{x + 1} {NAME} {C_HP}/{M_HP} {C_MP} {St}</mspace>";
        //text.text = $"<mspace=18px>{result}</mspace>";
        return result;
    }

    public void updateNameplate()
    {
        for (int i = 0; i < heroList.Count; i++)
        {
            playerNameplates[i].nameplate.text = getHeroNamePlate(i);
        }
    }
}
