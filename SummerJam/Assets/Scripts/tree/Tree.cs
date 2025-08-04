using UnityEngine;

public class Tree : MonoBehaviour
{
    public bool isDead = true;
    public int healAmount = 20;

    public Mesh deadMesh;   // ������ ������ ������
    public Mesh aliveMesh;  // ������ ������ ������

    private MeshFilter meshFilter;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = deadMesh; // ���������� ����� ������
    }

    public void ReviveTree(PlayerHealth player)
    {
        if (isDead)
        {
            isDead = false;
            player.Heal(healAmount);

            // ������ ������ ������
            meshFilter.mesh = aliveMesh;

            Debug.Log("������ ����� � �������� ������!");
        }
    }
}
