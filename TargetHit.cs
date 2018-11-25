using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public int ScoreIncrease = 1;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
        //Debug.Log("OnTriggerEnter");
        Player player = GameObject.Find("Main Camera").GetComponent<Player>();
        player.IncreaseScore(ScoreIncrease);
        GameObject.Destroy(other.gameObject);
	}
}
