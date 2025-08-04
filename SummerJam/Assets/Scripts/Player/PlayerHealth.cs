using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [Header("Здоровье")]
    public int maxHP = 100;
    public int currentHP;

    [Header("Потеря здоровья")]
    public int damagePerTick = 1;    // Сколько HP уходит за один тик
    public float damageInterval = 5f; // Интервал урона в секундах
    private float damageTimer;

    [Header("UI")]
    public TextMeshProUGUI hpText;  // Текст HP
    public Image hpBar;             // Полоска HP (Image с Fill)

    void Start()
    {
        currentHP = maxHP;
        UpdateHPUI();
    }

    void Update()
    {
        DamageOverTime();
    }

    /// <summary>
    /// Постепенное уменьшение здоровья раз в заданный интервал.
    /// </summary>
    void DamageOverTime()
    {
        damageTimer += Time.deltaTime;
        if (damageTimer >= damageInterval)
        {
            TakeDamage(damagePerTick);
            damageTimer = 0f;
        }
    }

    /// <summary>
    /// Наносит урон игроку.
    /// </summary>
    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPUI();

        if (currentHP <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Лечит игрока (используется деревьями).
    /// </summary>
    public void Heal(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPUI();
    }

    /// <summary>
    /// Обновляет UI (текст и полоску HP).
    /// </summary>
    void UpdateHPUI()
    {
        if (hpText != null)
            hpText.text = "HP: " + currentHP;

        if (hpBar != null)
            hpBar.fillAmount = (float)currentHP / maxHP;
    }

    /// <summary>
    /// Смерть игрока.
    /// </summary>
    void Die()
    {
        Debug.Log("Игрок умер!");
        // Здесь можно добавить рестарт сцены или экран смерти.
    }
}

