using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private VisualTreeAsset _character_Menu;

    private UIDocument _doc;
    private Button _startButton;
    private Button _optionsButton;
    private Button _quitButton;

    private VisualElement _CharactersBtns;
    private VisualElement _btnWrapper;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();
        _startButton = _doc.rootVisualElement.Q<Button>("StartBtn");
        _CharactersBtns = _doc.rootVisualElement.Q<VisualElement>("CharactersBtns");
        _startButton.clicked += StartButtonOnClicked; 


        _optionsButton = _doc.rootVisualElement.Q<Button>("OptionsBtn");


        _quitButton = _doc.rootVisualElement.Q<Button>("QuitBtn");
        _quitButton.clicked += QuitButtonOnClicked;

        


        
    }

    private void StartButtonOnClicked ()
    {
        _btnWrapper.Clear();
        _btnWrapper.Add(_CharactersBtns);
    }

    private void QuitButtonOnClicked()
    {
        Application.Quit();
    }
}
