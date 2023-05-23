using UnityEngine;
using UnityEngine.AI;

public class AgentAnimationController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    private void Start()
    {
        // Get the Animator and NavMeshAgent components
        animator = GameObject.Find("Figurine").GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Get the agent's velocity magnitude
        float velocityMagnitude = agent.velocity.magnitude;

        // Set the "Speed" parameter in the Animator Controller based on the agent's velocity
        animator.SetFloat("Speed", velocityMagnitude);

        // Check if the agent has reached its destination
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // Set the "IsWalking" parameter to false to transition back to Idle state
            animator.SetBool("IsWalking", false);
        }
        else
        {
            // Set the "IsWalking" parameter to true to transition to Walking state
            animator.SetBool("IsWalking", true);
        }
    }
}