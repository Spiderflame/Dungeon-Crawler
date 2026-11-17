using JetBrains.Annotations;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public BaseChar target;
    public BattleStateMachine BSM;
    public BaseChar enemy;

    public enum EnemyPhase
    {
        PLANNING,
        DONE,
        EXECUTE,
        END
    }

    public EnemyPhase currentPhase;

    void Update()
    {
        if(BSM.battleState == BattleStateMachine.BattleStates.ENEMY){
            switch (currentPhase)
            {
                case(EnemyPhase.PLANNING):
                    ChooseAction();
                    currentPhase = EnemyPhase.END;
                break;
                case(EnemyPhase.EXECUTE):

                break;
            }
            
        }
    }

    void ChooseAction()
    {
        target = BSM.heroList[Random.Range(0, BSM.heroList.Count)];//Need to distinguish between buffs and attacks
        
        int num = Random.Range(0, enemy.actions.Count);
        BaseAction currAction = enemy.actions[num];
        Debug.Log(enemy.charName + " has choosen " + currAction.actionName + " on " + target.charName);
    }
}
