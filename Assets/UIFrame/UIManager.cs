using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI Panel注册
public class UIConst
{
    public const string RoleSelectPanel = "RoleSelectPanel";
    public const string WeaponSelectPanel = "WeaponSelectPanel";
    public const string DifficultySelectPanel = "DifficultySelectPanel";
}

//TODO简易的UI框架，后续慢慢优化吧
public class UIManager
{
    private static UIManager _instance;
    private Transform _uiRoot;

    private IDictionary<string, string> pathDictionary;
    private IDictionary<string, GameObject> prefabDictionary;
    private IDictionary<string, BasePanel> panelDictionary;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }

            return _instance;
        }
    }

    public Transform UIRoot
    {
        get
        {
            if (_uiRoot == null)
            {
                _uiRoot = GameObject.Find("Canvas").transform;
            }

            return _uiRoot;
        }
    }

    private UIManager()
    {
        InitDictionary();
    }

    private void InitDictionary()
    {
        prefabDictionary = new Dictionary<string, GameObject>();
        panelDictionary = new Dictionary<string, BasePanel>();
        //TODO:后续优化成 界面名对应路径的表 统一读取不再初始化
        pathDictionary = new Dictionary<string, string>()
        {
            { UIConst.RoleSelectPanel, "/RoleSelectPanel" },
            {UIConst.WeaponSelectPanel,"/WeaponSelectPanel"},
            {UIConst.DifficultySelectPanel,"/DifficultySelectPanel"}
        };
    }
    
    public BasePanel OpenPanel(string name)
    {
        BasePanel panel = null;
        //检查界面是否打开
        if (panelDictionary.TryGetValue(name, out panel))
        {
            Debug.LogWarning("界面已经打开" + name);
            return null;
        }

        //检查路径是否有配置
        string path = "";
        if (!pathDictionary.TryGetValue(name, out path))
        {
            Debug.LogWarning("界面名称错误，或界面为配置路径" + name);
            return null;
        }

        //加载预制体
        GameObject panelPrefab = null;
        if (!prefabDictionary.TryGetValue(name, out panelPrefab))
        {
            string realPath = "Prefabs/Panel" + path;
            panelPrefab = Resources.Load<GameObject>(realPath);
            Debug.Log("加载界面预制体" + name + "完成");
        }

        //打开界面
        GameObject panelObject = GameObject.Instantiate(panelPrefab, UIRoot, false);
        panel = panelObject.GetComponent<BasePanel>();
        panelDictionary.Add(name, panel);
        panel.OnShow(name);
        return panel;
    }

    public bool ClosePanel(string name)
    {
        BasePanel panel = null;
        if (!panelDictionary.TryGetValue(name, out panel))
        {
            Debug.LogWarning("界面未打开" + name);
            return false;
        }

        panel.OnClose();
        panelDictionary.Remove(name);
        return true;
    }
}
