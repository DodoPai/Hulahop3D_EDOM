using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]


public class Ball : MonoBehaviour
{
 



    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;
    public static int score;

    private bool isShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        

        
       

    }
   
    
    private void OnMouseDown()
    {
       
        mousePressDownPos = Input.mousePosition;

    }

    private void OnMouseUp()
    {
      
        mouseReleasePos = Input.mousePosition;
        Shoot(Force: mousePressDownPos - mouseReleasePos);

    }
    private float forceMultiplier = 3;

    void Shoot(Vector3 Force)
    {
        if (isShoot)
            return;
        rb.AddForce(new Vector3(Force.x,Force.y,z:Force.y) * forceMultiplier);
        isShoot = true;
        Spawner.Instance.NewSpawnRequest();
    }




 










}
