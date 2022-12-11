using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public float score = 0;

    // Start is called before the first frame update
    void Start()
    {   
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = score.ToString("0");
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
