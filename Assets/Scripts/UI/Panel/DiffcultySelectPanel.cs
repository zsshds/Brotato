using System.Collections;
using Model;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class DiffcultySelectPanel : BasePanel
{
    public static DiffcultySelectPanel Instance { get; private set; }
    
    private TextAsset difficultyTextAsset;
    private List<DifficultyData> difficultyDatas;
    private Transform pos_DiffcultySelectPanel;
    private GameObject comp_Diffculty;
    
    private RoleDatailsComp comp_RoleDatails;
    private WeaponDetailsComp comp_WeaponDatails;
    public DiffcultyDetailsComp comp_DiffcultyDetails;

    public override void OnShow(string name)
    {
        base.OnShow(name);
        //单例
        if (Instance == null)
        {
            Instance = this;
        }
        //载入数据刷新页面
        comp_RoleDatails = GameObject.Find("RoleDetailsComp").GetComponent<RoleDatailsComp>();
        comp_RoleDatails.Refresh(GameManager.Instance.curRoleData);
        comp_WeaponDatails = GameObject.Find("WeaponDetailsComp").GetComponent<WeaponDetailsComp>();
        comp_WeaponDatails.Refresh(GameManager.Instance.curWeaponData);
        comp_DiffcultyDetails = GameObject.Find("DiffcultyDetailsComp").GetComponent<DiffcultyDetailsComp>();
        //获取难度信息，刷新难度选择列表
        difficultyTextAsset = Resources.Load<TextAsset>("Data/difficulty");
        difficultyDatas = JsonConvert.DeserializeObject<List<DifficultyData>>(difficultyTextAsset.text);
        comp_Diffculty = Resources.Load<GameObject>("Prefabs/Comp/DifficultyComp");
        pos_DiffcultySelectPanel = GameObject.Find("DifficultyList").transform;
        foreach (DifficultyData difficultyData in difficultyDatas)
        {
            DifficultyComp comp = Instantiate(comp_Diffculty, pos_DiffcultySelectPanel).GetComponent<DifficultyComp>();
            comp.Refresh(difficultyData);
        }
    }

    public override void OnClose()
    {
        base.OnClose();
    }
}
