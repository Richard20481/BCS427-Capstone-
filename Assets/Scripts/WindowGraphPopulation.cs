using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowGraphPopulation : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private RectTransform xDashTemplate;
    private RectTransform yDashTemplate;

    private void Awake()
    {
        graphContainer = transform.Find("GraphContainerPopulation").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("xAxisLabelTemplatePopulation").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("yAxisLabelTemplatePopulation").GetComponent<RectTransform>();
        xDashTemplate = graphContainer.Find("xDashTemplatePopulation").GetComponent<RectTransform>();
        yDashTemplate = graphContainer.Find("yDashTemplatePopulation").GetComponent<RectTransform>();

        //CreateCircle(new Vector2(100,100)); //Places an example dot
        List<int> valueList = new List<int>() { 5, 200, 1350, 2300, 2750, 2500, 3000, 5688, 8900, 10000 }; //Test values
        showGraph(valueList);




    }

    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circleSprite", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(30, 30);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private void showGraph(List<int> valueList)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 10000f; //Top of graph was 300
        float xSize = 50f; //Length of graph

        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPosition = xSize + i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition)); //Places dots on graph
            if (lastCircleGameObject != null)
            {
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;

            RectTransform xLabel = Instantiate(labelTemplateX);
            xLabel.SetParent(graphContainer);
            xLabel.gameObject.SetActive(true);
            xLabel.anchoredPosition = new Vector2(xPosition, -3f);
            xLabel.GetComponent<Text>().text = "Day " + i.ToString(); //x-axis label 

            RectTransform xDash = Instantiate(yDashTemplate);
            xDash.SetParent(graphContainer, false);
            xDash.gameObject.SetActive(true);
            xDash.anchoredPosition = new Vector2(xPosition, 157f); //Adjust the vertical green lines was 140


        }
        int seperatorCount = 10; //total number of y-axis numbers
        for (int i = 0; i <= seperatorCount; i++)
        {
            if (i < 11) //If statement is crummy attempt to stop graph y-axis values from going over the backround
            {
                RectTransform yLabel = Instantiate(labelTemplateY);
                yLabel.SetParent(graphContainer, false);
                yLabel.gameObject.SetActive(true);
                float normalizedValue = i * 1.0f / seperatorCount; //Adjusting from 1.0f to 1.2 made graph accurate
                yLabel.anchoredPosition = new Vector2(45f, normalizedValue * graphHeight); //Adjust float value to offset y-Axis number
                yLabel.GetComponent<Text>().text = Mathf.RoundToInt(normalizedValue * yMaximum).ToString();

                RectTransform yDash = Instantiate(xDashTemplate);
                yDash.SetParent(graphContainer, false);
                yDash.gameObject.SetActive(true);
                yDash.anchoredPosition = new Vector2(285f, normalizedValue * graphHeight); //Adjust float value to offset y-Axis grid line (horizontal line). changed 300f to 285f to attempt to make graph neater
            }

        }

    }
    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameobject = new GameObject("dotConnection", typeof(Image)); 
        gameobject.transform.SetParent(graphContainer, false);
        gameobject.GetComponent<Image>().color = new Color(1, 1, 1, 1f); //.5f makes it slightly transparent
        RectTransform rectTransform = gameobject.GetComponent<RectTransform>();
        Vector2 direction = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);//Creates horizontal bar (not linking dots)
        rectTransform.anchoredPosition = dotPositionA + direction * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI);
    }
}

