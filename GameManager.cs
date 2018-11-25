using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    private float _timePassed;

    public float TimePassed
    {
        get { return _timePassed; }
        set { _timePassed = value; }
    }

    public float maxTimeSeconds = 5 * 60; // In seconds.



    public float Score{ get; set;}
    public float Level { get; set; }




    void Start()
    {
        TimePassed = 0;
    }

    void Update()
    {
        TimePassed += Time.deltaTime;

        // reset game at 60 seconds (max time)
        if (TimePassed >= maxTimeSeconds)
        {
            TimePassed = 0; // maxTimeSeconds;
            Score = 0;

            SceneManager.LoadScene(0);
        }
    }
}


