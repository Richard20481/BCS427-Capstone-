using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class WindowGraph : MonoBehaviour
{

    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private RectTransform xDashTemplate;
    private RectTransform yDashTemplate;

    List<GameObject> UIElements = new List<GameObject>();

    List<int> valueList = new() {0};
    int dayoffset = 0;

    bool isInit = false;
    private void Awake()
    {
        print("awake");
        graphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("xAxisLabelTemplate").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("yAxisLabelTemplate").GetComponent<RectTransform>();
        xDashTemplate = graphContainer.Find("xDashTemplate").GetComponent<RectTransform>();
        yDashTemplate = graphContainer.Find("yDashTemplate").GetComponent<RectTransform>();

        isInit = true;
        //CreateCircle(new Vector2(100,100)); //Places an example dot
         //Test values (if more thanten values then numbers will continue off right side of graph)
        showGraph(valueList);
    }
    public void AddValue(int value)
    {
        if (!isInit)
        {
            Awake();
        }
        
        if(valueList.Count >= 10)
        {
            valueList.RemoveAt(0);
            dayoffset += 1;
        }
        valueList.Add(value);
        showGraph(valueList);
    }

    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circleSprite", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(20, 20); //was 11, 11
        rectTransform.anchorMin = new Vector2(0,0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private void showGraph(List<int> valueList)
    {
        print(valueList.Count);
        for(int i = 0; i < UIElements.Count; i++)
        {
            Destroy(UIElements[i]);
        }


        
        UIElements.Clear();

        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 0f; //Top of graph was 300 (yMaximimum scales with value in list)
        float xSize = 50f; //Length of graph

        foreach (int value in valueList) //Find highest value in list
        {
            if(value > yMaximum)
            {
                yMaximum = value;
            }
        }
        yMaximum = yMaximum * 1.2f;

        GameObject lastCircleGameObject = null;
        for(int i=0;  i < valueList.Count; i++)
        {
            float xPosition = xSize + i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition)); //Places dots on graph
            UIElements.Add(circleGameObject);
            if (lastCircleGameObject != null)
            {
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent <RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;
            RectTransform xLabel = Instantiate(labelTemplateX);
            xLabel.SetParent(graphContainer);
            xLabel.gameObject.SetActive(true);
            xLabel.anchoredPosition = new Vector2(xPosition, -3f);
            xLabel.GetComponent<Text>().text = "Day "+(i+dayoffset).ToString(); //x-axis label 
            
            RectTransform xDash = Instantiate(yDashTemplate);
            xDash.SetParent(graphContainer, false);
            xDash.gameObject.SetActive(true);
            xDash.anchoredPosition = new Vector2(xPosition, 140f); //Adjust the vertical green lines
            
            
            UIElements.Add(xLabel.gameObject);
            UIElements.Add(xDash.gameObject);

        }
        int seperatorCount = 10; //total number of y-axis numbers
        for(int i=0; i <= seperatorCount; i++)
        {
            if (i < 8) //If statement is crummy attempt to stop graph y-axis values from going over the backround
            {
                RectTransform yLabel = Instantiate(labelTemplateY);
                yLabel.SetParent(graphContainer, false);
                yLabel.gameObject.SetActive(true);
                float normalizedValue = i * 1.2f / seperatorCount; //Adjusting from 1.0f to 1.2 made graph accurate
                yLabel.anchoredPosition = new Vector2(45f, normalizedValue * graphHeight); //Adjust float value to offset y-Axis number
                yLabel.GetComponent<Text>().text = Mathf.RoundToInt(normalizedValue * yMaximum).ToString();
                


                RectTransform yDash = Instantiate(xDashTemplate);
                yDash.SetParent(graphContainer, false);
                yDash.gameObject.SetActive(true);
                yDash.anchoredPosition = new Vector2(285f, normalizedValue * graphHeight); //Adjust float value to offset y-Axis grid line (horizontal line). changed 300f to 285f to attempt to make graph neater
                
                
                UIElements.Add(yDash.gameObject);
                UIElements.Add(yLabel.gameObject);
            }

        }

    }
    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameobject = new GameObject("dotConnection", typeof(Image)); //needs to match name of 
        gameobject.transform.SetParent(graphContainer, false);
        gameobject.GetComponent<Image>().color = new Color(1, 1, 1, .7f); //.5f makes it slightly transparent
        RectTransform rectTransform = gameobject.GetComponent<RectTransform>();
        Vector2 direction = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0,0);
        rectTransform.anchorMax = new Vector2(0,0);
        rectTransform.sizeDelta = new Vector2(distance,3f);//Creates horizontal bar (not linking dots)
        rectTransform.anchoredPosition = dotPositionA + direction * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x)*180/Mathf.PI);

        UIElements.Add(gameobject);
    }
}
