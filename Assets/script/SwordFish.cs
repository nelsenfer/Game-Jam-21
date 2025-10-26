using UnityEngine;

public class SwordFish : MonoBehaviour
{

    public float speed = 10f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

    }

}


