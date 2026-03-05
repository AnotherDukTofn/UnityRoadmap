using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Survivor survivor;
    public string PlayerName { get; private set; }

    [SerializeField] private float moveDirection;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<float>();
    }

    private void Update()
    {
        survivor.Move(moveDirection);
    }
}
