 using System.Collections;
using System.Collections.Generic;
using Model;
using Newtonsoft.Json;
using UI.Component;
using UnityEngine;

public class WeaponSelectPanel : BasePanel
{
    public static WeaponSelectPanel Instance { get; private set; }
    
    private TextAsset weaponTextAsset;
    private List<WeaponData> weaponDatas;
    
    private Transform pos_weaponList;
    private GameObject comp_weapon;

    private RoleDatailsComp comp_roleDatails;
    public WeaponDetailsComp comp_weaponDetails;
    public override void OnShow(string name)
    {
        base.OnShow(name);
        if (Instance == null)
        {
            Instance = this;
        }
        //读取配置示例武器对象
        weaponTextAsset = Resources.Load<TextAsset>("Data/weapon");
        weaponDatas = JsonConvert.DeserializeObject<List<WeaponData>>(weaponTextAsset.text);
        //生成武器列表
        comp_weapon = Resources.Load<GameObject>("Prefabs/Comp/WeaponComp");
        pos_weaponList = GameObject.Find("WeaponList").transform;
        foreach (WeaponData weaponData in weaponDatas)
        {
            WeaponComp weaponComp = Instantiate(comp_weapon, pos_weaponList).GetComponent<WeaponComp>();
            weaponComp.Refresh(weaponData);
        }
        //刷新角色信息
        comp_roleDatails = GameObject.Find("RoleDetailsComp").GetComponent<RoleDatailsComp>();
        comp_roleDatails.Refresh(GameManager.Instance.curRoleData);
        //获取武器信息面板
        comp_weaponDetails = GameObject.Find("WeaponDetailsComp").GetComponent<WeaponDetailsComp>();
    }

    public override void OnClose()
    {
        base.OnClose();
        
    }
}
