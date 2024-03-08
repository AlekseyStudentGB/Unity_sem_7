using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class NewBehaviourScript : MonoBehaviour
    
{
    public float maxTime;
    private Image img;
    private AudioSource audi;
    private float currentTime;
    private bool x = false;
    public Button button;
    
    public Logic logic;
    
    void Start()
    {
        img = GetComponent<Image>();
        audi = GetComponent<AudioSource>(); 
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.buttonP == false & x == false)
            {
                button.interactable = false;
            }else{
                button.interactable = true;
                }
        
        if (x == true){
            currentTime += Time.deltaTime;
            if (currentTime/maxTime < 1){
                img.fillAmount = currentTime/maxTime;
                button.interactable = false;
                

            }else{
                img.fillAmount = 1;
                x = false; 
                button.interactable = true;
                currentTime = 0;
            }
        }

    }
    public void clicKReloud(){
        x = true;
        audi.Play();


    }
}
