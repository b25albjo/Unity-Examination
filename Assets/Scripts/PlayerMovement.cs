using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;
    
    private Rigidbody2D myRigidbody2D;
    
    private InputAction move;
    
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.gravityScale = 0;
        
        move = InputSystem.actions.FindAction("Move");
    }
    
    void Update()
    {
        myRigidbody2D.linearVelocity = move.ReadValue<Vector2>() * moveSpeed;
        
        if (move.ReadValue<Vector2>().x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (move.ReadValue<Vector2>().x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
