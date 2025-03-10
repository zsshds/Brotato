using System.Collections.Generic;
using Model;
using Newtonsoft.Json;
using UnityEngine;

public class RoleSelectPanel : BasePanel
{
    public static RoleSelectPanel Instance { get; private set; }
    
    //角色数据
    public List<RoleData> roleDatas = new List<RoleData>();
    private TextAsset roleTextAsset;

    //UI对象
    public Transform pos_roleList;
    public GameObject comp_prefab;
    public RoleDatailsComp comp_roleDatailsComp;
    public RecordComp comp_recordComp;

    public override void OnShow(string name)
    {
        base.OnShow(name);
        
        //初始化单例
        if (Instance == null)
        {
            Instance = this;
        }

        //读取json并序列化
        roleTextAsset = Resources.Load<TextAsset>("Data/role");
        roleDatas = JsonConvert.DeserializeObject<List<RoleData>>(roleTextAsset.text);

        pos_roleList = GameObject.Find("RoleList").transform;
        comp_prefab = Resources.Load<GameObject>("Prefabs/Comp/RoleComp");
        comp_roleDatailsComp = GameObject.Find("RoleDetails").GetComponent<RoleDatailsComp>();
        comp_recordComp = GameObject.Find("Record").GetComponent<RecordComp>();
        
        foreach (RoleData roleData in roleDatas)
        {
            RoleComp role = Instantiate(comp_prefab, pos_roleList).GetComponent<RoleComp>();
            role.Refresh(roleData);
        }
    }

    public override void OnClose()
    {
        base.OnClose();
    }
}
