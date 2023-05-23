using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class QnACanvasBehaviour : MonoBehaviour
{
    public QuestionsSO qSO;
    public static string question;
    public static string answer;
    public static Image image;
    public static GameObject button;

    public static TextMeshProUGUI questionTMP;
    public static TextMeshProUGUI answerTMP;

    public static Canvas qaCanvas;
    public static Canvas speechBubble;

    public static bool isCanvasActivated;

    public string folderName = "DataBase/Questions";
    private QuestionsSO[] questions;
    private QuestionsSO desiredQuestion;

    private void Awake()
    {
        questionTMP = GameObject.Find("QuestionTMP").GetComponent<TextMeshProUGUI>();
        answerTMP = GameObject.Find("AnswerTMP").GetComponent<TextMeshProUGUI>();
        image = GameObject.Find("AttachedImage").GetComponent<Image>();
        button = GameObject.Find("ShowAnswerButton");

        speechBubble = GameObject.Find("SpeechBubbleCanvas").GetComponent<Canvas>();
        qaCanvas = GameObject.Find("QnA").GetComponent<Canvas>();
        qaCanvas.enabled = false;
    }

    public void LoadQuestions()
    {
        questions = Resources.LoadAll<QuestionsSO>(folderName);
    }

    public void ShowQuestionAndAnswer()
    {
        qSO = desiredQuestion;

        question = qSO.question;
        answer = qSO.answer;
        image.sprite = qSO.img;

        questionTMP.text = question;
    }

    public void FindProperQA(string TriggerObjectName)
    {
        desiredQuestion = null;

        foreach (QuestionsSO q in questions)
        {
            if (q.objectName.Equals(TriggerObjectName))
            {
                desiredQuestion = q;
                break;
            }
        }
    }

    public static string GetAnswer()
    {
        return answer;
    }

    public static void TurnOnQACanvas()
    {
        qaCanvas.enabled = true;
        isCanvasActivated = true;
        speechBubble.enabled = false;
        button.SetActive(true);
    }

    public static void TurnOffQACanvas()
    {
        qaCanvas.enabled = false;
        isCanvasActivated = false;
        speechBubble.enabled = false;
    }
}