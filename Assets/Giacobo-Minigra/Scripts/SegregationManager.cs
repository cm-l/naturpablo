using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SegregationManager : MonoBehaviour
{
    public GameObject trash, trashPrefab, landscapeGO, quasi;
    public GameObject[] bin;
    public int points, actions;

    //sounds
    public AudioClip positive;

    public AudioClip negative;

    //nwm co
    public CameraTransition ct;

    //public TextMeshProUGUI score;
    private Landscape landscape;

    private void Start()
    {
        //ChangeScoreDisplay();
        landscape = GameObject.FindGameObjectWithTag("Landscape").GetComponent<Landscape>();
    }

    private void Update()
    {
        if (trash == null)
        {
            //trash = Instantiate(trashPrefab, new Vector3(Random.Range(-2f, 2f), 2f, -9.75f), transform.rotation * Quaternion.Euler(90f, 0f, 0f));
            trash = Instantiate(trashPrefab, quasi.transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
        }
    }

    public void AddPoint()
    {
        actions++;
        points++;
        //Debug.Log(points);
        //ChangeScoreDisplay();
        CheckScore();

        SoundSystemSingleton.Instance.PlaySfxSound(positive);
    }

    public void SubtractPoint()
    {
        actions++;
        points--;
        //Debug.Log(points);
        //ChangeScoreDisplay();
        CheckScore();
        landscape.Downgrade();

        SoundSystemSingleton.Instance.PlaySfxSound(negative);
    }

    /*    void ChangeScoreDisplay()
        {
            score.text = "Score: " + points.ToString();
        }*/

    private void CheckScore()
    {
        if (actions > 2)
        {
            //End of the game
            //score.text = "End!";

            //pierdole
            //Browar to kontroluje xd potem sie zmieni
            ct = GameObject.Find("Stary Browar").GetComponent<CameraTransition>();
            ct.OnTurnBackCam();
        }
    }
}