using UnityEngine;
using TMPro;

public class MessageUI : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public CanvasGroup canvasGroup;
    public float displayTime = 2f; // ����� ������ ������
    public float clearDelay = 5f;  // ����� ������� ������ ����� ���������

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
                messageText.text = ""; // ������� ������
            }
        }
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        canvasGroup.alpha = 1f;
        timer = displayTime;     // ����� ��������� ������ (������������)
        clearTimer = clearDelay; // ������ ������� ������
        isShowing = true;
    }

    private void HideMessage()
    {
        canvasGroup.alpha = 0f; // ������������ = 0 (���������)
        isShowing = false;
    }
}
