using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class StartMenuManager : MonoBehaviour
{
    [Header("Menu Objects")]
    [SerializeField] private GameObject _startMenuCanvasGO;
    [SerializeField] private GameObject _stageMenuCanvasGO;
    [SerializeField] private GameObject _gameSettingCanvasGO;
    [Header("First Selected Options")]
    [SerializeField] private GameObject _startMenuFirst;
    [SerializeField] private GameObject _stageMenuFirst;
    [SerializeField] private GameObject _gameSettingFirst;
    // Start is called before the first frame update
    void Start()
    {
        OpenStartMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnExitPress()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPaused = false;
#else
        Application.Quit();
#endif
    }
    public void StartButton()
    {
        OpenStageMenu();
    }
    public void SettingButton()
    {
        OpenGameSetting();
    }
    public void OnStageBackPress()
    {
        OpenStartMenu();
    }
    public void OnStage1Press()
    {
        SceneManager.LoadScene("Stage1");
    }
    private void OpenStartMenu()
    {
        _startMenuCanvasGO.SetActive(true);
        _stageMenuCanvasGO.SetActive(false);
        _gameSettingCanvasGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_startMenuFirst);
    }
    private void OpenStageMenu()
    {
        _startMenuCanvasGO.SetActive(false);
        _stageMenuCanvasGO.SetActive(true);
        _gameSettingCanvasGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_stageMenuFirst);
    }
    private void OpenGameSetting()
    {
        _startMenuCanvasGO.SetActive(false);
        _stageMenuCanvasGO.SetActive(false);
        _gameSettingCanvasGO.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_gameSettingFirst);
    }
  
}
