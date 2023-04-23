using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;
using GoogleMobileAds.Api;

public class Movement : MonoBehaviour
{


    private InterstitialAd interstitial;

    public int value;
    public int ID;
    public float xspeed;
    public float forcespeed;

    public GameObject nextcube;
    public Rigidbody rb;

    CubeController cubec;
   
    public int nextcubevalue;
    

    AudioSource collisionsound;
    AudioSource collisionsound1;

    float mass;

    ParticleSystem explosion;





    private void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-6800551873518899/8657500162";

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);



        this.interstitial.OnAdClosed += HandleOnAdClosed;


        void HandleOnAdClosed(object sender, EventArgs args)
        {
            SceneManager.LoadScene("EndScene");
        }





    }



    void Start()
    {



        nextcube.GetComponent<Rigidbody>().AddForce((Vector3.forward + Vector3.up) * 100);

        explosion = GameObject.FindGameObjectWithTag("explosion").GetComponent<ParticleSystem>();
        collisionsound = GameObject.FindGameObjectWithTag("sound").GetComponent<AudioSource>();
        collisionsound1 = GameObject.FindGameObjectWithTag("sound1").GetComponent<AudioSource>();
        ID = GetInstanceID();
        rb = GetComponent<Rigidbody>();
        cubec = FindObjectOfType<CubeController>();
        cubec = GetComponent<CubeController>();
        nextcubevalue = nextcube.GetComponent<Movement>().value;
        explosion.Stop();
        mass = rb.mass;
    }

    
    void Update()
    {

        

        float xinput = 0;
        float deltax = 0;
        float zlimit = transform.position.z;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            deltax = Input.GetTouch(0).deltaPosition.x;

        }

        xinput = transform.position.x + xspeed * deltax * Time.deltaTime;

        xinput = Mathf.Clamp(xinput, -2.1f, 2.1f);
        zlimit = Mathf.Clamp(zlimit, 7.57f, 12.9f);
        transform.position = new Vector3(xinput, transform.position.y, zlimit);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            rb.AddForce(Vector3.forward * forcespeed);



           
            



        }




    }

  

   



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("cube"))


         {

            rb.AddForce(Vector3.up * 50);
            rb.AddForce(Vector3.right * 50);



            if (collision.gameObject.TryGetComponent(out Movement cube))
            {

                if (cube.value != value)
                {
                    collisionsound.Play();
                    

                }

                if (cube.value == value)
                {
                    if (ID < cube.ID) return;
                    Destroy(this.gameObject);
                    Destroy(cube.gameObject);




                    if (nextcube != null)
                    {

                        GameObject temp = Instantiate(nextcube, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + 0.3f, transform.position.z + Random.Range(0.2f, 0.2f)), Quaternion.Euler(0, Random.Range(-10, 10),0));
                        
                        collisionsound1.Play();
                        explosion.Play();
                        Instantiate(explosion, transform.position, transform.rotation);
                        


                    }
                
                }
            }
        }




    }



    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Limit"))
        {
            xspeed = 0;
            forcespeed = 0;
        }

      

    } 
    

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Limit"))
        {

            
            
            SceneManager.LoadScene("EndScene");

        }
    }


}
