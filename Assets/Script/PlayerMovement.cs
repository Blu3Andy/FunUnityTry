using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputMaster playerInput;

    public float speed = 1f;

    Vector2 movement;

    private Vector2 move;

    public Animator animator;

    void Awake()
    {
        playerInput = new InputMaster();

        animator = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
     movePlayer();

     if(movement != Vector2.zero)
     {
        animator.SetFloat("Horizontal", movement.x);

        animator.SetFloat("Vertical", movement.y);
     }

     animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void movePlayer()
    {
        movement = new Vector2(move.x, move.y);

        transform.Translate(movement *speed * Time.deltaTime);
    }

    void OnEnable()
    {
        playerInput.Player.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
    }
}
