using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SegregationManager : MonoBehaviour
{
    public GameObject trash, trashPrefab;
    public GameObject[] bin;
    public int points, actions;
    public TextMeshProUGUI score;
    private Landscape landscape;

    void Start()
    {
        ChangeScoreDisplay();
        landscape = GameObject.FindGameObjectWithTag("Landscape").GetComponent<Landscape>();
    }

    void Update()
    {
        if (trash == null)
        {
            trash = Instantiate(trashPrefab, new Vector3(Random.Range(-2f, 2f), 2f, -5.75f), transform.rotation * Quaternion.Euler(90f, 180f, 0f));
        }
    }

    public void AddPoint()
    {
        actions++;
        points++;
        //Debug.Log(points);
        ChangeScoreDisplay();
        CheckScore();
    }

    public void SubtractPoint()
    {
        actions++;
        points--;
        //Debug.Log(points);
        ChangeScoreDisplay();
        CheckScore();
        landscape.Downgrade();
    }

    void ChangeScoreDisplay()
    {
        score.text = "Score: " + points.ToString();
    }

    void CheckScore()
    {
        if (actions > 2)
        {
            score.text = "End!";
        }
    }
}
