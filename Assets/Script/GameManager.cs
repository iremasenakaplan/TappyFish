using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static Vector2 buttonLeft;

   private void Awake() 
   {
    buttonLeft=Camera.main.ScreenToWorldPoint(new Vector2(0,0)); //sol alt kose
   }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
