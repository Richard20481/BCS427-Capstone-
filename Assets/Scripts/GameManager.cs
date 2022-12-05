using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    /**
     * Public attributes game objects.
     */
    public static GameManager gm;
    public Light sun;

    /**
     * Public attributes primitives.
     */
    public float Income = 0.0f;
    public float Expense = 0.0f;
    public float Money = 0.0f;
    private float Happiness = 0;
    public int Population;
    public bool Bankrupt = false;

    /**
     * Private attributes primitives.
     */
    private float FrameTime = 0;
    private int day = 0;
    private int time = 1;
    

    //public Rigidbody rb;
    public TMPro.TextMeshProUGUI moneyTextFloat;
    public TMPro.TextMeshProUGUI populationTextFloat;
    public TMPro.TextMeshProUGUI dayTextFloat;
    public TMPro.TextMeshProUGUI happinessTextFloat;

    public WindowGraph moneyGraph;
    public WindowGraph populationGraph;


    void Start()
    {

        /**
         * Sets the attributes.
         */
        this.setIncome(this.Income);
        this.setExpense(this.Expense);
        this.setMoney(this.Money);

        this.sun.enabled = true;
        

        this.Bankrupt = false;
        if (gm != null) gm = this.gameObject.GetComponent<GameManager>();


        
        populationTextFloat.text = "" + this.Population;
        dayTextFloat.text = "Day: " + this.day;
        happinessTextFloat.text = this.Happiness + "%";
    }

    /**
     * Update.
     */
    void Update()
    {

        if (this.FrameTime >= 1.0f)
        {
            if (this.time >= 360)
            {
                NewDay();
                this.time -= 360;
            }
            this.sun.transform.rotation = Quaternion.Euler(new Vector3(this.time+=32, 0, 0));
            addMoney(this.Income - this.Expense);
            this.FrameTime = 0.0f;

            
        }

        this.FrameTime += Time.deltaTime;
    }

    private void NewDay()
    {
        this.day++;
        moneyGraph.AddValue((int)this.Money);
        populationGraph.AddValue((int)this.Population);
        dayTextFloat.text = "Day: " + this.day;
    }

    /**
     * GameOver methoid.
     */
    private void GameOver()
    {


    }
    
    /**
     * Setter for the Income.
     */
    public void setIncome(float Income = 0.0f)
    {

        this.Income = (Income < 0.0f) ? 0.0f : Income;
    }

    /**
     * Setter for the Expances.
     */
    public void setExpense(float Expense = 0.0f)
    {

        this.Expense = (Expense < 0.0f) ? 0.0f : Expense;
    }

    /**
     * Setter for the Money.
     */
    public void setMoney(float Money = 0.0f)
    {

        this.Money = (Money < 0.0f) ? 0.0f : Money;
        moneyTextFloat.text = "" + this.Money;
    }
    public void addMoney(float Money = 0.0f)
    {

        this.Money += Money;
        moneyTextFloat.text = "" + this.Money;
    }

    /**
     * Converts gameManager object to a string.
     */
    public string toString()
    {

        return "";
    }
}