using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    public static Canvas authorsCanvas;
    public static Canvas menuCanvas;

    void Awake() {
        authorsCanvas = GameObject.Find("AuthorsCanvas").GetComponent<Canvas>();
        menuCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();

        authorsCanvas.enabled = false;
    }


    public void Play() {
        // TODO: switch to game scene
    }

    public void ShowAuthors() {
        menuCanvas.enabled = false;
        authorsCanvas.enabled = true;
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void QuitAuthors() {
        menuCanvas.enabled = true;
        authorsCanvas.enabled = false;
    }
}
