using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;
using Unity.Netcode;

public class MenuController : MonoBehaviour
{
    [SerializeField] VisualTreeAsset _characterMenu;
    [SerializeField] VisualTreeAsset _creditsMenu;
    [SerializeField] VisualTreeAsset _networkMenu;
    [SerializeField] VisualTreeAsset _startMenu;

    UIDocument _doc;
    
    Button _startButton;
    Button _creditsButton;
    Button _quitButton;
    Button _startSinglePlayerButton;
    Button _startMultiPlayerButton;
    Button _startBackButton;
    Button _yokoButton;
    Button _lisaButton;

    //readonly string[] _namePlayers = { "Yoko", "Lisa", "Gimp", "Aaron", "Wolf" };
    //private Button[] _playerButtons = new Button[5];

    private VisualElement _btnWrapper, _menuButtons;
    private VisualElement _startButtons, _characterButtons;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();
        _btnWrapper = _doc.rootVisualElement.Q<VisualElement>("BtnWrapper");
        _menuButtons = _doc.rootVisualElement.Q<VisualElement>("MenuBtns");

        // Main Menu
        _startButton = _doc.rootVisualElement.Q<Button>("StartBtn");
        _creditsButton = _doc.rootVisualElement.Q<Button>("CreditsBtn");
        _quitButton = _doc.rootVisualElement.Q<Button>("QuitBtn");
        _startButton.clicked += StartButtonOnClicked;
        _creditsButton.clicked += CreditsButtonOnClicked;
        _quitButton.clicked += QuitButtonOnClicked;

        // Start Menu
        _startButtons = _startMenu.CloneTree();
        _startSinglePlayerButton = _startButtons.Q<Button>("SinglePlayerBtn");
        _startMultiPlayerButton = _startButtons.Q<Button>("MultiPlayerBtn");
        _startBackButton = _startButtons.Q<Button>("BackBtn");
        _startSinglePlayerButton.clicked += StartSinglePlayerButtonOnClicked;
        _startMultiPlayerButton.clicked += StartMultiPlayerButtonOnClicked;
        _startBackButton.clicked += StartBackButtonOnClicked;

        // Character Menu
        _characterButtons = _characterMenu.CloneTree();
        //_yokoButton = _characterButtons.Q<Button>("Yoko");
        //_yokoButton.clicked += StartSimplePlayer;
        _lisaButton = _characterButtons.Q<Button>("Lisa");
        _lisaButton.clicked += StartSimplePlayerOnClicked;
        Debug.Log(_lisaButton.text);
   


    }

    void StartSimplePlayerOnClicked()
    {
        Debug.Log("A jugar");
        NetworkManager.Singleton.StartHost();
    }

    void StartButtonOnClicked ()
    {
        //SceneManager.LoadScene("Scene2");
        _btnWrapper.Clear();
        //_btnWrapper.Add(_startButtons);
        _btnWrapper.Add(_characterButtons);
    }

    void CreditsButtonOnClicked()
    {
        _btnWrapper.Clear();
        _btnWrapper.Add(_creditsMenu.CloneTree());
    }
    void QuitButtonOnClicked()
    {
        Application.Quit();
    }

    void StartSinglePlayerButtonOnClicked()
    {
        _btnWrapper.Clear();
        _btnWrapper.Add(_characterMenu.CloneTree());
    }

    void StartMultiPlayerButtonOnClicked()
    {
        _btnWrapper.Clear();
        _btnWrapper.Add(_networkMenu.CloneTree());
    }

    void StartBackButtonOnClicked()
    {
        _btnWrapper.Clear();
        _btnWrapper.Add(_menuButtons);
    }

    private void OptionsButtonOnClicked()
    {
        Debug.Log("Options");
    }
}
