using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : MonoBehaviour, Controlls.IMovementActions
{
    
    public Vector2 MovementValue { get; private set; }
    [SerializeField]
    float speed = 4f;

    private Animator animator;

    private Controlls controlls;


    public void OnMovement(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        controlls = new Controlls();
        controlls.Movement.SetCallbacks(this);

        controlls.Movement.Enable();

        animator = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        controlls.Movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        #region Character Movement
        Vector3 movement = new Vector3();
        movement.x = MovementValue.x;
        movement.y = 0;
        movement.z = MovementValue.y;
        transform.Translate(movement * Time.deltaTime * speed);
        #endregion
    }
}
