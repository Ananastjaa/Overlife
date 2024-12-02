using UnityEngine;

public class EnemyDieScript : MonoBehaviour
{
    private EnemyManager enemyManagerScript;

    private void Start(){
        enemyManagerScript = GameObject.FindGameObjectWithTag("Environment").GetComponent<EnemyManager>();
    }

    public void EnemyDie() {
        enemyManagerScript.CurrentEnemyCounter--;
        if (enemyManagerScript.CurrentEnemyCounter < 0)
        {
            enemyManagerScript.CurrentEnemyCounter = 0; // Safety check
        }
        Destroy(gameObject);
        enemyManagerScript.StartCoroutine(enemyManagerScript.EnemySpawnRoutine());
    }
}
