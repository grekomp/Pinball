using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour
{
    public bool isLighted = false;
    public Material on;
    public Material off;
    public GameObject bulb;

    public void Switch()
    {
        isLighted = !isLighted;
        bulb.GetComponent<MeshRenderer>().material = isLighted ? on : off;
    }
}
