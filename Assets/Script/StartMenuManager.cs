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
    [Header("First Selected Options")]
    [SerializeField] private GameObject _startMenuFirst;
    [SerializeField] private GameObject _stageMenuFirst;
    // Start is called before the first frame update
    void Start()
    {
        OpenStartMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButton()
    {
        OpenStageMenu();
    }
    public void OnStageBackPress()
    {
        OpenStartMenu();
    }
    public void OnStage1Press()
    {
        SceneManager.LoadScene("SampleScene");
    }
    private void OpenStartMenu()
    {
        _startMenuCanvasGO.SetActive(true);
        _stageMenuCanvasGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_startMenuFirst);
    }
    private void OpenStageMenu()
    {
        _startMenuCanvasGO.SetActive(false);
        _stageMenuCanvasGO.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_stageMenuFirst);
    }
  
}
