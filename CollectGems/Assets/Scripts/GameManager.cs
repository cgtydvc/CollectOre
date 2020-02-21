using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TMPro.TextMeshProUGUI[] textMeshes;
    public int expectedValue;
    private int currentValue;
    public int timer;
    private void Start()
    {
        textMeshes[0].text = expectedValue.ToString();
        InvokeRepeating("decreaseValue", 1, 1.0f);
        //setLevel();
    }

    public void increaseCurrentValue(int value)
    {
        currentValue += value;
        textMeshes[1].text = currentValue.ToString();
    }
    private void decreaseValue()
    {
        timer--;
        textMeshes[2].text = "Timer : " + timer.ToString();

        if (timer <= 0)
        {
            if (currentValue >= expectedValue)
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            if (currentValue >= expectedValue)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    //private void setLevel()
    //{
    //    if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("saveit"))
    //    {
    //        PlayerPrefs.SetInt("saveit", SceneManager.GetActiveScene().buildIndex);
    //    }
    //}
}