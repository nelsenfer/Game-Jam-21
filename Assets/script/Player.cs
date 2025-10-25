using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 CameraWorldScale;
    private GameObject Meteor;
    private Vector3 moveDirection;
    [SerializeField] private float speed;
    public AudioClip collisions;

    void Start() 
    {
        Cursor.visible = false;
        CameraWorldScale = Camera.main.ScreenToWorldPoint
        (new Vector3(Screen.width, Screen.height, 
        Camera.main.transform.position.z));

    }

    void Update()
    {
        float InputY = Input.GetAxis("Vertical");
        float InputX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(InputX, InputY, 0f); 
    }
    
    void FixedUpdate()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, CameraWorldScale.x * -1, CameraWorldScale.x);
        viewPos.y = Mathf.Clamp(viewPos.y, CameraWorldScale.y * -1, CameraWorldScale.y);
        transform.position = viewPos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Meteor")
        {
            Debug.Log("Meteor");
            AudioSource.PlayClipAtPoint(collisions, transform.position);

        }
    }
}