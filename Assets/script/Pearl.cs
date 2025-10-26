using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pearl : MonoBehaviour
{
    public int pearl = 0;
    int pearlInscene;
    public Player player;
    public GameObject Earlypearl1;
    public GameObject Earnedpearl1;
    public GameObject Earlypearl2;
    public GameObject Earnedpearl2;
    public GameObject Earlypearl3;
    public GameObject Earnedpearl3;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene baru dimuat: " + scene.name);
        pearl += pearlInscene;
        Debug.Log(pearl);
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        Debug.Log(pearl);
    }

    void Update()
    {
        Showpearl();
        pearlInscene = player.pearls;
    }

    void Showpearl()
    {
        if (pearlInscene == 1)
        {
            Earlypearl1.SetActive(true);
            Earnedpearl1.SetActive(false);

            Earlypearl2.SetActive(true);
            Earnedpearl2.SetActive(false);

            Earlypearl3.SetActive(true);
            Earnedpearl3.SetActive(false);
        }
        if (pearlInscene == 1)
        {
            Earlypearl1.SetActive(false);
            Earnedpearl1.SetActive(true);

            Earlypearl2.SetActive(true);
            Earnedpearl2.SetActive(false);

            Earlypearl3.SetActive(true);
            Earnedpearl3.SetActive(false);
        }

        if (pearlInscene == 2)
        {
            Earlypearl1.SetActive(false);
            Earnedpearl1.SetActive(true);

            Earlypearl2.SetActive(false);
            Earnedpearl2.SetActive(true);

            Earlypearl3.SetActive(true);
            Earnedpearl3.SetActive(false);
        }

        if (pearlInscene == 3)
        {
            Earlypearl1.SetActive(false);
            Earnedpearl1.SetActive(true);

            Earlypearl2.SetActive(false);
            Earnedpearl2.SetActive(true);

            Earlypearl3.SetActive(false);
            Earnedpearl3.SetActive(true);
            Debug.Log(pearl);
        }
    }
}