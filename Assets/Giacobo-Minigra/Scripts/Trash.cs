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
    private Material[] paper, plastic, glass, bio;
    private SphereCollider coll;

    void Start()
    {
        segregationManager = GameObject.FindGameObjectWithTag("SegregationManager").GetComponent<SegregationManager>(); 
        type = Random.Range(1, 5);
        ChangeMaterial();
        Debug.Log(type);
        coll = gameObject.AddComponent<SphereCollider>();
        coll.isTrigger = true;
    }

    private void ChangeMaterial()
    {
        if (type == 1)
        {
            gameObject.GetComponent<Renderer>().material = paper[Random.Range(0, paper.Length)];
        }
        else if (type == 2)
        {
            gameObject.GetComponent<Renderer>().material = plastic[Random.Range(0, plastic.Length)];
        }
        else if (type == 3)
        {
            gameObject.GetComponent<Renderer>().material = glass[Random.Range(0, glass.Length)];
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = bio[Random.Range(0, bio.Length)];
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
            else if (other.gameObject.GetComponent<Bin>().type != type && canGetPoint == true)
            {
                Debug.Log(other.gameObject.GetComponent<Bin>().type + "!=" + type);
                segregationManager.SubtractPoint();
                canGetPoint = false;
            }

            Destroy(gameObject);
        }
    }
}
