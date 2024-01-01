using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void Test1()
    {
        SceneManager.LoadScene("Test1");
    }

    public void Test2() {
        SceneManager.LoadScene("Test2");
    }
}
