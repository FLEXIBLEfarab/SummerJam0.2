using TMPro;
using UnityEngine;

public class IntroMessage : MonoBehaviour
{
    public TextMeshProUGUI introTextUI; // ������ �� ����� � Canvas
    public string introMessage = "�� ������ ������ ��������, ���� �� ������� ��� �������� ���� � ������!";
    public float displayTime = 5f; // ����� ������ (� ��������)

    void Start()
    {
        // ���������� ���������
        introTextUI.text = introMessage;

        // ����� displayTime ������ ������� �����
        Invoke(nameof(ClearMessage), displayTime);
    }

    void ClearMessage()
    {
        introTextUI.text = "";
    }

}
