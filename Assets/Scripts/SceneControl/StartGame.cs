using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public static bool game_is_start = false;
    public StartingPush push;
    public GameObject direction_plane;
    public GameObject ball;
    public GameObject start_stop_text;
    private Text _text;

    private void Start()
    {
        BallIntoPositions();
        ball.SetActive(true);
        _text = start_stop_text.GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        if (game_is_start && StartingPush._rigidbody.IsSleeping())
        {
            if (Finish.is_triggered)
            {
                Debug.Log("Победа");
                game_is_start=false;
                NextScene.Switcher();
            }
            else
            {
                Debug.Log("Не победа");
            }
        }
    }

    public void StartEnd()
    {
        if (!game_is_start)
        {
            Starting();
        }
        else
        {
            Ending();
        }
    }

    private void Starting()
    {
        ball.GetComponent<Rigidbody>().useGravity = true;
        ball.GetComponent<Collider>().enabled = true;
        push.Push(direction_plane.transform.forward);
        game_is_start=true;
        _text.text = "Pause";
        SpeedPlanesReset();
    }

    public void Ending()
    {
        _text.text = "Start";
        StartingPush._rigidbody.velocity = Vector3.zero;
        StartingPush._rigidbody.angularVelocity = Vector3.zero;
        BallIntoPositions();
        game_is_start = false;
        ball.GetComponent<Rigidbody>().useGravity = false;
        ball.GetComponent<Collider>().enabled = false;
    }

    private void BallIntoPositions()
    {
        ball.transform.position = direction_plane.transform.position + new UnityEngine.Vector3(0, 0.49f, 0);
    }

    private void SpeedPlanesReset()
    {
        var found_objects = FindObjectsByType<SpeedPlane>(FindObjectsSortMode.None);
        for (int i = 0; i < found_objects.Length; i++)
        {
            found_objects[i].is_used = false;
        }
    }
}
