using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject canvasObject;
    public QnACanvasBehaviour qnACanvasBehaviour;
    public CameraTransition ct;

    public void ShowAnswer()
    {
        // Deleting button
        gameObject.SetActive(false);

        // Show answer canvas
        QnACanvasBehaviour.speechBubble.enabled = true;

        QnACanvasBehaviour.answerTMP.text = QnACanvasBehaviour.GetAnswer();
    }

    public void BackOutOfQnA()
    {
        canvasObject = GameObject.Find("Canvas");

        if (canvasObject != null)
        {
            //qnACanvasBehaviour = canvasObject.GetComponent<QnACanvasBehaviour>();
            QnACanvasBehaviour.TurnOffQACanvas();
        }

        //Browar to kontroluje xd potem sie zmieni
        ct = GameObject.Find("Stary Browar").GetComponent<CameraTransition>();
        ct.OnTurnBackCam();
    }
}