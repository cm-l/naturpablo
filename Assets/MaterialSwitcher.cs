using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    public Material targetMaterial;

    private void Start()
    {
        SwitchMaterial(targetMaterial);
    }

    public void SwitchMaterial(Material targetMaterial)
    {
        // Get all child objects of the current GameObject
        Transform[] children = GetComponentsInChildren<Transform>();

        // Iterate through each child object
        foreach (Transform child in children)
        {
            // Check if the child has a MeshRenderer component
            MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                // Set the material of the child's MeshRenderer component to the target material
                meshRenderer.material = targetMaterial;
            }
        }
    }
}