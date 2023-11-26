using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button Start = root.Q<Button>("Start");
        Button Options = root.Q<Button>("Options");
        Button Quit = root.Q<Button>("Quit");

        
    }
}
