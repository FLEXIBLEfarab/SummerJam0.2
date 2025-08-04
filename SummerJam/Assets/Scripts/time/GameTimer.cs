using UnityEngine;
using TMPro; // для TextMeshPro
using System;

public class GameTimer : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text timerText;       // Перетащи сюда TimerText
    public TMP_Text gameOverText;    // Перетащи сюда GameOverText

    [Header("Timer Settings")]
    public float startTime = 60f;    // Стартовое время
    public bool useMinutesFormat = false; // Отображать в формате ММ:СС

    private float _currentTime;
    private bool _isRed = false;
    private float _blinkInterval = 0.5f;
    private float _blinkTimer = 0f;
    private bool _isGameOver = false;
    private bool _hasMoved = false;
    private bool _isPaused = false;

    // События (опционально, если хотите подписываться в других скриптах)
    public event Action OnLowTime;
    public event Action OnGameOver;

    void OnEnable()
    {
        ResetTimer();
    }

    void Update()
    {
        if (_isGameOver || _isPaused) return;

        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            UpdateTimerDisplay();

            // Мигаем при <10 сек
            if (_currentTime <= 10f)
            {
                _blinkTimer += Time.deltaTime;
                if (_blinkTimer >= _blinkInterval)
                {
                    _isRed = !_isRed;
                    timerText.color = _isRed ? Color.red : Color.white;
                    _blinkTimer = 0f;
                }

                // Перемещаем объект только один раз
                if (_currentTime <= 10f && !_hasMoved)
                {
                    RectTransform rt = timerText.GetComponent<RectTransform>();
                    rt.anchoredPosition = new Vector2(90.9f, -27.89999f); // Новая позиция UI текста
                    _hasMoved = true;
                }

            }
        }
        else
        {
            _currentTime = 0;
            GameOver();
        }
    }

    void UpdateTimerDisplay()
    {
        if (useMinutesFormat)
        {
            int minutes = Mathf.FloorToInt(_currentTime / 60f);
            int seconds = Mathf.FloorToInt(_currentTime % 60f);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
        else
        {
            timerText.text = Mathf.Ceil(_currentTime).ToString();
        }
    }

    void GameOver()
    {
        _isGameOver = true;
        timerText.text = "0";
        timerText.color = Color.red;
        gameOverText.gameObject.SetActive(true);
        OnGameOver?.Invoke();
    }

    public void ResetTimer()
    {
        _currentTime = startTime;
        timerText.color = Color.white;
        gameOverText.gameObject.SetActive(false);
        _isGameOver = false;
        _isRed = false;
        _blinkTimer = 0f;
        _hasMoved = false;
        _isPaused = false;
        UpdateTimerDisplay();
    }

    public void PauseTimer()
    {
        _isPaused = true;
    }

    public void ResumeTimer()
    {
        _isPaused = false;
    }
}
