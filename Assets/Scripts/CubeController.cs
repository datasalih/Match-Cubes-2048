using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CubeController : MonoBehaviour
{
    public List<GameObject> cubes = new List<GameObject>();
    public Transform spawnpoint;
    Movement currentCube;
    public AudioSource clicksound;
    public Text scoretext;
    int score;
    public GameObject dragicon;
    bool touchenable = true;


   
    private void Start()
    {



       
        
            score += 2;
        

        
      
            



    }




    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            dragicon.SetActive(false);
        }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && touchenable == true)
        {
            touchenable = false;
            StartCoroutine(EnableTouch());
            
            
            clicksound.Play();
            if(touchenable==false)
            {
                score += currentCube.value;
            }
           
        }

        scoretext.text = score.ToString();

        PlayerPrefs.SetInt("score", score);



        if (score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", score);
        }


    }



    
    public Movement PickRandomCube()
    {
        GameObject temp = Instantiate(cubes[Random.Range(0, 4)], spawnpoint.position, Quaternion.identity);
        return temp.GetComponent<Movement>();
    }

    IEnumerator EnableTouch()
    {
        yield return new WaitForSeconds(1.3f);
        touchenable = true;
        currentCube = PickRandomCube();
        

    }
    

}


    


