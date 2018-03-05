using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    int NumberOfObjects;
    string str;
    public GameObject cube;

    public void StartGame()
    {
        GameObject canvas = GameObject.Find("Canvas");
        canvas.SetActive(false);
        for (int i = 0; i < NumberOfObjects; i++)
        {
            Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            Instantiate(cube,
                new Vector3(Random.Range(-screenBounds[0], screenBounds[0]),
                    Random.Range(-screenBounds[1], screenBounds[1])),
                Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ValueChanged(string input)
    {
        float temp = float.Parse(input);
        NumberOfObjects = (int)temp;
    }
}
