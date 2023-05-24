using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landscape : MonoBehaviour
{
    [SerializeField]
    private Material[] materials;
    private int i;

    void Start()
    {
        gameObject.GetComponent<Renderer>().material = materials[i];
    }

    public void Downgrade()
    {
        if (i < 2)
        {
            gameObject.GetComponent<Renderer>().material = materials[++i];
        }
    }
}
