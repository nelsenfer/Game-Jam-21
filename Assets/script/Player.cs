using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 moveDirection;
    [SerializeField] private float speed = 5f;
    private int Heart = 3;
    private Rigidbody2D rb;

    public GameObject[] shipTarget;
    private int indexShip = 0;

    public float jumpDuration = 1.5f;
    public float jumpHeight = 2f;

    private bool isJumping = false;
    private bool canJump = true; // <-- tambahan: agar hanya bisa lompat sekali
    private float jumpTimer = 0f;
    private Vector3 jumpStartPos;
    private Vector3 jumpEndPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");
        moveDirection = new Vector3(inputX, inputY, 0f);

        // hanya bisa bergerak kalau tidak sedang lompat
        if (!isJumping)
        {
            transform.position += moveDirection * speed * Time.deltaTime;

            // deteksi naik ke permukaan → hanya kalau boleh lompat
            if (transform.position.y > 2.5f && canJump)
            {
                StartJump();
            }
        }
        else
        {
            UpdateJump();
        }

        // jika sudah kembali ke air, reset izin lompat
        if (transform.position.y < 2.3f)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            canJump = true; // sekarang boleh lompat lagi
        }
    }

    void StartJump()
    {
        if (isJumping) return;

        isJumping = true;
        canJump = false; // tidak boleh lompat lagi sampai jatuh ke air
        jumpTimer = 0f;
        jumpStartPos = transform.position;
        jumpEndPos = shipTarget[indexShip].transform.position;

        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;

        Debug.Log("Mulai lompat ke kapal!");
    }

    void UpdateJump()
    {
        jumpTimer += Time.deltaTime;
        float t = jumpTimer / jumpDuration;

        if (t >= 1f)
        {
            // selesai lompat → aktifkan gravitasi untuk jatuh bebas
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
