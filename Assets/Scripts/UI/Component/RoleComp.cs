using Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoleComp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RoleData _roleData;
    public Image img_Bg;
    public Image img_role;
    public Button btn_role;

    private void Awake()
    {
        img_Bg = GetComponent<Image>();
        img_role = transform.GetChild(0).GetComponent<Image>();
        btn_role = GetComponent<Button>();
        //选择英雄的逻辑
        btn_role.onClick.AddListener(() =>
        {
            OnSelectRole(_roleData);
        });
    }

    public void Refresh(RoleData roleData)
    {
        _roleData = roleData;
        if (roleData.unlock == 0)
        {
            img_role.sprite = Resources.Load<Sprite>("Image/UI/锁");
        }
        else
        {
            img_role.sprite = Resources.Load<Sprite>(roleData.img);
        }
    }

    //选择角色
    public void OnSelectRole(RoleData roleData)
    {
        if (roleData != null)
        {
            GameManager.Instance.curRoleData = roleData;
            //打开武器选择界面,关闭角色选择界面
            UIManager.Instance.ClosePanel(UIConst.RoleSelectPanel);
            UIManager.Instance.OpenPanel(UIConst.WeaponSelectPanel);
        }
        else
        {
            Debug.LogWarning("当前选择角色数据为空！！！");
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        img_Bg.color = new Color(207/255f,207/255f,207/255f);
        RoleSelectPanel.Instance.comp_roleDatailsComp.Refresh(_roleData);
        RoleSelectPanel.Instance.comp_recordComp.Refresh(_roleData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img_Bg.color = new Color(34/255f, 34/355f, 34/255f);
    }
}
