using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveForce = 20f;
    public float MaxVelocity = 5f;
    public float Jumpforce = 200f;
    public bool grounded = true;

    private Rigidbody2D mybody;
    private Animation anim;

    private bool moveLeft = false;
    private bool moveRight = false;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerWalkKeyboard();
    }

    void PlayerWalkKeyboard()
    {
        float forceX = 0;
        float forceY = 0;
        float vel = Mathf.Abs(mybody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        if (vel < MaxVelocity)
        {
            Vector3 temp = transform.localScale;
            if (h > 0)
            {
                temp.x = 1f;
                forceX = MoveForce;
            }
            else if (h < 0)
            {
                temp.x = -1f;
                forceX = -MoveForce;
            }
            else 
            {

            }
            transform.localScale = temp;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                forceY = Jumpforce;
                mybody.AddForce(new Vector2(0, forceY));
            }
        }
        mybody.AddForce(new Vector2(forceX, forceY));
    }



    public void Jump()
    {
        if (grounded)
        {
            grounded = false;
            mybody.AddForce(new Vector2(0, Jumpforce));
        }
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }
    public void MoveLeft(bool left)
    {
        moveLeft = left;
        moveRight = !left;
    }
    public void StopMoving()
    {
        moveLeft = moveRight = false;
    }
}
