using UnityEngine;

public class HP : MonoBehaviour
{
    public Player player;  //drag gameobject player
    private int healthPlayer;


    public GameObject Health1;
    public GameObject Health2;
    public GameObject Health3;

    void Start()
    {

    }

    void Update()
    {
        healthPlayer = player.heart;


        if (healthPlayer == 0)
        {
            Health1.SetActive(false);
            Health2.SetActive(false);
            Health3.SetActive(false);
        }
        if (healthPlayer == 1)
        {
            Health1.SetActive(true);
            Health2.SetActive(false);
            Health3.SetActive(false);
        }
        if (healthPlayer == 2)
        {
            Health1.SetActive(true);
            Health2.SetActive(true);
            Health3.SetActive(false);
        }
        if (healthPlayer == 3)
        {
            Health1.SetActive(true);
            Health2.SetActive(true);
            Health3.SetActive(true);
        }
    }
}
