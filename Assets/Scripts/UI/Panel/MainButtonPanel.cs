using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainButtonPanel : MonoBehaviour
{
    private Button btn_Start;
    private Button btn_Setting;
    private Button btn_Progress;
    private Button btn_Exit;

    private void Awake()
    {
        //获取按钮组件（其实直接在检查器面板拖拽也行）
        btn_Start = GameObject.Find("Btn_Start").GetComponent<Button>();
        btn_Setting = GameObject.Find("Btn_Setting").GetComponent<Button>();
        btn_Progress = GameObject.Find("Btn_Progress").GetComponent<Button>();
        btn_Exit = GameObject.Find("Btn_Exit").GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //绑定按钮事件
        btn_Start.onClick.AddListener(() =>
        {
            Debug.Log("点击开始按钮");
            //使用场景管理器更换场景
            SceneLoadManager.Instance.LoadScene("LevelSelect", () =>
            {
                UIManager.Instance.OpenPanel(UIConst.RoleSelectPanel);
            });
        });
        btn_Setting.onClick.AddListener(() =>
        {
            Debug.Log("点击设置按钮");
        });
        btn_Progress.onClick.AddListener(() =>
        {
            Debug.Log("点击进度按钮");
        });
        btn_Exit.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();            
#endif
            Debug.Log("点击退出按钮");
        });
    }
}