using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerCharacter2D : CharacterController2D
{
    public float speed = 3.0f;
    public float collisionTestOffset;
    public SpriteRenderer spriteRenderer;
    private int _coin;
    private int _life;
    private Rigidbody2D rigidbody2D;
    //private bool canJumpAgain;
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
        _coin = 0;
        _life = 2;
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

        /*while (IsTouchingGround())
        {
            canJumpAgain = true;
        }*/
        
        if (Input.GetAxis("Jump") > 0.0f && isTouchingGround){
                motion.y = speed + 1.5f;
            /* if(Input.GetAxis("Jump") > 0.0f && canJumpAgain == true)
            {
                motion.y = speed + 1.5f;
                canJumpAgain = false;
            } */
        }

        rigidbody2D.velocity = motion;

    }

    public void CoinCounter()
    {
        _coin++;
    }

    public void LifeCounter()
    {
        _life++;
    }
}
