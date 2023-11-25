using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CapsuleController : MonoBehaviour
{
    public float jumpForce;
    public float forwardForce;
    private Rigidbody2D myRig;

    
    private bool isJump;
    private bool isGrounded;
    private CapsuleGameController myCtrl;

    private bool isPush;

    /*public AudioSource playShotSound;
    public AudioClip deafSoundChild;
    public AudioClip jumpSoundChild;*/

    private float myTime;
    private float TimeDistance = 0.5f;

    public float rotateSpeed;
    void Start()
    {
        myRig = GetComponent<Rigidbody2D>();
        myCtrl = FindObjectOfType<CapsuleGameController>();
        isJump = false;
        isPush = false;
        myTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (myCtrl.IsGameover) return;
        if (Input.GetKeyDown("space") || Input.GetKeyUp("space")) SetIsJump();
        if (Input.GetKeyDown("f") || Input.GetKeyUp("f")) SetIsPush();

        if (GetIsJump() && isGrounded)
        {
            /*if (playShotSound && jumpSoundChild)
            {
                playShotSound.PlayOneShot(jumpSoundChild);
            }*/
            JumpForce();
            isGrounded = false;
        }
        myTime -= Time.deltaTime;
        if (myTime <= 0)
        {
            if (GetIsPush())
            {
                Push();
                myTime = TimeDistance;
            }
        }
       
        RotateOnPressed();
    }

    
    public void SetIsJump()
    {
        if (GetIsJump() == false)
        {
            isJump = true;
        }
        else
        {
            isJump = false;
        }
    }
    public bool GetIsJump()
    {
        return isJump;
    }
    void JumpForce()
    {
        myRig.AddForce(new Vector2(transform.position.x, jumpForce));
    }

    //*****************************************************

    public void SetIsPush()
    {
        if (GetIsPush() == false)
        {
            isPush = true;
        }
        else
        {
            isPush = false;
        }
    }
    public bool GetIsPush()
    {
        return isPush;
    }
    void Push()
    {
        myRig.AddForce(new Vector2(forwardForce, transform.position.y));
    }

    //*****************************************************

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            /*if (playShotSound && deafSoundChild)
            {
                playShotSound.PlayOneShot(deafSoundChild);
            }*/
            myCtrl.SetGameover(true);
            myCtrl.IsGameRunning = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AddScore"))
        {
            myCtrl.ScoreIncrement();
        }
    }


    /*public bool isLeftRotate;
    public float rotatePressed;
    public void SetRotateLeftButton()
    {
        rotatePressed = -1;
    }

    public void SetRotateRightButton()
    {
        rotatePressed = 1;
    }*/

    public Joystick joystick;
    float horizontalRotate = .0f;

    float temp;
    public void RotateOnPressed()
    {
        Quaternion m_MyQuaternion = transform.rotation;
        temp = 0;
        horizontalRotate = joystick.Horizontal;
        temp += Mathf.Abs(horizontalRotate);
        Debug.Log(horizontalRotate);


        //float rotatePressed = Input.GetAxis("Horizontal");

        if (horizontalRotate < 0)
        {
            
            //Debug.Log("temp = " + temp);

            //m_MyQuaternion = Quaternion.Euler(new Vector3 (0f, 0f, -90) * rotatePressed);
            m_MyQuaternion = Quaternion.Euler(new Vector3(0f, 0f, -90) * horizontalRotate);
        }
        else if (horizontalRotate > 0)
        {
            //m_MyQuaternion = Quaternion.Euler(new Vector3(0f, 0f, -90) * rotatePressed);
            m_MyQuaternion = Quaternion.Euler(new Vector3(0f, 0f, -90) * horizontalRotate);
        }
        else if (horizontalRotate == 0)
        {
            m_MyQuaternion = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
        
        transform.rotation = m_MyQuaternion;
    }

    
}
