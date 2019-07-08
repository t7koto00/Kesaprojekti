using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class ObjectiveController : MonoBehaviour
{
    public static int paintings;
    public static int statues;
    public static int guards;
    private bool paintingsDone = false;
    private bool statuesDone = false;
    private bool guardsDone = false;
    public GameObject objectives;
    private int scoreGain;
    private int bonusScore;
    string sceneName;
    Scene currentScene;
    // Start is called before the first frame update
    void Start()
    {
        paintings = 0;
        statues = 0;
        guards = 0;
        scoreGain = 0;
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (sceneName == "GameScene")
        {
            CreateObjective("Paint 6 paintings: " + paintings.ToString() + "/6", 200, -50, "1");
            CreateObjective("Paint 4 statues: " + statues.ToString() + "/4", 200, -70, "2");
            CreateObjective("Paint a guard: " + guards.ToString() + "/1", 200, -90, "3");
        }
        else if (sceneName == "GameSceneTonin")
        {
            CreateObjective("Paint 10 paintings: " + paintings.ToString() + "/10", 200, -50, "1");
            CreateObjective("Paint 5 statues: " + statues.ToString() + "/5", 200, -70, "2");
            CreateObjective("Paint 2 guards: " + guards.ToString() + "/2", 200, -90, "3");
        }
        else if (sceneName == "#1 Museo")
        {
            CreateObjective("Paint 10 paintings: " + paintings.ToString() + "/10", 200, -50, "1");
            CreateObjective("Paint 5 statues: " + statues.ToString() + "/5", 200, -70, "2");
            CreateObjective("Paint 2 guards: " + guards.ToString() + "/2", 200, -90, "3");
        }
        else if (sceneName == "JokuMuseo")
        {
            CreateObjective("Paint 10 paintings: " + paintings.ToString() + "/10", 200, -50, "1");
            CreateObjective("Paint 5 statues: " + statues.ToString() + "/5", 200, -70, "2");
            CreateObjective("Paint 2 guards: " + guards.ToString() + "/2", 200, -90, "3");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneName == "GameScene")
        { 
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
        else if (sceneName == "GameSceneTonin")
        {
            if (paintings >= 10 && paintingsDone == false)
            {
                paintingsDone = true;
                scoreGain = scoreGain + 2000;
                FloatingTextController.CreateFloatingText(2000.ToString(), objectives.transform);
            }
            if (statues >= 5 && statuesDone == false)
            {
                statuesDone = true;
                scoreGain = scoreGain + 2000;
                FloatingTextController.CreateFloatingText(2000.ToString(), objectives.transform);
            }
            if (guards >= 2 && guardsDone == false)
            {
                guardsDone = true;
                scoreGain = scoreGain + 2000;
                FloatingTextController.CreateFloatingText(2000.ToString(), objectives.transform);
            }

            if (scoreGain > bonusScore)
            {
                bonusScore = bonusScore + 5;
                TopDownController.score = TopDownController.score + 5;
            }
        }
        else if (sceneName == "#1 Museo")
        {
            if (paintings >= 10 && paintingsDone == false)
            {
                paintingsDone = true;
                scoreGain = scoreGain + 2000;
                FloatingTextController.CreateFloatingText(2000.ToString(), objectives.transform);
            }
            if (statues >= 5 && statuesDone == false)
            {
                statuesDone = true;
                scoreGain = scoreGain + 2000;
                FloatingTextController.CreateFloatingText(2000.ToString(), objectives.transform);
            }
            if (guards >= 2 && guardsDone == false)
            {
                guardsDone = true;
                scoreGain = scoreGain + 2000;
                FloatingTextController.CreateFloatingText(2000.ToString(), objectives.transform);
            }

            if (scoreGain > bonusScore)
            {
                bonusScore = bonusScore + 5;
                TopDownController.score = TopDownController.score + 5;
            }
        }
        else if (sceneName == "JokuMuseo")
        {
            if (paintings >= 10 && paintingsDone == false)
            {
                paintingsDone = true;
                scoreGain = scoreGain + 2000;
                FloatingTextController.CreateFloatingText(2000.ToString(), objectives.transform);
            }
            if (statues >= 5 && statuesDone == false)
            {
                statuesDone = true;
                scoreGain = scoreGain + 2000;
                FloatingTextController.CreateFloatingText(2000.ToString(), objectives.transform);
            }
            if (guards >= 2 && guardsDone == false)
            {
                guardsDone = true;
                scoreGain = scoreGain + 2000;
                FloatingTextController.CreateFloatingText(2000.ToString(), objectives.transform);
            }

            if (scoreGain > bonusScore)
            {
                bonusScore = bonusScore + 5;
                TopDownController.score = TopDownController.score + 5;
            }
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
        if (sceneName == "GameScene")
        {
            objectives.transform.Find("1").GetComponent<Text>().text = "Paint 6 paintings: " + paintings.ToString() + "/6";
            objectives.transform.Find("2").GetComponent<Text>().text = "Paint 4 statues: " + statues.ToString() + "/4";
            objectives.transform.Find("3").GetComponent<Text>().text = "Paint a guard: " + guards.ToString() + "/1";
        }
        else if(sceneName == "GameSceneTonin")
        {
            objectives.transform.Find("1").GetComponent<Text>().text = "Paint 10 paintings: " + paintings.ToString() + "/10";
            objectives.transform.Find("2").GetComponent<Text>().text = "Paint 5 statues: " + statues.ToString() + "/5";
            objectives.transform.Find("3").GetComponent<Text>().text = "Paint 2 guards: " + guards.ToString() + "/2";
        }
        else if (sceneName == "#1 Museo")
        {
            objectives.transform.Find("1").GetComponent<Text>().text = "Paint 10 paintings: " + paintings.ToString() + "/10";
            objectives.transform.Find("2").GetComponent<Text>().text = "Paint 5 statues: " + statues.ToString() + "/5";
            objectives.transform.Find("3").GetComponent<Text>().text = "Paint 2 guards: " + guards.ToString() + "/2";
        }
        else if (sceneName == "JokuMuseo")
        {
            objectives.transform.Find("1").GetComponent<Text>().text = "Paint 10 paintings: " + paintings.ToString() + "/10";
            objectives.transform.Find("2").GetComponent<Text>().text = "Paint 5 statues: " + statues.ToString() + "/5";
            objectives.transform.Find("3").GetComponent<Text>().text = "Paint 2 guards: " + guards.ToString() + "/2";
        }
    }
}
