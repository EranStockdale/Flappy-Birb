using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public float flapStrength = 10;
    private LogicScript logic;
    public bool isAlive = true;
    public PlayerInputActions playerControls;
    private InputAction flap;

    void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    void OnEnable()
    {
        flap = playerControls.Player.Flap;
        flap.Enable();
        flap.performed += Flap;
    }

    void OnDisable()
    {
        flap.Disable(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isAlive = false;
        logic.GameOver();
    }

    private void Flap(InputAction.CallbackContext context) {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * flapStrength;
    }
}
