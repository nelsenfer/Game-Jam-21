using UnityEngine;

public class SwordFish : MonoBehaviour
{
    //public GameObject player;
    //public GameObject WarningSprite;
    //[SerializeField] private float distanceX = 34f;
    //private bool isCrossed = false;
    public float speed = 5f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        
    }

    /*void Eaaaa()
    {
        // Hitung jarak di sumbu X saja (pakai nilai absolut supaya tidak negatif)
        float distX = Mathf.Abs(transform.position.x - player.transform.position.x);

        if (distX <= distanceX && !isCrossed)
        {
            WarningSprite.SetActive(true);
            Debug.Log("⚠️ Pemain mendekat!");
        }
        else
        {
            WarningSprite.SetActive(false);
        }
    }*/
}


