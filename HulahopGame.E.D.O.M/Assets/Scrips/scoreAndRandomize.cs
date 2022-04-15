using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreAndRandomize : MonoBehaviour
{
    public ParticleSystem blockParticle;
   
    public GameObject hulahop;

   














    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player")
        {
          
            TrueBall.score += 50;
            
            Instantiate(blockParticle, transform.position, Quaternion.identity);
          


            TimerGameOver.countDownStartValue += 5;
            
            SpawnHulahop();

            Destroy(gameObject);

            
           
           

            
            

        }


    }

    
     
   //  private void Update()
   //{
   //  if( TrueBall.score >= 200)
   //   {

   //     transform.Rotate(0, 1, 0);
   //    transform.localEulerAngles = new Vector3(0,0,90); 

  //    }
  //   }


    private void SpawnHulahop()
    {
        bool hulaHopSwapwned = false;
        
        while (!hulaHopSwapwned)
        {
            Vector3 hulaHopPosition = new Vector3(Random.Range(-3.50f,2.61f), Random.Range(10.5f,-2.50f), 0.5f);
            if ((hulaHopPosition - transform.position).magnitude < 3)
            {
                continue;

            }
            else
            {
                
                Instantiate(hulahop, hulaHopPosition, Quaternion.identity);
                hulaHopSwapwned = true;
            }
        }
        
    }






}
