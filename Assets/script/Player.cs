using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject SwordFish;
    private Vector3 moveDirection;
    [SerializeField] private float speed;
    public AudioClip collisions;
    private int Heart;
    Rigidbody2D rb;
    public Transform shipTarget; // titik kapal tempat ikan mendarat
    public float jumpDuration = 1.5f, jumpHeight = 2f;     // tinggi loncatan
    private bool isJumping = false;

    void Start() 
    {
        //Cursor.visible = false;  
        rb = GetComponent<Rigidbody2D>();
        Heart = 3;
    }

    void Update()
    {
        float InputY = Input.GetAxis("Vertical");
        float InputX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(InputX, InputY, 0f); 

        
        if (transform.position.y > 2.5f)
            {
                rb.gravityScale = 1; // hidupkan gravitasi
                StartCoroutine(JumpToShip());
            }
        else if (transform.position.y < 2.3f)
            {
                rb.gravityScale = 0; // matikan gravitasi
                rb.velocity = new Vector2(rb.velocity.x, 0f);
            }


    }
    
    void FixedUpdate()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SwordFish")
        {
            Debug.Log("SwordFish");
            Heart --;
        }
    }

    IEnumerator JumpToShip()
    {
        isJumping = true;

        Vector3 startPos = transform.position;
        Vector3 endPos = shipTarget.position;
        float time = 0f;

        while (time < jumpDuration)
        {
            time += Time.deltaTime;
            float t = time / jumpDuration; // progress 0 -> 1

            // Lerp posisi dasar (lurus)
            Vector3 flatLerp = Vector3.Lerp(startPos, endPos, t);

            // Tambahkan efek parabola di sumbu Y
            float parabola = Mathf.Sin(t * Mathf.PI) * jumpHeight;
            flatLerp.y += parabola;

            transform.position = flatLerp;
            yield return null;
        }

        transform.position = endPos;
        isJumping = false;

        // (Opsional) bisa tambahkan event setelah landing
        Debug.Log("Ikan mendarat di kapal!");
    }
}