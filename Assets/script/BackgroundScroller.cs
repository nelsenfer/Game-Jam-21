using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.2f;   // kecepatan scroll
    private Renderer rend;
    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // Gerakkan offset seiring waktu
        offset = new Vector2(Time.time * scrollSpeed, 0);
        rend.material.mainTextureOffset = offset;
    }
}
