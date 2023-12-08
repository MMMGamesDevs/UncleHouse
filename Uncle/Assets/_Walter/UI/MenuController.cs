using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private VisualTreeAsset _character_Menu;
    private VisualElement _CharactersBtns;
    private VisualElement _btnWrapper;

    private UIDocument _doc;
    private Button _startButton;
    private Button _optionsButton;
    private Button _quitButton;

    

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();
        _startButton = _doc.rootVisualElement.Q<Button>("StartBtn");

        _character_Menu = Instantiate(_character_Menu);

        _CharactersBtns = _doc.rootVisualElement.Q<VisualElement>("CharactersBtns");
        _btnWrapper = _doc.rootVisualElement.Q<VisualElement>("BtnWrapper");
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
