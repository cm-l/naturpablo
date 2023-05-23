using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour {
    public static Canvas authorsCanvas;
    public static Canvas menuCanvas;

    [SerializeField] private AudioClip UIClick;

    void Awake() {
        authorsCanvas = GameObject.Find("AuthorsCanvas").GetComponent<Canvas>();
        menuCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();

        authorsCanvas.enabled = false;
    }


    public void Play() {
        // TODO: switch to game scene
        SoundSystemSingleton.Instance.PlaySfxSound(UIClick);
        SceneManager.LoadScene("PoznanPlane");
    }

    public void ShowAuthors() {
        menuCanvas.enabled = false;
        authorsCanvas.enabled = true;

        SoundSystemSingleton.Instance.PlaySfxSound(UIClick);
    }

    public void QuitGame() {
        SoundSystemSingleton.Instance.PlaySfxSound(UIClick);
        Application.Quit();
    }

    public void QuitAuthors() {
        menuCanvas.enabled = true;
        authorsCanvas.enabled = false;

        SoundSystemSingleton.Instance.PlaySfxSound(UIClick);
    }
}
