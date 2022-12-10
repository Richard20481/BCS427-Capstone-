using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarScript : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 dest;
    float value = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = this.dest;
        agent.enabled = true;
        StartCoroutine(Die());
    }
    public void SetDest(Vector3 dest, float value)
    {
        this.dest = dest;
        this.value = value;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, agent.destination) <= .5f)
        {
            StartCoroutine(ConfirmDest());
        }
    }
    IEnumerator ConfirmDest()
    {
        yield return new WaitForSeconds(1);
        if (Vector3.Distance(transform.position, agent.destination) <= .4f)
        {
            GameManager.gm.addMoney(value);
            Destroy(gameObject);
        }

    }
        IEnumerator Die()
    {
        //play your sound
        yield return new WaitForSeconds(30); 
        Destroy(gameObject); 
    }
}
