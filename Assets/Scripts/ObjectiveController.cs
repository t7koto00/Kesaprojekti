using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ObjectiveController : MonoBehaviour
{
    public static int paintings;
    public static int statues;
    public static int guards;
    private bool paintingsDone = false;
    private bool statuesDone = false;
    private bool guardsDone = false;
    public GameObject objectives;
    public int scoreGain;
    public int bonusScore;
    // Start is called before the first frame update
    void Start()
    {
        paintings = 0;
        statues = 0;
        guards = 0;
        scoreGain = 0;
        CreateObjective("Paint 6 paintings: " + paintings.ToString() + "/6", 200, -50, "1");
        CreateObjective("Paint 4 statues: " + statues.ToString() + "/4", 200, -70, "2");
        CreateObjective("Paint a guard: " + guards.ToString() + "/1", 200, -90, "3");

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(paintings +" " + statues + " " + guards);
        if (paintings >= 6 && paintingsDone == false)
        {
            paintingsDone = true;
            scoreGain = scoreGain + 2000;
            FloatingTextController.CreateFloatingText(2000.ToString(), objectives.transform);
        }
        if (statues >= 4 && statuesDone == false)
        {
            statuesDone = true;
            scoreGain = scoreGain + 2000;
            FloatingTextController.CreateFloatingText(2000.ToString(), objectives.transform);
        }
        if(guards >= 1 && guardsDone == false)
        {
            guardsDone = true;
            scoreGain = scoreGain + 2000;
            FloatingTextController.CreateFloatingText(2000.ToString(), objectives.transform);
        }

        if(scoreGain > bonusScore)
        {
            bonusScore = bonusScore + 5;
            TopDownController.score = TopDownController.score + 5;     
        }
        
    }
    
    void FixedUpdate()
    {
        UpdateObjective();
    }

    void CreateObjective(string text, int x, int y, string id)
    {
        GameObject gameObject = new GameObject(id);
        gameObject.transform.SetParent(objectives.transform);
        RectTransform trans = gameObject.AddComponent<RectTransform>();
        trans.anchorMin = new Vector2(0, 1);
        trans.anchorMax = new Vector2(0, 1);
        trans.anchoredPosition = new Vector2(x, y);
        trans.sizeDelta = new Vector2(400, 100);

        Text objectiveText = gameObject.AddComponent<Text>();
        objectiveText.alignment = TextAnchor.UpperLeft;
        objectiveText.text = text;
        objectiveText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        objectiveText.color = Color.red;
    }
    
    void UpdateObjective()
    {
        objectives.transform.Find("1").GetComponent<Text>().text = "Paint 6 paintings: " + paintings.ToString() + "/6";
        objectives.transform.Find("2").GetComponent<Text>().text = "Paint 4 statues: " + statues.ToString() + "/4";
        objectives.transform.Find("3").GetComponent<Text>().text = "Paint a guard: " + guards.ToString() + "/1";
    }
}
