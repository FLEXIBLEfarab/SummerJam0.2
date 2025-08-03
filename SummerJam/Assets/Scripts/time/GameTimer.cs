using UnityEngine;
using TMPro; // для TextMeshPro

public class GameTimer : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text timerText;       // Перетащи сюда TimerText
    public TMP_Text gameOverText;    // Перетащи сюда GameOverText

    [Header("Timer Settings")]
    public float startTime = 60f;    // Стартовое время

    private float currentTime;
    private bool isRed = false;
    private float blinkInterval = 0.5f;
    private float blinkTimer = 0f;
    private bool isGameOver = false;

    void OnEnable()
    {
        // Сбрасываем таймер при активации объекта
        currentTime = startTime;
        timerText.color = Color.white;
        gameOverText.gameObject.SetActive(false);
        isGameOver = false;
    }

    void Update()
    {
        if (isGameOver) return;

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timerText.text = Mathf.Ceil(currentTime).ToString();

            // Мигаем при <10 сек
            if (currentTime <= 10f)
            {
                blinkTimer += Time.deltaTime;
                if (blinkTimer >= blinkInterval)
                {
                    isRed = !isRed;
                    timerText.color = isRed ? Color.red : Color.white;
                    blinkTimer = 0f;
                }
            }
        }
        else
        {
            currentTime = 0;
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        timerText.text = "0";
        timerText.color = Color.red;
        gameOverText.gameObject.SetActive(true);
    }
}