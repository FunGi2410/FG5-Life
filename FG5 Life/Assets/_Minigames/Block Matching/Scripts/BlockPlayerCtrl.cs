using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlayerCtrl : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    private float screenHalfWidthInWorldUnits;

    [SerializeField] private List<GameObject> shapeObjs;
    private int randomIndexShape;

    [SerializeField] private IDBlock curID;

    private float timer = 0f;
    [SerializeField] private float secondsBetweenChangeShape = 6f;

    public event System.Action OnPlayerDeath;

    private void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;
    }
    private void Update()
    {
        if (!BlockMatchGameManager.Instance.IsGameRunning) return;
        // Change shape for player
        timer += Time.deltaTime;
        if (timer >= secondsBetweenChangeShape)
        {
            timer = 0f;
            this.ChangeShape();
        }

        //if (!GameController.Instance.IsGameRunning) return;
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
        else if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
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
