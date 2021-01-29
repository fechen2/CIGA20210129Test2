using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Timers;

public class MainPanel : MonoBehaviour
{
    public static MainPanel Instance;

    //
    public Button btnTeam;
    public GameObject objTeams;
    public Button btnLogin;
    //
    public Button btnTestTips;
    public Button btnTestResart;


    public Text txtTips;


    // Start is called before the first frame update
    void Start()
    {
        Instance = new MainPanel();

        btnTeam.onClick.AddListener(OpenTeam);

        
        btnTestTips.onClick.AddListener(TestTips);
        btnTestResart.onClick.AddListener(TestRestart);


        EventManager.GameEvent.Add(GameEvent.SystemTxt, OnRecivedSystemTxtHandler);
        EventManager.GameEvent.Add(GameEvent.RESET_GAME, OnRestartGameHandler);
    }

    public void TestRestart()
    {
        EventManager.GameEvent.Send(GameEvent.RESET_GAME);
    }
    public void TestTips()
    {
        EventManager.GameEvent.Send(GameEvent.SystemTxt,"TestTips");
    }    

    public void OpenTeam()
    {
        if (objTeams.activeSelf)
        {
            objTeams.SetActive(false);
        }
        else
        {
            objTeams.SetActive(true);
        }
    }
    /// <summary>
    /// 重启游戏
    /// </summary>
    public void OnRestartGameHandler(object value)
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        Debug.Log("OnRestartGameHandler 游戏结束！！");
    }

    private void OnRecivedSystemTxtHandler(object value)
    {
        txtTips.gameObject.SetActive(true);
        txtTips.text = value.ToString();
        //  Invoke("OnDelayTimeHandler", 2);
        TimersManager.SetTimer(this,2, OnDelayTimeHandler);
    }

    private void OnDelayTimeHandler()
    {
        txtTips.gameObject.SetActive(false);
    }

}
