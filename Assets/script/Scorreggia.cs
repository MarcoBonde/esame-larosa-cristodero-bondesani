

using UnityEngine;
using UnityEngine.UI;

public class Scorreggia : MonoBehaviour //easter egg
{
    public Transform player;
    public Text scoreText;
    private float timer;
    private int score;

    void Update()
    {

        timer += Time.deltaTime;

        if (timer > 1f)
        {

            score += 1;

            //We only need to update the text if the score changed.
            scoreText.text = score.ToString();

            //Reset the timer to 0.
            timer = 0;
        }
    }
}

