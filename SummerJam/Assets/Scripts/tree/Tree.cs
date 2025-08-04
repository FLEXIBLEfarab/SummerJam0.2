using UnityEngine;

public class Tree : MonoBehaviour
{
    public bool isDead = true;
    public int healAmount = 20;

    public Mesh deadMesh;   // Модель сухого дерева
    public Mesh aliveMesh;  // Модель живого дерева

    private MeshFilter meshFilter;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = deadMesh; // Изначально сухое дерево
    }

    public void ReviveTree(PlayerHealth player)
    {
        if (isDead)
        {
            isDead = false;
            player.Heal(healAmount);

            // Меняем модель дерева
            meshFilter.mesh = aliveMesh;

            Debug.Log("Дерево ожило и поменяло модель!");
        }
    }
}
