using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
public class Logic : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    public TimerImg timerS;
    public TimerImg timerW;
    public TimerImg timerE;
    public Text infoText;
    public int meal;
    public int warrior;
    public int enemy;
    public int peasant;

    public bool buttonP;
    public bool buttonW;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        infoText.text = $"{meal}\n{peasant}\n{warrior}\n{enemy}";
        SborMeal();
        TakeoverMeal();
        CheckedButtonP();
        CheckedButtonW();
        Attack();
    }

    public void NewPeasant(){
        if (meal-1 >= 0){
            peasant += 1;
            meal -=1;
        }
    }
    public void NewWarrior(){
        if (meal-2 >= 0){
            warrior += 1;
            meal -=2;
        }
    }
    void SborMeal(){
        if (timerS.tick == true){
            meal += 1*peasant; 
        }
        
    }
    void  TakeoverMeal(){

        if (timerE.tick == true){
            meal -= (1 * peasant + 2 * warrior); 
        }
        
    }
    void Attack(){
        if (timerW.tick == true){
            
            if (warrior - enemy < 0){
                if(peasant - 2*(enemy - warrior)<0){
                    warrior = 0;
                    peasant = 0;
                    Time.timeScale = 0;
                    gameOver.SetActive(true);
                }else{
                    peasant -= 2*(enemy - warrior);
                    warrior = 0;
                    enemy *= 2;
                }

            }else{
                warrior -= enemy;
                enemy *= 2;

            }

        }

    }
    public void Restart(){
        gameOver.SetActive(false);
        Time.timeScale = 1;
        infoText.text = "0\n0\n0\n0";
        meal = 5;
        warrior = 0;
        enemy = 1;
        peasant = 1;
        
        Time.timeScale = 1;

    }
    void CheckedButtonP()
    {
        if (meal - 1>=0)
        {
            buttonP = true;
        }else{
            buttonP = false;
        }
    }
    void CheckedButtonW()
    {
        if (meal - 2>=0)
        {
            buttonW = true;
        }else{
            buttonW = false;
        }
    }
}
