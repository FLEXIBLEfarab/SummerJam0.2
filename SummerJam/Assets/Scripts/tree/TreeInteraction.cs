using UnityEngine;

public class TreeInteraction : MonoBehaviour
{
    private PlayerHealth player;

    void Start()
    {
        // Используем новый метод вместо устаревшего
        player = Object.FindFirstObjectByType<PlayerHealth>();
        // Если нужно просто найти любой объект PlayerHealth:
        // player = Object.FindAnyObjectByType<PlayerHealth>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Кнопка взаимодействия
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
