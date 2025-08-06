using UnityEngine;

public class Tree : MonoBehaviour
{
    public bool isDead = true;
    public int healAmount = 20;

    public Mesh deadMesh;
    public Mesh aliveMesh;

    private MeshFilter meshFilter;
    private MessageUI messageUI;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = deadMesh;

        // Находим компонент MessageUI в сцене
        messageUI = FindObjectOfType<MessageUI>();
    }

    public void ReviveTree(PlayerHealth player)
    {
        if (isDead)
        {
            isDead = false;
            player.Heal(healAmount);

            // Меняем модель дерева
            meshFilter.mesh = aliveMesh;

            // Показываем сообщение перед экраном
            if (messageUI != null)
            {
                messageUI.ShowMessage("Дерево ожило и вылечило тебя!");
            }
        }
    }
}
