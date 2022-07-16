using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;
    Color[] colors = new Color[4] { Color.red, Color.green, Color.blue, Color.white };
    Color currentColor = Color.white;
    Color[] availableColors = new Color[3];

    public Color GetCurrentColor() {
        return currentColor;
    }

    void Awake() {
         if (Instance != null && Instance != this) { 
            Destroy(this); 
        } else { 
            Instance = this; 
        } 
    }

    void OnEnable()
    {
        EventManager.TimedEvent += GetNewColor;
    }

    void OnDisable() {
        EventManager.TimedEvent -= GetNewColor;
    }


    void Update()
    {
        
    }

    void GetNewColor() {
        availableColors = colors.Where(color => color != currentColor).ToArray();
        currentColor = availableColors[Random.Range(0, availableColors.Length)];
    }
}
