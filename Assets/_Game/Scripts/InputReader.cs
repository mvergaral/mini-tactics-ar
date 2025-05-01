using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public Vector2 LastTapPosition { get; private set; }
    public bool TapDetected { get; private set; }

    private GameInputActions inputActions;

    private void Awake()
    {
        inputActions = new GameInputActions();
        inputActions.Gameplay.Tap.performed += ctx =>
        {
            LastTapPosition = ctx.ReadValue<Vector2>();
            TapDetected = true;
        };
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void ResetTap()
    {
        TapDetected = false;
    }
}
