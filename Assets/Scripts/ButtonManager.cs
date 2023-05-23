using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class ButtonManager : MonoBehaviour {

    public void ShowAnswer() {
        // Deleting button
        Destroy(gameObject);

        // Show answer canvas
        QnACanvasBehaviour.speechBubble.enabled = true;

        QnACanvasBehaviour.answerTMP.text = QnACanvasBehaviour.GetAnswer();
    }
}