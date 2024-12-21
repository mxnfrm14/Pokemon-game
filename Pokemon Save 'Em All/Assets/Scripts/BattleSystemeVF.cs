using System.Collections;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace
using UnityEngine.SceneManagement; // Import SceneManagement namespace

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
        UnitEnnemy enemyUnit;

        public BattleHUD playerHUD;
        public BattleHUD enemyHUD;
        public TMP_Text HPText_Player;
        public TMP_Text HPText_Enemy;

        // Start is called before the first frame update
        void Start()
        {
            state = BattleState.START;
            SetupBattle();
        }

    void SetupBattle()
    {
        Debug.Log("SetupBattle");

        // Reuse the persistent player object
        if (playerHealth.Instance != null)
        {
            GameObject playerGO = playerHealth.Instance.gameObject;
            GameObject playerGO2 = Instantiate(playerPrefab, playerBattleStation);

            // Position the persistent player object in the battle scene
            playerGO.transform.position = playerBattleStation.position;
            playerGO.transform.rotation = Quaternion.identity;

            // Fetch the Unit component and sync health values
            playerUnit = playerGO.GetComponent<Unit>();
            playerUnit.currentHP = (int)playerHealth.Instance.health;
            playerUnit.maxHP = (int)playerHealth.Instance.maxHealth;
        }
        else
        {
            Debug.LogError("PlayerHealth instance not found!");
            return;
        }

        // Instantiate the enemy
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<UnitEnnemy>();

        // Initialize UI
        dialogueText.text = "Un " + enemyUnit.unitNameE + " sauvage approche...";
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD2(enemyUnit);
        UpdateHUD();

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void UpdateHUD()
    {
        HPText_Enemy.text = "HP " + enemyUnit.currentHPE + "/" + enemyUnit.maxHPE;
        HPText_Player.text = "HP " + playerUnit.currentHP + "/" + playerUnit.maxHP;
    }

        void PlayerTurn()
        {
            dialogueText.text = "Que faire ?...";
        }

        IEnumerator PlayerAttack()
        {
            bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

            dialogueText.text = "L'attaque de " + playerUnit.unitName + " a touché " + enemyUnit.unitNameE + " !";
            enemyHUD.SetHP(enemyUnit.currentHPE);
            HPText_Enemy.text = "HP " + enemyUnit.currentHPE + "/" + enemyUnit.maxHPE;

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
            dialogueText.text = enemyUnit.unitNameE + " attaque!";

            yield return new WaitForSeconds(1f);

            bool isDead = playerUnit.TakeDamage(enemyUnit.damageE);
            playerHUD.SetHP(playerUnit.currentHP);
            HPText_Player.text = "HP " + playerUnit.currentHP + "/" + playerUnit.maxHP;

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
                dialogueText.text = "Vous avez gagné!";
                // Optionally, destroy the enemy game object
                if (enemyUnit != null)
                {
                    Destroy(enemyUnit.gameObject);
                }
            }
            else if (state == BattleState.LOST)
            {
                dialogueText.text = "Vous avez perdu...";
            }

            // Update playerHealth's HP with playerUnit's HP
            if (playerHealth.Instance != null && playerUnit != null)
            {
                playerHealth.Instance.UpdateHealth(playerUnit.GetCurrentHP());
            }

            // Load the previous scene after a short delay
            StartCoroutine(ReturnToPreviousScene());
        }

        IEnumerator ReturnToPreviousScene()
        {
            yield return new WaitForSeconds(2f); // Wait for 2 seconds before returning to the previous scene
            if (state == BattleState.WON)
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
            else
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex - 1);
            }
        }

        public void OnAttackButton()
        {
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(PlayerAttack());
        }

        public void OnFleeButtonClick()
        {
            // Update playerHealth's HP with playerUnit's HP before fleeing
            if (playerHealth.Instance != null && playerUnit != null)
            {
                playerHealth.Instance.UpdateHealth(playerUnit.GetCurrentHP());
            }

            // Charger le niveau 1
            SceneManager.LoadScene("Numero1");
        }
    }
}