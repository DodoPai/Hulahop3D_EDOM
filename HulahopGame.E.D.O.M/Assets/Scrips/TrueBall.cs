using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TrueBall : MonoBehaviour
{
    //LineRenderer
    Camera camera;
    [SerializeField] LineRenderer lr;
    Vector3 camOffset = new Vector3(0, 0, 5);


    public ParticleSystem ballParitcle;

    public float rotateSpeed = 1;
    public AudioSource hulahopSound;
    
    public static int score;
    public Text scoreText;

    public static bool isBallDown;
    public GameObject badBoyimage;


    public int ballJump;
    public Text jumpText;
    public bool isballjump;


    private float ballScorePosition;


    private Vector3 startPosition;
    private Vector3 endPosition;

    private Vector3 startBallPosition;

    public float force = 1000f;

    private Rigidbody ballpyhsics;



    private void Awake()
    {
        camera = Camera.main;
        ballpyhsics = GetComponent<Rigidbody>();
    }

   
    void Start()
    {

           badBoyimage.SetActive(false);
           isBallDown = false;
        hulahopSound = GetComponent<AudioSource>();

        score = 0;
        isballjump = false;
        ballpyhsics.isKinematic = true;
        startBallPosition  = transform.position;  //topu ilk konumuna getiridk.
        
    }

   
    void Update()
    {
        

        scoreText.text = "Score: " + score;
        jumpText.text = "Jump: " + ballJump;
        SpinBall();
        if (Input.GetMouseButtonDown(0))
        {
            if(lr ==null)
            {
                lr = gameObject.AddComponent<LineRenderer>();
            }
            lr.enabled = true;
            lr.positionCount = 2;
            startPosition = camera.ScreenToViewportPoint(Input.mousePosition);
            lr.SetPosition(0, startPosition);
            lr.useWorldSpace = true;
            

            startPosition = getMousePosition();
        }
        if(Input.GetMouseButton(0))
        {
            endPosition = camera.ScreenToViewportPoint(Input.mousePosition);
            lr.SetPosition(1, endPosition);
        }

        if(Input.GetMouseButtonUp(0))
        {
            lr.enabled= false;
            endPosition = getMousePosition();

            Vector2 power = startPosition- endPosition;
            ballpyhsics.isKinematic = false;

            ballpyhsics.AddForce(power * force, ForceMode.Force);
            isballjump = true;
            ballJump -= 1;

            if (ballJump == 0)
            {


                transform.position = startBallPosition;
                ballJump = 5;
                

            }


        }
        
    }
    private Vector3 getMousePosition()
    {
        return Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }
    void OnCollisionEnter(Collision collision)
    {
        


        if (!collision.gameObject.tag.Equals("ground")) return;


        
        ballpyhsics.isKinematic = true;

        isBallDown = true;
        badBoyimage.SetActive(true);
        StartCoroutine(RemoveAfterSeconds(0.75f, badBoyimage));

        Instantiate(badBoyimage, transform.position, Quaternion.identity);
        transform.position = startBallPosition;
        TimerGameOver.countDownStartValue -= 2;
        ballpyhsics.velocity = Vector3.zero; // hýzý 0 yaptýk.
        ballJump = 5;


    }
     IEnumerator RemoveAfterSeconds(float seconds,GameObject badBoyimage)
    {
     yield return new WaitForSeconds(seconds);
      badBoyimage.SetActive(false);
     }
    private void SpinBall()
    {
        transform.Rotate(0, 0, rotateSpeed, Space.World);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hulahop")
        {
            
            hulahopSound.Play();
        }
       

        ballScorePosition = transform.position.y;
        transform.position = startBallPosition;
        ballpyhsics.isKinematic = true;
        ballJump = 5;



    }
    private void OnTriggerExit(Collider other)
    {
        if (transform.position.y < ballScorePosition)
        {
            scoreText.text = "Score: " + score;
            score += 50;




        }
    }


  

}

