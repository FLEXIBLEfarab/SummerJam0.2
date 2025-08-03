using UnityEngine;

public class ThirdPersonCameraFixedPitch : MonoBehaviour
{
    public Transform player; // Игрок
    public Vector3 offset = new Vector3(0f, 2f, -4f);
    public float sensitivity = 200f;
    public float fixedPitch = 32.2f; // Фиксированный угол X

    private InputSystem_Actions _inputActions;
    private float _yaw; // Поворот по горизонтали

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        Vector2 look = _inputActions.Player.Look.ReadValue<Vector2>();

        // Только горизонтальный поворот
        _yaw += look.x * sensitivity * Time.deltaTime;

        // Вращаем игрока
        player.rotation = Quaternion.Euler(0f, _yaw, 0f);

        // Позиция камеры позади игрока
        transform.position = player.position + player.rotation * offset;

        // Фиксированный наклон по X, свободный поворот по Y
        transform.rotation = Quaternion.Euler(fixedPitch, _yaw, 0f);
    }
}
