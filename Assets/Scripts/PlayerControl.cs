using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float thrust;
    public float RCSThrust;
    public Cannon cannon;

    PlayerInput playerInput;
    InputAction rcsAction;
    InputAction rcs2Action;
    InputAction engineAction;
    InputAction attackAction;
    Rigidbody rb;

    private bool isThrusting;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        rcsAction = playerInput.actions.FindAction("RCS");
        rcs2Action = playerInput.actions.FindAction("RCS2");
        engineAction = playerInput.actions.FindAction("Engine");
        attackAction = playerInput.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rcsAction.IsPressed() || rcs2Action.IsPressed())
        {
            rb.angularVelocity = new Vector3(0,0,0);
            Debug.Log("RCS");
            Debug.Log("rcs " + rcsAction.ReadValue<Vector2>());
            Debug.Log("rcs2 " + rcs2Action.ReadValue<Vector2>());
            Vector3 eulerAngleVelocity = new Vector3(RCSThrust * rcsAction.ReadValue<Vector2>().y,
                                                     RCSThrust * rcs2Action.ReadValue<Vector2>().x,
                                                     - RCSThrust * rcsAction.ReadValue<Vector2>().x);
            Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            
        }

        if (engineAction.IsPressed())
        {
            Debug.Log("Thrust");
            float currentThrust = thrust * Time.fixedDeltaTime;
            rb.AddRelativeForce(new Vector3(0, currentThrust, 0));
            Debug.Log(currentThrust);
        }
    }

    void Update()
    {
        if (attackAction.WasPressedThisFrame())
        {
            Debug.Log("Attack!");
            cannon.SetLaser(true);
        }
        else if (attackAction.WasReleasedThisFrame())
        {
            Debug.Log("Stop Attack!");
            cannon.SetLaser(false);
        }
    }
}
