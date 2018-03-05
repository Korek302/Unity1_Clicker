using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public interface IButtonInterface: IEventSystemHandler
{
    void Message();
}

public class GameLoop : MonoBehaviour
{
    public GameObject Clickable1;
    public GameObject Clickable2;
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
        //BackgroundPanel.SetActive(false);

        for (int i = 0; i < _numberOfObjects; i++)
        {
            Vector3 _originalScale = Clickable1.transform.localScale;
            Vector2 _screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            if(Random.Range(0, 2) == 1)
            {
                float _temp = Random.Range(-0.05f, 0.05f);
                Clickable1.transform.localScale += new Vector3(_temp, _temp, 0);
                Instantiate(Clickable1,
                new Vector3(Random.Range(-_screenBounds[0], _screenBounds[0]),
                    Random.Range(-_screenBounds[1], _screenBounds[1])),
                Quaternion.Euler(0, 0, Random.Range(0, 360)));
            }
            else
            {
                float _temp = Random.Range(-0.05f, 0.05f);
                Clickable2.transform.localScale += new Vector3(_temp, _temp, 0);
                Instantiate(Clickable2,
                new Vector3(Random.Range(-_screenBounds[0], _screenBounds[0]),
                    Random.Range(-_screenBounds[1], _screenBounds[1])),
                Quaternion.Euler(0, 0, Random.Range(0, 360)));
            }
            Clickable1.transform.localScale = _originalScale;
            Clickable2.transform.localScale = _originalScale;
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
        FinishTimeText.text = finalTime.ToString("f2");

        //BackgroundPanel.SetActive(true);
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
