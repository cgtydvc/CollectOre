using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public static GameManager singleton;
    [SerializeField]
    private List<TMPro.TextMeshProUGUI> text;

    public int expectedMoney;
    private int currentMoney;
    public int totalTimer;

    //private void Awake()
    //{
    //    if (singleton != null)
    //    {
    //        singleton = this;
    //    }
    //    else
    //        Destroy(gameObject);

    //    DontDestroyOnLoad(gameObject);
    //}
    private void start()
    {
        text[2].text = expectedMoney.ToString();
        InvokeRepeating("decreasetoTime", 0, 1f);

    }
    public void increasetoMoney(int value)
    {
        currentMoney += value;
        text[1].text = currentMoney.ToString();
    }
    private void decreasetoTime()
    {
        totalTimer--;
        text[0].text = totalTimer.ToString();
        if (totalTimer <= 0)
        {
            if (currentMoney >= expectedMoney)
            {
                Debug.Log("Go Other Level");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}