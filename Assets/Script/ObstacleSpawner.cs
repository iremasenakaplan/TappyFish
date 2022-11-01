using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float maxTime;
    float timer;
    public float maxY;
    public float minY;
    float randomY;


    void Start()
    {
        InstantLateObstacle();
    }

    
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= maxTime)
        {
           randomY = Random.Range(minY,maxY);
           InstantLateObstacle();
           timer = 0;
        }
    }

    public void InstantLateObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x,randomY);
    }
}
