using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : CharacterController2D
{
    public float speed;
    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        if(faceRight())
        {
            rigidBody.velocity = new Vector2(speed, 0f);
        }
        else
        {
            rigidBody.velocity = new Vector2(-speed, 0f);
        }

    }


    private bool faceRight()
    {
        return transform.localScale.x > 0.001f;
    }

    private void OnTriggerExit2D(Collider2D boxCollider) //turning
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rigidBody.velocity.x)), transform.localScale.y);
    }
}
