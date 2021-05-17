using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Text txt;
    public SpriteRenderer spriteRen; 
    public float ySpeed = 0f;
    [Range(-2, 2)] public int movement;
    public float dodgeSpeed = 10f;
    public GameObject explosion;
    public AudioClip coinSound;
    public AudioClip explosionSound;
    public AudioSource audioPlayer;

    private static float yPos;
    private float x;

    void start()
    {   
        txt = GetComponent<Text>();
        rb = this.GetComponent<Rigidbody2D>();
        spriteRen = this.GetComponent<SpriteRenderer>();
    }

    private int coinCounter = 0;
    public GameObject gameOverScreen;
    public GameObject gamePlayScreeen;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "coin")
        {
            Destroy(col.gameObject);
            coinCounter += 1;
            if(PlayerPrefs.GetInt("EffectsSounds", 0) == 0)
            {
                audioPlayer.PlayOneShot(coinSound);
            }
        }

        if(col.gameObject.tag == "Enemy")
        {
            gameOverScreen.SetActive(true);
            gamePlayScreeen.SetActive(false);
            ySpeed = 0f;
            if(PlayerPrefs.GetInt("EffectsSounds", 0) == 0)
            {
                audioPlayer.PlayOneShot(explosionSound);
            }
            explosion.SetActive(true);
            spriteRen.enabled = false;
        }
    }

    void FixedUpdate()
    {   
        Vector2 yForce = new Vector2 (0, ySpeed);
        rb.velocity = new Vector2(0f, ySpeed) * Time.deltaTime;

        x = Mathf.Lerp(x, movement, dodgeSpeed * Time.deltaTime);
        transform.position = new Vector2(x, transform.position.y);
        yPos = Mathf.RoundToInt(transform.position.y);

        txt.text = "Score \n" + yPos.ToString();
    }

    public GameObject camara;

    public void LateUpdate()
    {  
        SwipeControl();

        if(Input.GetKeyUp("left"))
        {
            if(movement == -2)
                return;
            movement -= 2;
        }   
        if(Input.GetKeyUp("right"))
        {
            if(movement == 2)
                return;
            movement += 2;
        }

        camara.transform.position = new Vector3(0f, gameObject.transform.position.y + 4f , -10f);
    }

    private int swipeRange = 50;
    private Vector2 Distance;

    private Vector2 startPos;
    private Vector2 currentPos;
    private Vector2 endPos;
    private bool stopTouch = true;

    public void SwipeControl()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startPos = Input.GetTouch(0).position;
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPos = Input.GetTouch(0).position;
            Distance = currentPos - startPos;
        }

        if(!stopTouch)
        {
            if(Distance.x <= -swipeRange)
            {
                if(movement == -2)
                    return;

                movement -= 2;
                stopTouch = true;
            }
            if(Distance.x >= swipeRange)
            {   
                if(movement == 2)
                    return;

                movement += 2;
                stopTouch = true;
            }
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
        }
    }
}
