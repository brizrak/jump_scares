using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateObject : MonoBehaviour
{
    public GameObject prefab;
    private GameObject game_object;

    public GameObject button_text;
    private Text _text;

    private int count;

    private void Start()
    {
        count = CountObjects.Count(prefab.gameObject.name);
        _text = button_text.GetComponent<Text>();
        _text.text = Convert.ToString(count);
    }

    public void Create()
    {
        if (CountObjects.CounterMinus(prefab.gameObject.name) && !StartGame.game_is_start)
        {
            if (prefab.tag == "Object")
            {
                game_object = Instantiate(prefab, new Vector3(0, 1, 0), prefab.transform.rotation);
            }
            else if (prefab.tag == "Plane")
            {
                game_object = Instantiate(prefab, new Vector3(0, 0.51f, 0), prefab.transform.rotation);
            }
            AddObject game_object_script = game_object.GetComponent<AddObject>();
            game_object_script.is_moving = true;
            game_object_script.is_rotating = true;
            game_object_script.is_custom = true;
            count--;
            _text.text = Convert.ToString(count);
        }
    }

    private void Update()
    {
        if (count < CountObjects.Count(prefab.gameObject.name))
        {
            count++;
            _text.text = Convert.ToString(count);
        }
    }
}
