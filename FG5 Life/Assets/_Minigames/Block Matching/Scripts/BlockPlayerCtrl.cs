using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlayerCtrl : MonoBehaviour
{
    private float screenHalfWidthInWorldUnits;

    [SerializeField] private List<GameObject> shapeObjs;
    private int randomIndexShape;

    [SerializeField] private IDBlock curID;

    private float timer = 0f;
    [SerializeField] private float secondsBetweenChangeShape = 6f;

    public event System.Action OnPlayerDeath;
    Vector2 difference = Vector2.zero;
    Animator animator;
    [SerializeField] private GameObject deadEffect;

    private void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;
        this.animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        this.difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        Vector2 transformPosMouse = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
        transform.position = new Vector2(transformPosMouse.x, transform.position.y);
        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
        else if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
    }
    private void Update()
    {
        if (!BlockMatchGameManager.Instance.IsGameRunning) return;
        // Change shape for player
        timer += Time.deltaTime;
        if(timer >= secondsBetweenChangeShape - 3)
        {
            this.animator.SetBool("IsChange", true);
        }
        if (timer >= secondsBetweenChangeShape)
        {
            timer = 0f;
            this.animator.SetBool("IsChange", false);
            this.ChangeShape();
        }
    }

    private void ChangeShape()
    {
        this.randomIndexShape = Random.Range(0, this.shapeObjs.Count);
        GameObject shape = this.shapeObjs[randomIndexShape];
        gameObject.GetComponent<SpriteRenderer>().sprite = shape.GetComponent<SpriteRenderer>().sprite;
        transform.position = new Vector2(transform.position.x, shape.transform.position.y);
        this.curID = shape.GetComponent<IDBlockPlayer>().id;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if(this.curID == collision.gameObject.GetComponent<BlockEnemyCtrl>().id)
            {
                int score = ++BlockMatchGameManager.Instance.Score;
                UIBlockMathManager.Instance.ScoreTxt.text = score.ToString();
            }
            else
            {
                Instantiate(deadEffect, transform.position, Quaternion.identity);
                Instantiate(collision.GetComponent<BlockEnemyCtrl>().DeadEffect, collision.gameObject.transform.position, Quaternion.identity);
                print("Player Died");
                if (OnPlayerDeath != null)
                {
                    this.OnPlayerDeath();
                }
                BlockMatchGameManager.Instance.GameOver();
                Destroy(gameObject);
            }
        }
        
        Destroy(collision.gameObject);
    }
}
