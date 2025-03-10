using System;
using Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoleDatailsComp : MonoBehaviour
{
    private Image img_RoleInfo;
    private TextMeshProUGUI txt_RoleName;
    private TextMeshProUGUI txt_RoelDescribe;
    

    private void Awake()
    {
        img_RoleInfo = GameObject.Find("Img_RoleInfo").GetComponent<Image>();
        txt_RoleName = GameObject.Find("Txt_RoleName").GetComponent<TextMeshProUGUI>();
        txt_RoelDescribe = GameObject.Find("Txt_RoleDescribe").GetComponent<TextMeshProUGUI>();
    }

    //刷新角色信息
    public void Refresh(RoleData roleData)
    {
        if (roleData.unlock == 0)
        {
            img_RoleInfo.sprite = Resources.Load<Sprite>("Image/UI/锁");
            txt_RoleName.text = "???";
            txt_RoelDescribe.text = roleData.unlockConditions;
        }
        else
        {
            img_RoleInfo.sprite = Resources.Load<Sprite>(roleData.img);
            txt_RoleName.text = roleData.name;
            txt_RoelDescribe.text = roleData.describe;
        }
    }
}
