using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;
	[SerializeField] GameObject player;
	[SerializeField] Text currentScore;
	[SerializeField] Text highScore;
	[SerializeField] GameObject Gameover;
	public int score;

	void Awake ()
	{
		instance = this;
	}

	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		ShowScore ();
	}

	void ShowScore ()
	{
		PlayerPrefs.SetInt ("Score", score);
		currentScore.text = "Score " + score;
	}

	public void UpdateScore ()
	{
		score += 1;
		currentScore.text = "" + score;
	}

	public void GameOver ()
	{
		Gameover.SetActive (true);
		Sound.instance.sound.Stop ();
		int best = PlayerPrefs.GetInt ("Best: ", 0);
		if (best < score) {
			best = score;
			PlayerPrefs.SetInt ("Best: ", best);
		}
		highScore.text = "Best: " + best;
	}
}
