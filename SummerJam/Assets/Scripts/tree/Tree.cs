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

        // ������� ��������� MessageUI � �����
        messageUI = FindObjectOfType<MessageUI>();
    }

    public void ReviveTree(PlayerHealth player)
    {
        if (isDead)
        {
            isDead = false;
            player.Heal(healAmount);

            // ������ ������ ������
            meshFilter.mesh = aliveMesh;

            // ���������� ��������� ����� �������
            if (messageUI != null)
            {
                messageUI.ShowMessage("������ ����� � �������� ����!");
            }
        }
    }
}
