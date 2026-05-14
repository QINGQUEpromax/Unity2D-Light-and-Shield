using UnityEngine;
using Cinemachine;

public class CameraControlTrigger : MonoBehaviour
{
    public CustomInspectorObjects customInspectorObjects;

    private Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerA"))
        {
            if (customInspectorObjects.panCameraOnContact)
            {
                CameraManager.instance.PanCameraOnContact(customInspectorObjects.panDistance, customInspectorObjects.panTime,customInspectorObjects.panDirection,false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Vector2 exitDirection = (collision.transform.position - coll.bounds.center).normalized;

        if (customInspectorObjects.swapCameras && customInspectorObjects.cameraOnLeft != null && customInspectorObjects.cameraOnRight != null)
        {
            CameraManager.instance.SwapCamera(customInspectorObjects.cameraOnLeft, customInspectorObjects.cameraOnRight, exitDirection);
        }

        if (collision.CompareTag("PlayerA"))
        {
            if (customInspectorObjects.panCameraOnContact)
            {
                CameraManager.instance.PanCameraOnContact(customInspectorObjects.panDistance, customInspectorObjects.panTime, customInspectorObjects.panDirection, true);
            }
        }
    }
}

[System.Serializable]
public class CustomInspectorObjects
{
    public bool swapCameras = false;
    public bool panCameraOnContact = false;

    [HideInInspector] public CinemachineVirtualCamera cameraOnLeft;
    [HideInInspector] public CinemachineVirtualCamera cameraOnRight;

    [HideInInspector] public PanDirection panDirection;
    [HideInInspector] public float panDistance = 3f;
    [HideInInspector] public float panTime = 0.35f;
}

public enum PanDirection
{
    Up,
    Down,
    Left,
    Right,
}