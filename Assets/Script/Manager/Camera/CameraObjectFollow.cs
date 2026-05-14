using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObjectFollow : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerTransform;

    [Header("Flip Rotation Stats")]
    [SerializeField] private float flipYRotationTime = 0.5f;

    private Coroutine turnCoroutine;

    private PlayerController player;

    private bool isFacingRight;

    private void Awake()
    {
        player = playerTransform.GetComponent<PlayerController>();

        isFacingRight = player.IsFacingRight;
    }

    private void Start()
    {
        transform.position = playerTransform.position;
    }

    private void Update()
    {
        transform.position = playerTransform.position;
    }

    public void CallTurn()
    {
        turnCoroutine = StartCoroutine(nameof(FlipYLerp));
    }

    IEnumerator FlipYLerp()
    {
        float startRotation = transform.localEulerAngles.y;
        float endRotationAmount = DeterminationEndRotation();
        float yRotation = 0f;

        float elapsedTime = 0f;
        
        while(elapsedTime < flipYRotationTime)
        {
            elapsedTime += Time.deltaTime;

            yRotation = Mathf.Lerp(startRotation,endRotationAmount,(elapsedTime/flipYRotationTime));
            transform.rotation = Quaternion.Euler(0f,yRotation,0f);

            yield return null;
        }

    }

    private float DeterminationEndRotation()
    {
        isFacingRight = !isFacingRight;

        if (isFacingRight)
        {
            return 180f;
        }
        else
        {
            return 0f;
        }

    }
}
