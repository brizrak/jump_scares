using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AddObject : MonoBehaviour
{
    public LayerMask layerMask;
    private bool object_is_editable = false;

    public bool is_moving = false;
    public bool is_rotating = false;
    internal bool is_custom = false;

    private void Start()
    {
        if (is_rotating && !is_moving)
        {
            is_rotating = false;
        }

        if (is_custom)
        {
            object_is_editable = true;
        }

        if (!is_rotating)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material.color = rend.material.color - new Color(0.3f, 0.3f, 0.3f);
            if (!is_moving)
            {
                rend.material.color = rend.material.color - new Color(0.15f, 0.15f, 0.15f);
            }
        }
    }

    void Update()
    {
        if (StartGame.game_is_start)
        {
            object_is_editable = false;
        }

        if (object_is_editable && is_moving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f, layerMask) && gameObject.tag == "Object")
            {
                transform.position = hit.point + new Vector3(0, 0.5f, 0);
            }
            else if (Physics.Raycast(ray, out hit, 1000f, layerMask) && gameObject.tag == "Plane")
            {
                transform.position = hit.point + new Vector3(0, 0.01f, 0);
            }

            if (is_custom)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    object_is_editable = false;
                    CountObjects.CounterPlus(gameObject.name.TrimEnd("(Clone)"));
                    Destroy(gameObject);
                }
            }

            float mw = Input.GetAxis("Mouse ScrollWheel");

            if (is_rotating && mw != 0)
            {
                transform.Rotate(Vector3.up * 150f * mw);
            }
        }
    }

    private void OnMouseDown()
    {
        if(!StartGame.game_is_start)
        {
            if (!object_is_editable)
            {
                object_is_editable = true;
            }

            else
            {
                object_is_editable = false;
            }
        }
    }
}
