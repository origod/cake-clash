using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    [SerializeField] private GameObject _gameclearCanvasGO;
    //[SerializeField] private GameObject _gameoverCanvasGO;

    [SerializeField] private PalyerScript _player;

    [SerializeField] private GameObject _gameclearFirst;
    //[SerializeField] private GameObject _gameoverFirst;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _gameclearCanvasGO.SetActive(false);
        //_gameoverCanvasGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (_player.currentHP == 0)
        //{
        //    GameOver();
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameClear();
            audioManager.StopBGM();
        }
    }
    void GameClear()
    {
        Time.timeScale = 0f;
        _player.enabled = false;
        _gameclearCanvasGO.SetActive(true);

        // EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_gameclearFirst);
    }
    //private void GameOver()
    //{
    //    Time.timeScale = 0f;
    //    _player.enabled = false;
    //    _gameoverCanvasGO.SetActive(true);

    //    // EventSystem.current.SetSelectedGameObject(null);
    //    EventSystem.current.SetSelectedGameObject(_gameoverFirst);
    //}
}
