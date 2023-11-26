using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    protected Rigidbody2D rigid2d;

    [SerializeField] private Vector3 velocity = new Vector3(0f, 0f, 0f);
    private float speedUp = 0.3f;
    private float speedDownd = 0.5f;
    [SerializeField] private float speedMax = 20f;
    private float speedHorizontal = 3f;

    private float pressHorizontal = 0f;
    public float pressVertical = 0f;

    public Joystick joystick;


    [SerializeField] private Transform roadTrans;
    private Vector2 sizeOfRoad;

    private void Awake()
    {
        this.rigid2d = GetComponent<Rigidbody2D>();

        // get half width of player
        float halfPlayerWidth = transform.localScale.x / 2f;

        // set size of Road Prefab
        this.sizeOfRoad = this.roadTrans.GetChild(0).GetComponent<SpriteRenderer>().bounds.size;
        this.sizeOfRoad /= 2;
        this.sizeOfRoad.x -= halfPlayerWidth;
    }

    private void Update()
    {
        if (!CarGameManager.intance.IsGameRunning || CarGameManager.intance.IsGameOver) return;
        this.HorizontalPressed();
        /*this.pressHorizontal = Input.GetAxis("Horizontal");  
        this.pressVertical = Input.GetAxis("Vertical");*/
    }

    private void FixedUpdate()
    {
        if (CarGameManager.intance.IsGameOver) return;
        if (!CarGameManager.intance.IsGameRunning || CarGameManager.intance.IsGameOver) return;
        this.UpdateSpeed();
    }

    public void HorizontalPressed()
    {
        if (joystick.Horizontal < 0)
        {
            this.pressHorizontal = -1;
        }
        else if (joystick.Horizontal > 0) this.pressHorizontal = 1;
        else this.pressHorizontal = 0;
    }

    public void PoiterRigh()
    {
        this.pressHorizontal = 1;
    }

    public void PoiterLeft()
    {
        this.pressHorizontal = -1;
    }
    public void PoiterMove()
    {
        this.pressVertical = 1;
    }

    public void PoiterUp()
    {
        this.pressHorizontal = 0;
        this.pressVertical = 0;
    }


    protected virtual void UpdateSpeed()
    {
        velocity.x = this.pressHorizontal * this.speedHorizontal;

        if(transform.position.x >= this.sizeOfRoad.x || transform.position.x <= -this.sizeOfRoad.x)
        {
            if (transform.position.x >= this.sizeOfRoad.x)
                transform.position = new Vector2(this.sizeOfRoad.x, transform.position.y);
            else if(transform.position.x <= - this.sizeOfRoad.x)
                transform.position = new Vector2(-this.sizeOfRoad.x, transform.position.y);

            /*this.velocity.y -= speedDownd;
            if (this.velocity.y <= 0)
            {
                this.velocity.y = 0;
            }*/
        }

        if (this.pressVertical > 0)
        {
            this.velocity.y += speedUp;
            if (this.velocity.y >= this.speedMax)
            {
                this.velocity.y = this.speedMax;
            }
        }
        else
        {
            this.velocity.y -= speedDownd;
            if (this.velocity.y <= 0)
            {
                this.velocity.y = 0;
            }
        }

        /*else
        {
            if (this.pressVertical > 0)
            {
                this.velocity.y += speedUp;
                if (this.velocity.y >= this.speedMax)
                {
                    this.velocity.y = this.speedMax;
                }
            }
            else
            {
                this.velocity.y -= speedDownd;
                if (this.velocity.y <= 0)
                {
                    this.velocity.y = 0;
                }
            }
        }*/
        //this.rigid2d.MovePosition(this.rigid2d.position + this.velocity * Time.fixedDeltaTime);
        transform.position += this.velocity * Time.fixedDeltaTime;
    }
}
