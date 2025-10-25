using UnityEngine;
using System.Collections;

public class SpawnSwordFish : MonoBehaviour
{
    public GameObject swordFishPrefab, warning;
    Vector3 spawnPos;


    void Start()
    {
        // Mulai coroutine yang meniru InvokeRepeating dengan jeda acak
        StartCoroutine(RandomInvoke());

    }

    void Update()
    {
        
        spawnPos = new Vector3(transform.position.x, 1f, transform.position.z);
    }

    IEnumerator RandomInvoke()
    {
        while (true)
        {
            // Jalankan fungsi yang ingin diulang
            SpawnFish();
            warning.SetActive(true);
            yield return new WaitForSeconds(6f);
            warning.SetActive(false);

            // Tunggu waktu acak antara 2 - 4 detik sebelum mengulangi
            float randomDelay = Random.Range(2f, 4f);
            yield return new WaitForSeconds(randomDelay);
            
        }
    }

    void SpawnFish()
    {
        Debug.Log("Menembak peluru!");
        Instantiate(swordFishPrefab, spawnPos, transform.rotation);
        
    }
}
