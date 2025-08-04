using UnityEngine;
using TMPro;

public class MessageUI : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public CanvasGroup canvasGroup;
    public float displayTime = 2f; // Время показа текста
    public float clearDelay = 5f;  // Через сколько секунд текст очищается

    private float timer = 0f;
    private bool isShowing = false;
    private float clearTimer = 0f;

    void Update()
    {
        if (isShowing)
        {
            timer -= Time.deltaTime;
            clearTimer -= Time.deltaTime;

            if (timer <= 0)
            {
                HideMessage();
            }

            if (clearTimer <= 0)
            {
                messageText.text = ""; // Очистка текста
            }
        }
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        canvasGroup.alpha = 1f;
        timer = displayTime;     // Время видимости текста (прозрачность)
        clearTimer = clearDelay; // Таймер очистки текста
        isShowing = true;
    }

    private void HideMessage()
    {
        canvasGroup.alpha = 0f; // Прозрачность = 0 (невидимый)
        isShowing = false;
    }
}
