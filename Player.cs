using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Singleton<Player>//MonoBehaviour  // MAKE singleton
//public class Player : MonoBehaviour  // MAKE singleton
{
    public GameObject BallPrefab;
    public Vector3 BallOffset = new Vector3(0.5f, 0.5f, 0.5f); // offset from camera to create balls when throwing
    public int Score { get { return score; } }
    private int score;
    public List<GameObject> balls = new List<GameObject>();
    private int totalBalls = 1000;
    
   


    // Use this for initialization
    void Start () {
        score = 0;

        //create my List of balls

        for (int i = 0; i < totalBalls; i++)
			{
                GameObject newBall = (GameObject)GameObject.Instantiate(BallPrefab, this.transform.position + BallOffset, this.transform.rotation);
                newBall.SetActive(false);
                balls.Add(newBall);

			}


    }

    void FixedUpdate()
    {
        if (Time.frameCount % 2 == 0) // throw a ball every 2nd update (was 2 not 10)
            ThrowBall();
    }

    private void ThrowBall()
    {
        // throw ball
        //GameObject newBall = (GameObject)GameObject.Instantiate(BallPrefab, this.transform.position + BallOffset, this.transform.rotation);
        
        //Get ball
        for (int i = 0; i < balls.Count; i++)
        {
            if (!balls[i].activeInHierarchy)
            {
               // GameObject newBall = (GameObject)GameObject.Instantiate(BallPrefab, this.transform.position + BallOffset, this.transform.rotation);
                //newBall.SetActive(false);
                //balls.Add(newBall);

                balls[i].SetActive(true);

                // add some randomness to throw vector
                Vector3 randVec = Random.insideUnitSphere;
                randVec.y *= 0.1f;
                // combine basic throw vector with randomness
                Vector3 throwVector = (new Vector3(-2f, 0.2f, 0f) + randVec) * 1400f;
                balls[i].GetComponent<Rigidbody>().AddForce(throwVector);



            }
        }




        
    }


    /// <summary>
    /// this shoudl be in the Game Manager part of th eprogram??
    /// </summary>
    /// <param name="scoreChange"></param>
    public void IncreaseScore(int scoreChange)
    {
        score += scoreChange;
        GameManager.Instance.Score = score;
        LevelUp();//(score);
        //GameManager.Instance.Level = 111;
    }

   public void LevelUp()//int score)
   {

        // level (this would be part of the score /1000?  rounded down
        //GameManager.Instance.Level = 111;  //score / 1000;
        if (score / 1000 > GameManager.Instance.Level)
        {
            GameManager.Instance.Level = score / 1000;
        }
    }
}
