using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNumber : MonoBehaviour
{
    public int number;

    public void Switcher()
    {
        SceneManager.LoadScene(number);
    }
}
