using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static ToggleEnumState;

public class ToggleEnumState : MonoBehaviour, IPointerClickHandler 
{
    GameObject[] buildToolbarOptions;
    private AudioSource selectClick;
    private AudioSource deselectClick;

    public enum State
    {
        show,
        hide,
    }
    public GameObject childTextObject;
    public State state;
   
    public void Start()
    {
        buildToolbarOptions = GameObject.FindGameObjectsWithTag("buildToolbarOption");

        state = State.hide;
        
        //childToggleObject = transform.GetChild(1).gameObject;

        if (state == State.hide)
        {
            childTextObject.SetActive(false);
        }
        if (state == State.show)
        {
            childTextObject.SetActive(true);
        }
    }
    private void Awake()
    {
        selectClick = GameObject.Find("selectAudio").GetComponent<AudioSource>();
        deselectClick = GameObject.Find("de-selectAudio").GetComponent<AudioSource>();
    }


    void Update()
    {
       
        
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        /*
        if ((state == State.hide) && (gameObject.name == "houseImage(FBM)"))
        {
            childTextObject.SetActive(false);
            gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 100);
            state = State.show;
        }
        else if ((state == State.show) && (gameObject.name == "houseImage(FBM)"))
        {
            childTextObject.SetActive(true);
            gameObject.GetComponent<Image>().color = new Color32(66, 188, 236, 100);
            state = State.hide;
        }
        */
        if (state == State.show)
        {
            childTextObject.SetActive(false);
            gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 100);
            state = State.hide;
            deselectClick.Play();
        }
        else if (state == State.hide)
        {
            foreach (GameObject go in buildToolbarOptions) 
            {
                go.GetComponent<ToggleEnumState>().setEnumHide(); //Deselect all other menu options before selcting a new one
                go.GetComponent<Image>().color = new Color(255, 255, 255, 100);
            }
            childTextObject.SetActive(true);
            gameObject.GetComponent<Image>().color = new Color32(66, 188, 236, 100);
            state = State.show;
            selectClick.Play();
        }
    }
    private void setEnumHide()
    {
        state = State.hide;
        childTextObject.SetActive(false);
    }
    private void setEnumshow()
    {
        state = State.show;
        childTextObject.SetActive(true);
    }



}
