using UnityEngine;
using System.Collections;

public class FloatingTextController : MonoBehaviour
{
    private static FloatingText popupText;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("HUDCanvas");
        if (!popupText)
            popupText = Resources.Load<FloatingText>("Prefabs/PopUpTextParent");
    }

    public static void CreateFloatingText(string text, Transform location)
    {
        FloatingText instance = Instantiate(popupText);
        //Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x + Random.Range(-.2f, .2f), location.position.y + Random.Range(-.2f, .2f)));

        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = new Vector3(Screen.width/2 + Random.Range(-25f, 25f), Screen.height/2 + Random.Range(-25f, 25f), 0f);
        instance.SetText(text);
    }
}