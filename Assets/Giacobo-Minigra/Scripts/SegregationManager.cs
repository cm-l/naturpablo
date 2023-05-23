using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SegregationManager : MonoBehaviour
{
    public GameObject trash, trashPrefab;
    public GameObject[] bin;
    public int points = 0;
    public TextMeshProUGUI score;

    void Start()
    {
        ChangeScoreDisplay();
    }

    void Update()
    {
        if (trash == null)
        {
            trash = Instantiate(trashPrefab, new Vector3(0, 1.5f, -5.75f), transform.rotation * Quaternion.Euler(90f, 180f, 0f));
        }
    }

    public void AddPoint()
    {
        points += 1;
        Debug.Log(points);
        ChangeScoreDisplay();
    }

    public void SubtractPoint()
    {
        points -= 1;
        Debug.Log(points);
        ChangeScoreDisplay();
    }

    void ChangeScoreDisplay()
    {
        score.text = "Score: " + points.ToString();
    }
}
