using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static int score;
	private Text uiText;
	
	public void Start() {
		score = 0;
		uiText = GetComponent<Text>();
		reset ();
		updateUI();
	}
	
	public void addPoints(int points) {
		score += points;
		updateUI();
	}
	
	public static void reset() {
		score = 0;
	}
	
	private void updateUI() {
		uiText.text = score.ToString();
	}
}
