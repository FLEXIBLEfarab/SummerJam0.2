using TMPro;
using UnityEngine;

public class IntroMessage : MonoBehaviour
{
    public TextMeshProUGUI introTextUI; // Ссылка на текст в Canvas
    public string introMessage = "Вы должны помочь деревьям, ведь вы созданы для симбиоза друг с другом!";
    public float displayTime = 5f; // Время показа (в секундах)

    void Start()
    {
        // Показываем сообщение
        introTextUI.text = introMessage;

        // Через displayTime секунд убираем текст
        Invoke(nameof(ClearMessage), displayTime);
    }

    void ClearMessage()
    {
        introTextUI.text = "";
    }

}
