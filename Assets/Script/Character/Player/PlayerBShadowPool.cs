using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBShadowPool : MonoBehaviour
{
    public static PlayerBShadowPool Instance;

    public GameObject shadowPrefeb;

    public int shadowCount = 10;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;

        //初始化对象池
        FillPool();
    }

    public void FillPool()
    {
        for(int i = 0; i < shadowCount; ++i)
        {
            var newShadow = Instantiate(shadowPrefeb);
            newShadow.transform.SetParent(transform);

            //返回对象池
            ReturnPool(newShadow);
        }
    }

    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);

        availableObjects.Enqueue(gameObject);
    }

    public GameObject GetFromPool()
    {
        if( availableObjects.Count == 0)
        {
            FillPool();
        }

        var outShadow = availableObjects.Dequeue();

        outShadow.SetActive(true);

        return outShadow;
    }
}