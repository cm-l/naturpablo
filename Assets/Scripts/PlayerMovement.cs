using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Start()
    {
        // Get the NavMeshAgent component attached to the player GameObject
        agent = transform.parent.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits a valid NavMesh surface
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("nav"))
            {
                // Move the player to the clicked position on the NavMesh
                agent.SetDestination(hit.point);
            }
        }
    }
}