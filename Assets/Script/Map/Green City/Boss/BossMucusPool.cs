using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMucusPool : MonoBehaviour
{
    public float mucusSpawnCooldown = 2f;
    public float mucusSpeed = 2f;

    public GameObject spawnPosition1;
    public GameObject spawnPosition2;

    protected List<GameObject> spawn1List = new List<GameObject>();
    protected List<GameObject> spawn2List = new List<GameObject>();

    public GameObject spawnPrefeb;

    public int spawnCount = 3;//一边生成的数量
    public float spawnInternal = 1f;
    public float destroyInternal = 100f;

    private void OnEnable()
    {
        FillPool();
    }

    private void Update()
    {
        Spawn();
    }

    protected virtual void FillPool()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            var newMucus = Instantiate(spawnPrefeb, spawnPosition1.transform.position, Quaternion.identity);

            var mucusToPlayerA = newMucus.GetComponent<GreenMucus>();
            mucusToPlayerA.ChaseToPlayerA();
            newMucus.transform.SetParent(spawnPosition1.transform);
            ReturnPool(newMucus,spawn1List);
        }
        for (int i = 0; i < spawnCount; i++)
        {
            var newMucus = Instantiate(spawnPrefeb, spawnPosition2.transform.position, Quaternion.identity);

            var mucusToPlayerB = newMucus.GetComponent<GreenMucus>();
            mucusToPlayerB.ChaseToPlayerB();
            newMucus.transform.SetParent(spawnPosition2.transform);
            ReturnPool(newMucus,spawn2List);
        }
    }

    protected void ReturnPool(GameObject gameobject,List<GameObject> list)
    {
        gameobject.SetActive(false);
        list.Add(gameobject);
    }

    public void Spawn()
    {
        if (CheckIfUnActive())
        {
            StartCoroutine(nameof(SpawnCoroutine));
            StartCoroutine(nameof(ReturnSpawnCoroutine));
        }
    }

    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(spawnInternal);
        for (int i = 0; i < spawnCount; ++i)
        {
            var mucus1 = spawn1List[i];
            var mucus2 = spawn2List[i];

            mucus1.transform.position = spawnPosition1.transform.position;
            mucus1.SetActive(true);

            mucus2.transform.position = spawnPosition2.transform.position;
            mucus2.SetActive(true);

            yield return new WaitForSeconds(mucusSpawnCooldown);
        }
    }

    IEnumerator ReturnSpawnCoroutine()
    {
        yield return new WaitForSeconds(destroyInternal);
        for(int i=0;i<spawnCount; ++i)
        {
            var mucus1 = spawn1List[i];
            var mucus2 = spawn2List[i];

            mucus1.SetActive(false);
            mucus2.SetActive(false);

            yield return new WaitForSeconds(destroyInternal);
        }
    }

    bool CheckIfUnActive()
    {
        for (int i = 0; i < spawnCount; ++i)
        {
            var mucus1 = spawn1List[i];
            var mucus2 = spawn2List[i];

            if (mucus1.activeSelf || mucus2.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
}
