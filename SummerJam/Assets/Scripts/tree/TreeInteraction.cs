using UnityEngine;

public class TreeInteraction : MonoBehaviour
{
    private PlayerHealth player;

    void Start()
    {
        // ���������� ����� ����� ������ �����������
        player = Object.FindFirstObjectByType<PlayerHealth>();
        // ���� ����� ������ ����� ����� ������ PlayerHealth:
        // player = Object.FindAnyObjectByType<PlayerHealth>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // ������ ��������������
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 3f))
            {
                Tree tree = hit.collider.GetComponent<Tree>();
                if (tree != null)
                {
                    tree.ReviveTree(player);
                }
            }
        }
    }
}
