using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [Header("��������")]
    public int maxHP = 100;
    public int currentHP;

    [Header("������ ��������")]
    public int damagePerTick = 1;    // ������� HP ������ �� ���� ���
    public float damageInterval = 5f; // �������� ����� � ��������
    private float damageTimer;

    [Header("UI")]
    public TextMeshProUGUI hpText;  // ����� HP
    public Image hpBar;             // ������� HP (Image � Fill)

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
    /// ����������� ���������� �������� ��� � �������� ��������.
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
    /// ������� ���� ������.
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
    /// ����� ������ (������������ ���������).
    /// </summary>
    public void Heal(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPUI();
    }

    /// <summary>
    /// ��������� UI (����� � ������� HP).
    /// </summary>
    void UpdateHPUI()
    {
        if (hpText != null)
            hpText.text = "HP: " + currentHP;

        if (hpBar != null)
            hpBar.fillAmount = (float)currentHP / maxHP;
    }

    /// <summary>
    /// ������ ������.
    /// </summary>
    void Die()
    {
        Debug.Log("����� ����!");
        // ����� ����� �������� ������� ����� ��� ����� ������.
    }
}

