using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerCharacter2D : CharacterController2D
{
    public float speed = 3.0f;
    public float collisionTestOffset;
    public SpriteRenderer spriteRenderer;
    private static int _coin = 0;
    private static int _life = 2;
    private Rigidbody2D rigidbody2D;
    private int canJumpAgain = 0;
    private float jumpInputLastFrame = 0.0f;
    private static PlatformerPlayerCharacter2D _state;
    public static PlatformerPlayerCharacter2D State
    {
        get
        {
            if(_state == null)
            {
                Debug.LogError("Game is uninitialized?");
            }
            return _state;
        }
    }

    void Awake()
    {
        _state = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        isTouchingGround = IsTouchingGround();
        Vector2 motion = rigidbody2D.velocity;
        UIManager.State.UpdateCoinText(_coin);
        UIManager.State.UpdateLifeText(_life);

        // Test before you move
        if (xInput != 0.0f)
            motion.x = xInput*speed;

        if (IsTouchingGround())
        {
            canJumpAgain = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && canJumpAgain < 2)
        {
                motion.y = speed + 1.5f;
                canJumpAgain++;
        }

        rigidbody2D.velocity = motion;

    }

    public void CoinCounter()
    {
        _coin++;
        if(_coin == 100)
        {
            _coin = 0;
            _life++;
        }
    }

    public void LifeCounter()
    {
        _life++;
    }
}
