using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;

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

}
