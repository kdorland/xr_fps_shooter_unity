using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int totalScore;

    // Use this for initialization  
    public void Start() {
        totalScore = 0;
    }

    // Add score to totalScore
    public void AddScore(int points) {
        print("Score Updated");
        totalScore += points;
    }

    // Update GUI
    private void OnGUI() {
        GUI.Label(new Rect(10, 10, 200, 20), "Score: " + totalScore);
    }
}
