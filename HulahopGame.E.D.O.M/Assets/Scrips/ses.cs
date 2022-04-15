using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ses : MonoBehaviour
{
    public AudioSource ballDownSound;

    void Start()
    {

        ballDownSound = GetComponent<AudioSource>();


    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            ballDownSound.Play();


        }







    }
}
