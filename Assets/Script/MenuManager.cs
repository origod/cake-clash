using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Objects")]
    [SerializeField] private GameObject _mainMenuCanvasGO;
    [SerializeField] private GameObject _settingsMenuCanvasGO;
    [SerializeField] private GameObject _gameoverCanvasGO;

    [Header("Player Scripts to Deactivate on Pause")]
    [SerializeField] private PalyerScript _player;

    [Header("First Selected Options")]
    [SerializeField] private GameObject _mainMenuFirst;
    [SerializeField] private GameObject _settingMenuFirst;
    [SerializeField] private GameObject _gameoverFirst;

    private bool isPaused;

    void Start()
    {
        Time.timeScale = 1f;

        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);
        _gameoverCanvasGO.SetActive(false);
    }
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Escape ))
        ////if (InputManager.instance.MenuOpenCloseInput)
        //{
        //    // Debug.Log("push");
        //    if (!isPaused)
        //    {
        //        Pause();
        //    }
        //    else
        //    {
        //        Unpause();
        //    }
        //}
        if (_player.currentHP == 0)
        {
            GameOver();
        }
    }
    public void OpenClose(InputAction.CallbackContext context )
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        _player.enabled = false;

        OpenMainMenu();
    }
    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;

        _player.enabled = true;

        CloseAllMenus();
    }
    private void OpenMainMenu()
    {
        _mainMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }
    private void OpenSettingsMenuHandle()
    {
        _settingsMenuCanvasGO.SetActive(true);
        _mainMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_settingMenuFirst);
    }
    private void CloseAllMenus()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }
    private void GameOver()
    {
        Time.timeScale = 0f;
        _player.enabled = false;
        _gameoverCanvasGO.SetActive(true);

       // EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_gameoverFirst);
    }
    public void OnSettingsPress()
    {
        OpenSettingsMenuHandle();
    }
    public void OnResumePress()
    {
        Unpause();
    }
    public void OnSettingsBackPress()
    {
        OpenMainMenu();
    }
      public void OnRetry()
    {
        //Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
