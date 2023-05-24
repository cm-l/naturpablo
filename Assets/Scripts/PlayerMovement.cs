using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject QnA;

    public AudioClip musicThing;

    private void Start()
    {
        // Get the NavMeshAgent component attached to the player GameObject
        agent = transform.parent.GetComponent<NavMeshAgent>();

        //Get QnA panel thingy
        QnA = GameObject.Find("QnA");

        SoundSystemSingleton.Instance.PlayMusicSound(musicThing);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !QnACanvasBehaviour.isCanvasActivated)
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