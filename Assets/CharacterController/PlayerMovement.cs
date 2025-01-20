using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    private Rigidbody2D playerRigidbody;
    private Vector2 moveDirection;
    
    void Awake()
    {
        playerRigidbody = this.GetComponent<Rigidbody2D>();
        InputActions.MoveEvent += UpdateMoveVector;
    }

    private void UpdateMoveVector(Vector2 inputVector) // player input = moveVector(current vector2 from HandlePlayerMove)
    {
        moveDirection = inputVector;
    }

    void HandlePlayerMove(Vector2 moveVector) // use .Move functionality to move player on set veriables, gets updated by UpdateMoveVector() method
    {
        playerRigidbody.MovePosition(playerRigidbody.position + moveVector * moveSpeed * Time.fixedDeltaTime);
    }

    private void FixedUpdate() // moving player by character controller component every frame
    {
        HandlePlayerMove(moveDirection);
    }
    private void OnDisable()
    {
        InputActions.MoveEvent -= UpdateMoveVector;
    }
}
