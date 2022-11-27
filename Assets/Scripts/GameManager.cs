using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    /**
     * Public attributes.
     */
    public static GameManager gm;

    public float Income = 0.0f;
    public float Expense = 0.0f;
    public float Money = 0.0f;
    public bool Bankrupt = false;

    /**
     * Private attributes.
     */
    private float FrameTime = 0;

    /**
     * Start is called before the first frame update.
     */
    void Start(){

        /**
         * Sets the attributes.
         */
        this.setIncome(this.Income);
        this.setExpense(this.Expense);
        this.setMoney(this.Money);

        this.Bankrupt = false;

        if(gm != null) gm = this.gameObject.GetComponent<GameManager>();
    }

    /**
     * Update.
     */
    void Update(){

        if(this.FrameTime >= 1.0f){

            this.Money += (this.Income - this.Expense);
            this.FrameTime = 0.0f;

            print("\n" + this.Money);
        }
        
        this.FrameTime += Time.deltaTime;
    }

    /**
     * GameOver methoid.
     */
    private void GameOver(){


    }

    /**
     * Setter for the Income.
     */
    public void setIncome(float Income = 0.0f){

        this.Income = (Income < 0.0f) ? 0.0f : Income;
    }

    /**
     * Setter for the Expances.
     */
    public void setExpense(float Expense = 0.0f){

        this.Expense = (Expense < 0.0f) ? 0.0f : Expense;
    }

    /**
     * Setter for the Money.
     */
    public void setMoney(float Money = 0.0f){

        this.Money = (Money < 0.0f) ? 0.0f : Money;
    }

    /**
     * Converts gameManager object to a string.
     */
    public string toString(){

        return "";
    }
}
