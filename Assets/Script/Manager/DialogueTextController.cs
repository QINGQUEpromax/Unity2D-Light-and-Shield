using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueTextController : MonoBehaviour
{
    [Header("剧情设置")]
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] string[] dialogueLines;
    [SerializeField] float fadeInDuration = 1f;
    [SerializeField] float displayDuration = 3f;
    [SerializeField] float fadeOutDuration = 1f;
    [SerializeField] float verticalOffset = 100f; 

    private CanvasGroup textCanvasGroup;
    private RectTransform textRect;

    void Start()
    {
        InitializeTextPosition();
        StartCoroutine(PlayDialogueSequence());
    }

    void InitializeTextPosition()
    {
        textRect = dialogueText.GetComponent<RectTransform>();
        textRect.anchoredPosition = new Vector2(0, verticalOffset);

        textCanvasGroup = dialogueText.gameObject.AddComponent<CanvasGroup>();
        textCanvasGroup.alpha = 0;
    }

    IEnumerator PlayDialogueSequence()
    {
        foreach (string line in dialogueLines)
        {
            dialogueText.text = line;

            // 淡入
            yield return StartCoroutine(FadeText(0, 1, fadeInDuration));

            // 保持显示
            yield return new WaitForSeconds(displayDuration);

            // 淡出
            yield return StartCoroutine(FadeText(1, 0, fadeOutDuration));
        }

        dialogueText.gameObject.SetActive(false);
    }

    IEnumerator FadeText(float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0;
        while (elapsed < duration)
        {
            textCanvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        textCanvasGroup.alpha = endAlpha;
    }
}