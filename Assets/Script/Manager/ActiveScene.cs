using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class ActiveScene : MonoBehaviour
{
    [Header("Cinemachine ���������")]
    public CinemachineVirtualCamera targetVCam;

    [Header("BoxCollider")]
    public GameObject boxCollider;

    [Header("StartPoint")]
    public bool canTransit = true;
    public GameObject startPoint;

    [Header("Area")]
    public GameObject lastCameraArea;
    public GameObject lastSceneArea;
    public GameObject currentSceneArea;

    [Header("Scene")]
    public GameObject[] unactiveScene;
    public GameObject[] activeScene;

    [Header("DestroyTime")]
    public float destroyTime = 0.1f;

    PlayerAInput playerA;
    PlayerBInput playerB;

    private void OnEnable()
    {
        playerA=FindAnyObjectByType<PlayerAInput>();
        playerB=FindAnyObjectByType<PlayerBInput>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
        {
            for (int i = 0; i < unactiveScene.Length; i++)
            {
                if (unactiveScene[i] != null)
                {
                    unactiveScene[i].SetActive(false);
                }
            }

            for (int i = 0; i < activeScene.Length; i++)
            {
                if (activeScene[i] != null) activeScene[i].SetActive(true);
            }

            if (boxCollider != null) boxCollider.SetActive(true);
            if (lastSceneArea != null) lastSceneArea.SetActive(false);
            if (lastCameraArea != null) lastCameraArea.SetActive(false);
            if (currentSceneArea != null) currentSceneArea.SetActive(true);

            if (startPoint != null)
            {
                playerA.gameObject.GetComponent<PlayerController>().spawnPoint = startPoint;
                playerB.gameObject.GetComponent<PlayerController>().spawnPoint = startPoint;

                if (canTransit)
                {
                    playerB.transform.position = startPoint.transform.position;
                    playerA.transform.position = startPoint.transform.position;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            if(targetVCam != null) targetVCam.Priority = 10;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(targetVCam != null)
        {
            Gizmos.color = Color.green;
        
            float orthoSize = targetVCam.m_Lens.OrthographicSize;
            float aspect = targetVCam.m_Lens.Aspect;

            float height = orthoSize * 2;
            float width = height * aspect;

            Gizmos.DrawWireCube(targetVCam.transform.position, new Vector3(width, height, 1));
        }
    }
}
