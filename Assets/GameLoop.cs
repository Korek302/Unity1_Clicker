using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public interface IButtonInterface: IEventSystemHandler
{
    void Message();
}

public class GameLoop : MonoBehaviour, IButtonInterface
{
    public void Message()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    public GameObject Clickable;
    public Text TimerText;
    public Text FinishTimeText;
    public InputField InputField;
    public GameObject ButtonPanel;
    public GameObject BackgroundPanel;
    public GameObject FinishPanel;

    float _startTime;
    int _numberOfObjects;
    bool _running;

    public void StartGame()
    {
        float num;
        string input = InputField.text;
        if (float.TryParse(input, out num))
        {
            _numberOfObjects = int.Parse(input);
        }
        else
        {
            Debug.Log("Error: InputValue");
        }

        ButtonPanel.SetActive(false);
        BackgroundPanel.SetActive(false);

        for (int i = 0; i < _numberOfObjects; i++)
        {
            Vector2 _screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            Instantiate(Clickable,
                new Vector3(Random.Range(-_screenBounds[0], _screenBounds[0]),
                    Random.Range(-_screenBounds[1], _screenBounds[1])),
                Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }

        _running = true;
        TimerText.gameObject.SetActive(true);
        _startTime = Time.time;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Finish(float finalTime)
    {
        _running = false;
        FinishTimeText.text = finalTime.ToString();

        BackgroundPanel.SetActive(true);
        FinishPanel.SetActive(true);
        TimerText.gameObject.SetActive(false);
    }

    private void Start()
    {
        TimerText.gameObject.SetActive(false);
        FinishPanel.SetActive(false);
    }

    private void Update()
    {
        if(_running)
        {
            float _time = Time.time - _startTime;
            string _minutes = ((int)_time / 60).ToString();
            string _seconds = (_time % 60).ToString("f2");

            TimerText.text = _minutes + ":" + _seconds;

            if(GameObject.FindGameObjectWithTag("Clickable") == null)
            {
                Finish(_time);
            }
        }
    }
}
