using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CountObjects : MonoBehaviour
{
    public int cube_count;
    public int triangle_count;
    public int soft_cube_count;
    public int slime_cube_count;
    public int triangle_up_count;
    public int speed_plane_count;
    public int speed_point_count;

    private static Dictionary<string, int> name_dict;

    private void Start()
    {
        FillingDict();
    }

    private void FillingDict()
    {
        name_dict = new Dictionary<string, int>()
        {
            {"Cube",  cube_count},
            {"Triangle",  triangle_count},
            {"TriangleUp",  triangle_up_count},
            {"SoftCube",  soft_cube_count},
            {"SlimeCube",  slime_cube_count},
            {"SpeedPlane",  speed_plane_count},
            {"SpeedPoint",  speed_point_count},
        };
    }

    public static bool CounterMinus(string name)
    {
        if (name_dict[name] > 0)
        {
            name_dict[name]--;
            return true;
        }
        else return false;
    }

    public static void CounterPlus(string name)
    {
        name_dict[name]++;
    }

    public static int Count(string name)
    {
        return name_dict[name];
    } 
}
