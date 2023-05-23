using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField]
    public int type;
    public SegregationManager segregationManager;
    private Vector3 mOffset;
    private float mZCoord;
    private bool canGetPoint = true;
    [SerializeField]
    private Material[] materials;

    void Start()
    {
        segregationManager = GameObject.FindGameObjectWithTag("SegregationManager").GetComponent<SegregationManager>();
        type = Random.Range(1, 5);
        ChangeMaterial();
    }

    private void ChangeMaterial()
    {
        if (type == 1)
        {
            gameObject.GetComponent<Renderer>().material = materials[Random.Range(0, 2)];
        }
        else if (type == 2)
        {
            gameObject.GetComponent<Renderer>().material = materials[Random.Range(2, 4)];
        }
        else if (type == 3)
        {
            gameObject.GetComponent<Renderer>().material = materials[Random.Range(4, 6)];
        }
        else if (type == 4)
        {
            gameObject.GetComponent<Renderer>().material = materials[Random.Range(6, 8)];
        }
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bin"))
        {
            if (other.gameObject.GetComponent<Bin>().type == type && canGetPoint == true)
            {
                segregationManager.AddPoint();
                canGetPoint = false;
            }
            else if (other.gameObject.GetComponent<Bin>().type == type && canGetPoint == true)
            {
                segregationManager.SubtractPoint();
            }

            Debug.Log(type);
            Destroy(gameObject);
        }
    }
}
