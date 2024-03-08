using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TimerImg : MonoBehaviour
{   
    public Sprite newSp;
    private Image img;
    private float currentTime;
    public float maxTime;
    public bool tick;

    void Start()
    {
        img = GetComponent<Image>();
        currentTime = maxTime;
        
    }

    
    void Update()
    {
        tick = false;
        currentTime -= Time.deltaTime;
        if (currentTime <= 0){
            currentTime = maxTime;
            tick = true;
        }
        img.fillAmount = currentTime/maxTime;
        
        
    }
    public void Ch(){
    
        img.sprite = newSp;
        img.color = Color.black;
         
    
    }
    public void ReStart(){
        currentTime = maxTime;
    }
}
