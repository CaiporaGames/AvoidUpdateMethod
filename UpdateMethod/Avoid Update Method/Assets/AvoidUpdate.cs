using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidUpdate : MonoBehaviour
{

    

    //### First Method using a separeted update method to call "all"
    //the updates

    //Used with the SingleUpdate function. This code will run in the
    //update there.
    public void SomeExpensiveMethod()
    {
        Debug.Log("Some expensive method!");
    }







    //#### Second method using the Time.frameCount
   
    
    public float interval = 3;
    float time = 0;
    //This tecnique can be used with the SingleUpdate class.
    void Update()
    {   /*     
        time += Time.deltaTime;

        //Code without optimization.
        if (time <= 5)
        {
            Debug.Log("Expensive code here!");
        }
        //Code optimized for one expensive piece of code.
        if (Time.frameCount % interval == 0 && time <= 5)
        {
            Debug.Log("OPTIMIZADE CODE: Expensive code here!");
        }
        */

        /*
        //Code optimized for several expensive piece of code.
        if (Time.frameCount % interval == 0)
        {
            Debug.Log("OPTIMIZADE CODE: First piece expensive code here!");
        }
        else if (Time.frameCount % interval == 1)
        {
            Debug.Log("OPTIMIZADE CODE: Second piece expensive code here!");
        }
        else if (Time.frameCount % interval == 2)
        {
            Debug.Log("OPTIMIZADE CODE: Third piece expensive code here!");
        }*/
    }



    //### Third method. Use the coroutine to control the flux o code.
    //It runs less then the update function.
    float timer = 0;
    float maxTime = 5;
    private void Start()
    {
       StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        float perc = 0;
        float timer = 0;
        while (perc < 1)
        {
            yield return null;
            timer = timer + Time.deltaTime;
            perc = timer / maxTime;
            SomeExpensiveMethod();
        }
        Debug.Log("I will run once each 5 seconds!");
        StartCoroutine(Timer());
    }
}
