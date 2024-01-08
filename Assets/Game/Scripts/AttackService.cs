using UnityEngine;

public class AttackService : MonoBehaviour
{
    public void attackEnemy(GameObject gameObject)
    {
        EnemyCharacter enemyCharacter = gameObject.GetComponent<EnemyCharacter>();
        enemyCharacter.Data.TakeDamage(10);
    }
    
    public void attackPlayer(GameObject gameObject)
    {
        MainCharacter enemyCharacter = gameObject.GetComponent<MainCharacter>();
        enemyCharacter.Data.TakeDamage(10);
    }
}