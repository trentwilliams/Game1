using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour {

    [SerializeField]
    private Text timerLabel;

    [SerializeField]
    private Text scoreLabel;

    [SerializeField]
    private Text levelLabel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        timerLabel.text = FormatTime(GameManager.Instance.TimePassed);
        scoreLabel.text = GameManager.Instance.Score.ToString();
        levelLabel.text = GameManager.Instance.Level.ToString();
    }


    private string FormatTime(float timeInSeconds)
    {
	return string.Format("{0}:{1:00}", Mathf.FloorToInt(timeInSeconds/60), Mathf.FloorToInt(timeInSeconds % 60));
	}
}
