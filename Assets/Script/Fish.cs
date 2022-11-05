using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb; // degisken tanimlandi
    [SerializeField]
    private float _speed;
    int angle;
    int maxAngle = 20;
    int minAngle =-60;
    public Score score;
    bool touchedGround;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer _sr;
    Animator anim;
    public ObstacleSpawner obstaclespawner;
    [SerializeField] private AudioSource swimSource, hitSource, pointSource;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Rigidbody2d component ini aktardik
        _rb.gravityScale = 0;
        _sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        FishSwim();
       

    }

     private void FixedUpdate() 
    {
         FishRotation();
    }

    void FishSwim()
    {
         if(Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            swimSource.Play();
            if(GameManager.gameStarted == false)
            {
              _rb.gravityScale = 4f;
              _rb.velocity = Vector2.zero;
              _rb.velocity = new Vector2(_rb.velocity.x, _speed);
              obstaclespawner.InstantLateObstacle();
              gameManager.GameHasStarted();
            }
            else 
            {
               _rb.velocity = Vector2.zero;
               _rb.velocity = new Vector2(_rb.velocity.x,_speed); // Fish move
            }

         
        }
    }

    void FishRotation()
    {
        
        if(_rb.velocity.y>0)
        {
           if(angle<=maxAngle)
           {
              angle=angle+4;
           }
        }else if(_rb.velocity.y<-1.2)
        {
            if(angle>minAngle)
            {
                angle = angle-2;
            }
        }

        if(touchedGround == false)
        {
           transform.rotation=Quaternion.Euler(0,0,angle);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Obstacle"))
        {
           score.Scored();
           pointSource.Play();
        }
        else if(collision.CompareTag("Column") && GameManager.gameOver == false)
        {
           //gameover
           FishDieEffects();
           gameManager.GameOver();
        }
    }

    void FishDieEffects()
    {
        hitSource.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            if(GameManager.gameOver == false)
            {
                //gameover
                FishDieEffects();
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                // gameover
                GameOver();
            }
        }
    }

    void GameOver()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        _sr.sprite = fishDied;
        anim.enabled = false;
    }
}
