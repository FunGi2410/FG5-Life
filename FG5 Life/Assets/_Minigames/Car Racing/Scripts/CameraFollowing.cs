using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform followTransform;

    public Vector3 offset;

    public bool lockHorizontalFollow;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.lockHorizontalFollow)
        {
            transform.position = new Vector3(transform.position.x, followTransform.position.y + offset.y, offset.z);
            return;
        }
        transform.position = new Vector3(followTransform.position.x + offset.x, followTransform.position.y + offset.y, offset.z);
    }
}
