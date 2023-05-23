using UnityEngine;

public class HowerEffect : MonoBehaviour
{
    public Outline outline;
    public float hoverWidth = 8f;
    public float normalWidth = 0f;

    public GameObject pabloNav;

    private void Start()
    {
        // Ensure the Outline component is attached to the same GameObject
        outline = GetComponent<Outline>();
        pabloNav = GameObject.Find("Pablo Navigator");
    }

    private void Update()
    {
        //Check if item is in range
        if (Vector3.Distance(transform.position, pabloNav.transform.position) < 4f)
        {
            // Cast a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the object with the HoverEffect script
            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                // Set the outline width to the hover width
                if (outline != null)
                {
                    outline.OutlineWidth = hoverWidth;
                }
            }
            else
            {
                // Set the outline width back to the normal width
                if (outline != null)
                {
                    outline.OutlineWidth = normalWidth;
                }
            }
        }
    }
}