using UnityEngine;
using UnityEngine.InputSystem;

public class MovementManager : MonoBehaviour
{
    public Vector2 moveInput;
    public Rigidbody2D rb;
    public int movespeed;

    public Animator playerAnimator;

    private int animatorMovement = Animator.StringToHash("Movement");
    private int animatorDance = Animator.StringToHash("Dance");
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        rb.MovePosition(rb.position + moveInput * movespeed * Time.deltaTime);
    }

    public void HandlePlayerAnimation()
    {
        if (moveInput == Vector2.zero)
        {
            playerAnimator.SetBool(animatorMovement, false);
        }
        else
        {
            playerAnimator.SetBool(animatorMovement, true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        HandlePlayerAnimation();
    }

    public void Ondance(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerAnimator.SetBool(animatorDance, true);
        }
        if (context.canceled)
        {
            playerAnimator.SetBool(animatorDance, false);
        }
    }
}
