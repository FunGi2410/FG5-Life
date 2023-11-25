using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScreen : MonoBehaviour
{
    public float speed = 2.0f;//easing speed

    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;
    //float z = 0.0f;

    bool flag = false;
    Vector3 target_position;

    [SerializeField] private Vector2 limitHorizontalDrag;
    [SerializeField] private Vector2 limitVerticalDrag = new Vector2(0, 0);

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit_position = Input.mousePosition;
            camera_position = transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            current_position = Input.mousePosition;
            LeftMouseDrag();
            flag = true;
        }

        if (flag)
        {
            if (transform.position.x <= limitHorizontalDrag.x)
            {
                transform.position = new Vector2(limitHorizontalDrag.x, transform.position.y);
            }
            else if(transform.position.x >= limitHorizontalDrag.y)
            {
                transform.position = new Vector2(limitHorizontalDrag.y, transform.position.y);
            }

            if(transform.position.y != limitVerticalDrag.x) transform.position = new Vector2(transform.position.x, limitVerticalDrag.x);

            transform.position = Vector3.MoveTowards(transform.position, target_position, Time.deltaTime * speed);
            if (transform.position == target_position)//reached?
            {
                flag = false;// stop moving
            }
        }
    }

    void LeftMouseDrag()
    {
        // From the Unity3D docs: "The z position is in world units from the camera."  In my case I'm using the y-axis as height
        // with my camera facing back down the y-axis.  You can ignore this when the camera is orthograhic.
        current_position.z = hit_position.z = camera_position.y;

        // Get direction of movement.  (Note: Don't normalize, the magnitude of change is going to be Vector3.Distance(current_position-hit_position)
        // anyways.  
        Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);

        // Invert direction to that terrain appears to move with the mouse.
        direction = direction * -1;

        target_position = camera_position + direction;
    }
}
