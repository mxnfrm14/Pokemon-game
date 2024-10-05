using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    
    public BattleState state;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
    }


    void SetupBattle()
    {
        Instantiate(playerPrefab, playerBattleStation);
        Instantiate(enemyPrefab, enemyBattleStation);
        state = BattleState.PLAYERTURN;
    }

}
