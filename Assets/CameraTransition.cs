using UnityEngine;
using Cinemachine;

public class CameraTransition : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float zoomedInDistance = 5f;

    private CinemachineFramingTransposer framingTransposer;
    private float defaultDistance;

    public GameObject pabloNav;

    private void Start()
    {
        pabloNav = GameObject.Find("Pablo Navigator");

        // Ensure the CinemachineVirtualCamera component is assigned to the script
        if (virtualCamera == null)
        {
            virtualCamera = Camera.main.GetComponent<CinemachineVirtualCamera>();
        }

        // Get the Framing Transposer component from the virtual camera
        framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();

        // Store the default camera distance
        defaultDistance = framingTransposer.m_CameraDistance;
    }

    private void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits an object
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Interactable"))
                {
                    if (Vector3.Distance(transform.position, pabloNav.transform.position) < gameObject.GetComponent<HowerEffect>().interactionRange)
                    {
                        // Switch the camera focus to the clicked object
                        virtualCamera.Follow = hit.transform;

                        // Position the camera at the position of the first child object
                        Transform firstChild = hit.transform.GetChild(0);
                        if (firstChild != null)
                        {
                            virtualCamera.transform.position = firstChild.position;

                            // Decrease the camera distance within the Framing Transposer
                            framingTransposer.m_CameraDistance = zoomedInDistance;

                            // Deadzone
                            framingTransposer.m_DeadZoneHeight = 0f;
                            framingTransposer.m_DeadZoneWidth = 0f;

                            //Interaction canvas
                            //QNA
                            if (gameObject.GetComponent<TriggerQnACanvas>() != null)
                            {
                                gameObject.GetComponent<TriggerQnACanvas>().TriggerClicked();
                            }
                        }
                    }
                }
            }
        }
    }

    public void OnTurnBackCam()
    {
        // Reset the camera distance when the script is disabled
        framingTransposer.m_CameraDistance = defaultDistance;
        framingTransposer.m_DeadZoneHeight = 0.25f;
        framingTransposer.m_DeadZoneWidth = 0.25f;

        //Back to Player
        virtualCamera.Follow = pabloNav.transform.GetChild(0).transform;
    }
}