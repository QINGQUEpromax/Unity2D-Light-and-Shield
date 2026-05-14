using UnityEngine;
using Cinemachine;

public class CameraZoneTrigger : MonoBehaviour
{
    [Header("Cinemachine 虚拟摄像机")]
    public CinemachineVirtualCamera targetVCam;

    [Header("进入区域时的优先级")]
    public int enterPriority = 20; // 高于默认优先级（通常为10）

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerA") || other.CompareTag("PlayerB"))
        {
            // 提高目标摄像机优先级，Cinemachine会自动切换
            targetVCam.Priority = enterPriority;
        }
    }
}