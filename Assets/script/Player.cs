using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 CameraWorldScale;
    private GameObject SwordFish;
    private Vector3 moveDirection;
    [SerializeField] private float speed;
    public AudioClip collisions;
    private int Heart;
    Rigidbody2D rb;

    void Start() 
    {
        //Cursor.visible = false;
        CameraWorldScale = Camera.main.ScreenToWorldPoint //
        (new Vector3(Screen.width, Screen.height,         //
        Camera.main.transform.position.z));               //
        rb = GetComponent<Rigidbody2D>();
        Heart = 3;
    }

    void Update()
    {
        float InputY = Input.GetAxis("Vertical");
        float InputX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(InputX, InputY, 0f); 

        if (Input.GetKeyDown(KeyCode.G))
        {
           if (rb.gravityScale == 0)
            {
                rb.gravityScale = 1; // hidupkan gravitasi
            }
            else
            {
                rb.gravityScale = 0; // matikan gravitasi
            }

        }
    }
    
    void FixedUpdate()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void LateUpdate()
    {
        //Vector3 viewPos = transform.position;
        //viewPos.x = Mathf.Clamp(viewPos.x, CameraWorldScale.x * -1, CameraWorldScale.x);
       // viewPos.y = Mathf.Clamp(viewPos.y, CameraWorldScale.y * -1, CameraWorldScale.y);
        //transform.position = viewPos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SwordFish")
        {
            Debug.Log("SwordFish");
            Heart --;
        }
    }
}