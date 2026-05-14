using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    //[SerializeField] private GameObject cutSceneController;

    [SerializeField] private GameObject[] players;

    [SerializeField] private GameObject[] lightCityToActive;
    [SerializeField] private GameObject[] greenCityToActive;
    [SerializeField] private GameObject[] darkSeaToActive;

    [SerializeField] private CinemachineVirtualCamera[] allVirtualCameras;
    [SerializeField] private CinemachineVirtualCamera[] allCGVirtualCameras;

    private PlayerAInput playerA;
    private PlayerBInput playerB;

    [Header("Control CGCamera")]
    [SerializeField] private float cgCameraExistTime = 0.35f;

    [Header("Controls for lerping the Y Damping during player jump/fall")]
    [SerializeField] private float fallPanAmount = 0.25f;
    [SerializeField] private float fallYPanTime = 0.35f;
    public float fallSpeedYDampingChangeThreshold = -15f;

    public bool IsLerpingYDamping { get; private set; }
    public bool LerpedFromPlayerFalling { get;set; }

    private Coroutine lerpYPanCoroutine;
    private Coroutine panCameraCoroutine;

    private CinemachineVirtualCamera currentVirtualCamera;
    private CinemachineFramingTransposer framingTransposer;

    private float normYPanAmount;

    private Vector2 startingTrackedObjectsOffset;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        playerA = players[0].GetComponent<PlayerAInput>();
        playerB = players[1].GetComponent<PlayerBInput>();

        StartCGCamera();

        //cutSceneController.SetActive(true);

        for (int i=0;i< players.Length; ++i)
        {
            players[i].SetActive(true);
        }

        allVirtualCameras[0].enabled = true;
        //cutSceneController.SetActive(false);

        for (int i = 0; i < allVirtualCameras.Length; i++)
        {
            if (allVirtualCameras[i].enabled)
            {
                currentVirtualCamera = allVirtualCameras[i];

                framingTransposer = currentVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            }
        }

        normYPanAmount = framingTransposer.m_YDamping;

        startingTrackedObjectsOffset = framingTransposer.m_TrackedObjectOffset;
    }

    #region Lerp The Y Damping
    public void LerpYDamping(bool isPlayerFalling)
    {
        lerpYPanCoroutine = StartCoroutine(LerpYAction(isPlayerFalling));
    }

    IEnumerator LerpYAction(bool isPlayerFalling)
    {
        IsLerpingYDamping = true;

        float startDampAmount = framingTransposer.m_YDamping;
        float endDampAmount = 0f;

        if (isPlayerFalling)
        {
            endDampAmount = fallPanAmount;
            LerpedFromPlayerFalling = true;
        }
        else
        {
            endDampAmount = normYPanAmount;
        }
        float elasepdTime = 0f;
        while (elasepdTime < fallYPanTime)
        {
            elasepdTime += Time.deltaTime;

            float lerpedPanAmount = Mathf.Lerp(startDampAmount, endDampAmount, (elasepdTime / fallYPanTime));
            framingTransposer.m_YDamping = lerpedPanAmount;

            yield return null;
        }


        IsLerpingYDamping = false;
    }
    #endregion

    #region Pan Camera
    public void PanCameraOnContact(float panDistance,float panTime, PanDirection panDirection,bool panToStartingPos)
    {
        panCameraCoroutine = StartCoroutine(PanCamera(panDistance, panTime, panDirection, panToStartingPos));
    }

    IEnumerator PanCamera(float panDistance, float panTime, PanDirection panDirection, bool panToStartingPos)
    {
        Vector2 endPos = Vector2.zero;
        Vector2 startingPos = Vector2.zero;

        if (!panToStartingPos)
        {
            switch (panDirection)
            {
                case PanDirection.Up:
                    endPos = Vector2.up;
                    break;
                case PanDirection.Down:
                    endPos = Vector2.down;
                    break;
                case PanDirection.Left:
                    endPos = Vector2.left;
                    break;
                case PanDirection.Right:
                    endPos = Vector2.right;
                    break;
            }

            endPos *= panDistance;

            startingPos = startingTrackedObjectsOffset;

            endPos += startingPos;
        }
        else
        {
            startingPos = framingTransposer.m_TrackedObjectOffset;
            endPos = startingTrackedObjectsOffset;
        }

        float elapsedTime = 0f;
        while (elapsedTime < panTime)
        {
            elapsedTime += Time.deltaTime;

            Vector3 panLerp = Vector3.Lerp(startingPos, endPos, (elapsedTime / panTime));
            framingTransposer.m_TrackedObjectOffset = panLerp;

            yield return null;
        }
    }
    #endregion

    #region Swap Cameras
    public void SwapCamera(CinemachineVirtualCamera cameraFromLeft,CinemachineVirtualCamera cameraFromRight,Vector2 triggerExitDirection)
    {
        if(currentVirtualCamera == cameraFromLeft && triggerExitDirection.x > 0f)
        {
            cameraFromRight.enabled = true;

            cameraFromLeft.enabled = false;

            currentVirtualCamera = cameraFromRight;

            framingTransposer = currentVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        }
        else if(currentVirtualCamera == cameraFromRight && triggerExitDirection.x < 0f)
        {
            cameraFromLeft.enabled = true;

            cameraFromRight.enabled = false;

            currentVirtualCamera = cameraFromLeft;

            framingTransposer = currentVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        }
    }
    #endregion

    #region Start CGCamera
    private void StartCGCamera()
    {
        StartCoroutine(CGCameraControlCoroutine());
    }

    IEnumerator CGCameraControlCoroutine()
    {
        playerA.canInput = false;
        playerB.canInput = false;

        for (int i = 0; i < allCGVirtualCameras.Length; ++i)
        {
            allCGVirtualCameras[i].enabled = true;
            currentVirtualCamera = allCGVirtualCameras[i];

            switch(i)
            {
                case 0:
                    for (int j = 0; j < lightCityToActive.Length; ++j)
                    {
                        lightCityToActive[j].SetActive(true);
                    }
                    break;
                case 1:
                    for (int j = 0; j < greenCityToActive.Length; ++j)
                    {
                        greenCityToActive[j].SetActive(true);
                    }
                    break;
                case 2:
                    for (int j = 0; j < darkSeaToActive.Length; ++j)
                    {
                        darkSeaToActive[j].SetActive(true);
                    }
                    break;
            }

            yield return new WaitForSeconds(cgCameraExistTime);

            allCGVirtualCameras[i].enabled = false;

            switch (i)
            {
                case 0:
                    for (int j = 0; j < lightCityToActive.Length; ++j)
                    {
                        lightCityToActive[j].SetActive(false);
                    }
                    break;
                case 1:
                    for (int j = 0; j < greenCityToActive.Length; ++j)
                    {
                        greenCityToActive[j].SetActive(false);
                    }
                    break;
                case 2:
                    for (int j = 0; j < darkSeaToActive.Length; ++j)
                    {
                        darkSeaToActive[j].SetActive(false);
                    }
                    break;
            }
        }

        playerA.canInput = true;
        playerB.canInput = true;
    }
    #endregion
}
