using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    Text scoretext;
    [SerializeField] int scorePerHit = 15;

    // Start is called before the first frame update
    void Start()
    {
        scoretext = GetComponent<Text>();
        scoretext.text = score.ToString();
    }

    public void ScoreHit(int scorePerHit)
    {
        score += scorePerHit;
        scoretext.text = score.ToString();
    }
}
