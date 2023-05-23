using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class TriggerQnACanvas : MonoBehaviour {

    private QnACanvasBehaviour qnACanvasBehaviour;
    GameObject canvasObject;

    void Start() {
        canvasObject = GameObject.Find("Canvas");

        if (canvasObject != null) {
            qnACanvasBehaviour = canvasObject.GetComponent<QnACanvasBehaviour>();
        }
    }

    public void TriggerClicked() {
        QnACanvasBehaviour.TurnOnQACanvas();

        string objectName = gameObject.name;

        qnACanvasBehaviour.LoadQuestions();
        qnACanvasBehaviour.FindProperQA(objectName);
        qnACanvasBehaviour.ShowQuestionAndAnswer();
    }
}
