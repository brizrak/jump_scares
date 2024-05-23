using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameZone : MonoBehaviour
{
    public StartGame StartGame;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            StartGame.StartEnd();
        }
    }
}

