using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreScene : MonoBehaviour
{
    public Text scoretext;
    public Text hihscoretext;

   

    void Start()
    {
        scoretext.text = PlayerPrefs.GetInt("score").ToString();
        hihscoretext.text = PlayerPrefs.GetInt("highscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
