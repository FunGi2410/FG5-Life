using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    //public Transform player;
    [SerializeField] private float randomSpeed;
    [SerializeField] private Vector2 rangeSpeed = new Vector2(13, 25);
    //private float distanceLimit = 3f;

    private float timer = 0f;
    [SerializeField] private float timeDisChangeSpeed = 5f;

    private Rigidbody2D mRigid;

    private void Awake()
    {
        this.randomSpeed = Random.Range(this.rangeSpeed.x, this.rangeSpeed.y);
        this.mRigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!CarGameManager.intance.IsGameRunning || CarGameManager.intance.IsGameOver) return;
        this.Move();
    }

    private void Update()
    {
        if (!CarGameManager.intance.IsGameRunning || CarGameManager.intance.IsGameOver) return;
        this.ChangeSpeed();
    }

    void ChangeSpeed()
    {
        if (!this.CheckTime()) return;
        this.randomSpeed = Random.Range(this.rangeSpeed.x, this.rangeSpeed.y);
    }

    bool CheckTime()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.timeDisChangeSpeed) return false;
        this.timer = 0f;
        return true;
    }

    void Move()
    {
        Vector2 moveVelocity = Vector2.up * this.randomSpeed;
        this.mRigid.MovePosition(mRigid.position + moveVelocity * Time.fixedDeltaTime);
    }

    /*void FollowObject()
    {
        Vector3 pos = PlayerCtrl.intance.transform.position;
        pos.x = this.ranPosX;

        Vector3 distance = pos - transform.position;
        pos.x = this.ranPosX;
        if (distance.magnitude >= this.distanceLimit)
        {
            Vector3 targetPoint = pos - distance.normalized * this.distanceLimit;
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, this.ranSpeed * Time.fixedDeltaTime);
        }
    }*/
}
