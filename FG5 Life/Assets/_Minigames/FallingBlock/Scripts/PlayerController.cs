using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 7f;
    float inputX = 0;
    private float screenHalfWidthInWorldUnits;

    public event System.Action OnPlayerDeath;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        this.animator = GetComponent<Animator>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();

        float halfPlayerWidth = transform.localScale.x / 2f;
        //screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;

    }
    private void Update()
    {
        if (!GameController.Instance.IsGameRunning) return;
        //float inputX = Input.GetAxisRaw("Horizontal");
        this.Animate(inputX);
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if(transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
        else if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
    }

    public void PoiterLeft()
    {
        this.inputX = -1;
    }

    public void PoiterRigh()
    {
        this.inputX = 1;
    }

    public void PoiterUp()
    {
        this.inputX = 0;
    }

    private void Animate(float inputX)
    {
        bool isMoving = inputX != 0 ? true : false;
        if (inputX > 0) this.spriteRenderer.flipX = false;
        else if (inputX < 0) this.spriteRenderer.flipX = true;
        
        this.animator.SetBool("isMoving", isMoving);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            this.animator.SetBool("isDead", true);
            if (OnPlayerDeath != null)
            {
                this.OnPlayerDeath();
            }
            //Destroy(gameObject);
        }
    }
}
