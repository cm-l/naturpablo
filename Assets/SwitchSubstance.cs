using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSubstance : MonoBehaviour
{
    public Material[] materialList;
    private int currentIndex = 0;

    private MaterialSwitcher ms;
    public AudioClip switchSound;

    public float squishDuration = 0.2f;
    public float squishScale = 0.8f;

    public void Start()
    {
        ms = GameObject.Find("Figurine").GetComponent<MaterialSwitcher>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if the right mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            Switcher();
        }
    }

    private void Switcher()
    {
        // Increase the index and wrap around if necessary
        currentIndex = (currentIndex + 1) % materialList.Length;

        // Call the SwitchMaterial function with the current material from the list
        ms.SwitchMaterial(materialList[currentIndex]);

        // Sound
        SoundSystemSingleton.Instance.PlaySfxSound(switchSound);

        // Store the original scale
        Vector3 originalScale = new Vector3(1, 1, 1);

        // Apply the squish effect using LeanTween
        LeanTween.scale(gameObject, originalScale * squishScale, squishDuration)
            .setEase(LeanTweenType.easeInQuad)
            .setLoopPingPong(1)
            .setOnComplete(() =>
            {
                // Restore the original scale
                LeanTween.scale(gameObject, originalScale, squishDuration)
                    .setEase(LeanTweenType.easeOutElastic);
            });
    }
}