using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;   // drag Player di Inspector
    [SerializeField] private float smoothSpeed = 2f;  // semakin besar semakin cepat mengejar
    [SerializeField] private Vector2 offset;     // posisi relatif dari player

    private void LateUpdate()
    {
        if (player == null) return;

        // target posisi (2D)
        Vector2 targetPosition = (Vector2)player.position + offset;

        // posisi kamera sekarang (2D)
        Vector2 currentPosition = transform.position;

        // interpolasi halus (lerp)
        Vector2 smoothPosition = Vector2.Lerp(currentPosition, targetPosition, smoothSpeed * Time.deltaTime);

        // update posisi kamera, z tetap
        transform.position = new Vector3(smoothPosition.x, smoothPosition.y, transform.position.z);
    }
}
