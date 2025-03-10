using System;
using Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Component
{
    public class WeaponComp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private WeaponData _weaponData;
        private Image img_Bg;
        private Image img_Weapon;
        private Button btn_weapon;
        private void Awake()
        {
            img_Bg = GetComponent<Image>();
            img_Weapon = transform.GetChild(0).GetComponent<Image>();
            btn_weapon = GetComponent<Button>();
            btn_weapon.onClick.AddListener(() =>
            {
                OnSelectWeapon(_weaponData);
            });
        }
        public void Refresh(WeaponData weaponData)
        {
            _weaponData = weaponData;
            img_Weapon.sprite = Resources.Load<Sprite>(weaponData.img);
        }

        public void OnSelectWeapon(WeaponData weaponData)
        {
            if (weaponData != null)
            {
                GameManager.Instance.curWeaponData = weaponData;
                UIManager.Instance.ClosePanel(UIConst.WeaponSelectPanel);
                UIManager.Instance.OpenPanel(UIConst.DifficultySelectPanel);
            }
            else
            {
                Debug.LogWarning("当前选择武器数据为空！！！");
            }
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            img_Bg.color = new Color(207/255f,207/255f,207/255f);
            WeaponSelectPanel.Instance.comp_weaponDetails.Refresh(_weaponData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            img_Bg.color = new Color(34/255f, 34/355f, 34/255f);
        }
    }
}