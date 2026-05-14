using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scrollingText;
    [SerializeField] float scrollSpeed = 25f;
    [SerializeField] float accelerateFactor = 2.5f;
    [SerializeField] float showDuration = 5f;
    [SerializeField] float fadeInDuration = 1f;
    [SerializeField] float fadeOutDuration = 3f;
    [SerializeField,Range(0f,1000f)] float quitDistance = 1000f;
    [SerializeField] Image[] memoryCGs;

    private RectTransform textRect;
    private float contentHeight;
    private bool isFastForward;

    void Start()
    {
        textRect = scrollingText.GetComponent<RectTransform>();
        contentHeight = scrollingText.preferredHeight;
        StartCoroutine(ShowMemoryCGs());
    }

    void Update()
    {
        // ´¥Ãþ/Êó±ê»¬¶¯¼ì²â
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            isFastForward = true;
        }
        else
        {
            isFastForward = false;
        }

        float currentSpeed = isFastForward ? scrollSpeed * accelerateFactor : scrollSpeed;
        textRect.anchoredPosition += Vector2.up * currentSpeed * Time.deltaTime;

        // ½áÊøÅÐ¶Ï
        if (textRect.anchoredPosition.y > contentHeight + quitDistance)
        {
            QuitGame();
        }
    }

    System.Collections.IEnumerator ShowMemoryCGs()
    {
        foreach (Image cg in memoryCGs)
        {
            cg.gameObject.SetActive(true);
            cg.canvasRenderer.SetAlpha(0);

            cg.CrossFadeAlpha(1, fadeInDuration, false);
            yield return new WaitForSeconds(fadeInDuration);

            yield return new WaitForSeconds(showDuration);

            cg.CrossFadeAlpha(0, fadeOutDuration, false);
            yield return new WaitForSeconds(fadeOutDuration);
            cg.gameObject.SetActive(false);
        }
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
                Application.Quit();
    }
}