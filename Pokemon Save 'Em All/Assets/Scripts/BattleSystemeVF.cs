using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

namespace YourNamespace
{

    public class BattleDialogue : MonoBehaviour
    {
        public TMP_Text dialogueText;

        public void setDialogueText(string text)
        {
            dialogueText.text = text;
        }
    }
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

    public class BattleSystemeVF : MonoBehaviour
    {
        public BattleState state;
        public GameObject playerPrefab;
        public GameObject enemyPrefab;
        public Transform playerBattleStation;
        public Transform enemyBattleStation;

        public TMP_Text dialogueText; // Use TMP_Text instead of Text
        Unit playerUnit;
        Unit enemyUnit;

        public BattleHUD playerHUD;
        public BattleHUD enemyHUD;


        // Start is called before the first frame update
        void Start()
        {
            state = BattleState.START;
            SetupBattle();
        }

        void SetupBattle()
        {
            GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
            playerUnit = playerGO.GetComponent<Unit>();
            GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
            enemyUnit = enemyGO.GetComponent<Unit>();

            dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";

            playerHUD.SetHUD(playerUnit);
            enemyHUD.SetHUD(enemyUnit);

            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

        void PlayerTurn()
        {
            dialogueText.text = "Choose an action:";
        }

        IEnumerator PlayerAttack()
        {
            bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

            dialogueText.text = "The attack is successful!";

            yield return new WaitForSeconds(2f);

            if (isDead)
            {
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
        }

        IEnumerator EnemyTurn()
        {
            dialogueText.text = enemyUnit.unitName + " attacks!";

            yield return new WaitForSeconds(1f);

            bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

            yield return new WaitForSeconds(1f);

            if (isDead)
            {
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                state = BattleState.PLAYERTURN;
                PlayerTurn();
            }
        }

        void EndBattle()
        {
            if (state == BattleState.WON)
            {
                dialogueText.text = "You won the battle!";
            }
            else if (state == BattleState.LOST)
            {
                dialogueText.text = "You were defeated.";
            }
        }

        public void OnAttackButton()
        {
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(PlayerAttack());
        }
    }
}