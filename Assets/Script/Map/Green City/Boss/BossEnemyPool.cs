using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyPool : BossMucusPool
{
    protected override void FillPool()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            var newEnemy = Instantiate(spawnPrefeb, spawnPosition1.transform.position, Quaternion.identity);

            var enemyToPlayerA = newEnemy.GetComponent<LittleEnemy>();
            enemyToPlayerA.ChaseToPlayerA();
            newEnemy.transform.SetParent(spawnPosition1.transform);
            ReturnPool(newEnemy, spawn1List);
        }
        for (int i = 0; i < spawnCount; i++)
        {
            var newEnemy = Instantiate(spawnPrefeb, spawnPosition2.transform.position, Quaternion.identity);

            var enemyToPlayerB = newEnemy.GetComponent<LittleEnemy>();
            enemyToPlayerB.ChaseToPlayerB();
            newEnemy.transform.SetParent(spawnPosition2.transform);
            ReturnPool(newEnemy, spawn2List);
        }
    }
}
