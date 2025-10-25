using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void Main()
    {

    }

    public void Restart()
    {
        SceneManager.LoadScene("Level1");
    }
}
