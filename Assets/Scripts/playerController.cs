using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// Should put Script inside main camera
public class playerController : MonoBehaviour
{
    //public Rigidbody rb;
    public TMPro.TextMeshProUGUI moneyTextFloat;
    public TMPro.TextMeshProUGUI populationTextFloat;
    public TMPro.TextMeshProUGUI dayTextFloat;
    public TMPro.TextMeshProUGUI happinessTextFloat;
    public int money = 0;
    public float speed = 3.0f;
    public int population = 10;
    public int day = 0;   
    public int avgHappiness = 66;
   
    
  

    // Start is called before the first frame update
    void Start()
    {
        moneyTextFloat.text = "" + money;
        populationTextFloat.text = "" + population;
        dayTextFloat.text = "Day: " + day;
        happinessTextFloat.text = avgHappiness + "%";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Input.GetKeyDown("space")
        {
            money += 1;
            moneyTextFloat.text = ""+money;
        }
         
    
    }
    public void addMoney()
    {
        money += 10;
        moneyTextFloat.text = "" + money;
    }
    
}
