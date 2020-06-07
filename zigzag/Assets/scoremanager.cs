using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoremanager : MonoBehaviour {

    public static scoremanager instance;
    public int score;
	public Text gameScore;
    public int highscore;
    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

	// Use this for initialization
	void Start () {
        score = 0;
        PlayerPrefs.SetInt("score", score);
	}
	
	// Update is called once per frame
	void Update () {
		gameScore.text = score.ToString ();
	}

    void incrementscore()
    {
        score += 1;
    }

    public void startscore()
    {
        InvokeRepeating("incrementscore", 0.1f, 0.5f);
    }

    public void stopscore()
    {
        CancelInvoke("incrementscore");
        PlayerPrefs.SetInt("score", score);
        if (PlayerPrefs.HasKey("highscore"))
        {
            if (score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
