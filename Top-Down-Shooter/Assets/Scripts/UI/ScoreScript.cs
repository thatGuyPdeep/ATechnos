using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;

    public Text score;
    //public TextMesh scoreTMP;
    

    void Start()
    {
        score = GetComponent<Text>();
        //scoreTMP = GetComponent<TextMesh>();
    }

    void Update()
    {
        score.text = "Score: " + scoreValue;
        //scoreTMP.text = "Score:" + scoreValue;
    }
}
