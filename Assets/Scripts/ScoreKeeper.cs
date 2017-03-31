using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	static int score;
	private Text uiText;
	
	void Start() {
		score = 0;
		uiText = GetComponent<Text>();
	}
	
	public void addPoints(int points) {
		score += points;
		updateUI();
	}
	
	public void reset() {
		score = 0;
		updateUI();
	}
	
	private void updateUI() {
		uiText.text = score.ToString();
	}
}
