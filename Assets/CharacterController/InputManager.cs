using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, GameInput.IPlayerActions
{
    private GameInput gameInput;

    void Awake()
    {
        gameInput = new GameInput();
        gameInput.Player.Enable(); // enable input system

        gameInput.Player.SetCallbacks(this);
    }

    public void OnMove(InputAction.CallbackContext context) // player input updates by vector2
    {
        if (context.performed || context.canceled) // prevent sliding, char stops moving when button released
        {
            Debug.Log("Move input recieving: " + context.ReadValue<Vector2>());
            InputActions.MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }
    }

    public void OnInteraction(InputAction.CallbackContext context) // spacebar input, cancelled for bomb flass on space hold/release change colors
    {
        if (context.performed)
        {
            Debug.Log("Interaction input recieving: " + context.ReadValue<float>());
            InputActions.InteractEvent?.Invoke();
        }
        if (context.canceled)
        {
            Debug.Log("Interaction input cancelled: " + context.ReadValue<float>());
            InputActions.InteractEventCancelled?.Invoke();
        }
    }
}

public static class InputActions // can expand to add more actions for the player
{
    public static Action<Vector2> MoveEvent;    
    public static Action InteractEvent; 
    public static Action InteractEventCancelled;    
}
