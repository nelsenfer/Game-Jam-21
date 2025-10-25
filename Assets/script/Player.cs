using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 moveDirection;
    [SerializeField] private float speed = 5f;
    private int Heart = 3;
    private Rigidbody2D rb;

    public GameObject[] shipTarget; // daftar semua kapal
    private GameObject nearestShip; // kapal terdekat yang sedang dituju

    public float jumpDuration = 1.5f;
    public float jumpHeight = 2f;

    private bool isJumping = false;
    private bool canJump = true;
    private float jumpTimer = 0f;
    private Vector3 jumpStartPos;
    private Vector3 jumpEndPos;
    public GameObject DeathCanvas;
private Vector3 zeroVector = Vector3.zero;

    SpriteRenderer sr;

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        // hanya bisa bergerak kalau tidak sedang lompat
        if (!isJumping)
        {
            transform.position += moveDirection * speed * Time.deltaTime;

            // deteksi naik ke permukaan → hanya kalau boleh lompat
            if (transform.position.y > 2.5f && canJump)
            {
                nearestShip = FindNearestShip();
                if (nearestShip != null)
                {
                    StartJump(nearestShip.transform.position);
                }
            }
        }
        else
        {
            UpdateJump();
        }

        // jika sudah kembali ke air, reset izin lompat
        if (transform.position.y < 2.3f)
        {
            animator.SetBool("water", true);
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            canJump = true;
        }

        if (Heart == 0)
        {
            DeathCanvas.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(inputX, inputY, 0f);
        if (inputX != 0 || inputY != 0)
        {
            animator.SetBool("walk", true);
        }

        else if (inputX == 0 && inputY == 0)
        {
            animator.SetBool("walk", false);
        }

        if (inputX < 0)
        {
            sr.flipX = true;
        }
        else if (inputX > 0)
        {
            sr.flipX = false;
        }
    }

    // Mendeteksi kapal terdekat
    GameObject FindNearestShip()
    {
        GameObject nearest = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        foreach (GameObject ship in shipTarget)
        {
            if (ship == null) continue;
            float distance = Vector3.Distance(currentPos, ship.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = ship;
            }
        }

        return nearest;
    }

    void StartJump(Vector3 targetPos)
    {
        if (isJumping) return;
        
        animator.SetBool("water", false);

        isJumping = true;
        canJump = false;
        jumpTimer = 0f;
        jumpStartPos = transform.position;
        jumpEndPos = targetPos;

        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;

        Debug.Log("Mulai lompat ke kapal terdekat!");
    }

    void UpdateJump()
    {
        jumpTimer += Time.deltaTime;
        float t = jumpTimer / jumpDuration;

        if (t >= 1f)
        {
            transform.position = jumpEndPos;
            rb.gravityScale = 1;
            isJumping = false;
            Debug.Log("Mendarat di kapal, mulai jatuh bebas!");
            return;
        }

        // gerak lerp dengan parabola
        Vector3 flatLerp = Vector3.Lerp(jumpStartPos, jumpEndPos, t);
        float parabola = Mathf.Sin(t * Mathf.PI) * jumpHeight;
        flatLerp.y += parabola;

        transform.position = flatLerp;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SwordFish"))
        {
            Debug.Log("SwordFish");
            Heart--;
        }
    }
}
