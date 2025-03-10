using System;
using System.Collections;
using System.Collections.Generic;
using Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDetailsComp : MonoBehaviour
{
    private Image img_weaponInfo;
    private TextMeshProUGUI txt_weaponName;
    private TextMeshProUGUI txt_weaponDescribe;
    private TextMeshProUGUI txt_weaponType;
    private void Awake()
    {
        img_weaponInfo = GameObject.Find("Img_WeaponInfo").GetComponent<Image>();
        txt_weaponName = GameObject.Find("Txt_WeaponName").GetComponent<TextMeshProUGUI>();
        txt_weaponDescribe = GameObject.Find("Txt_WeaponDescribe").GetComponent<TextMeshProUGUI>();
        txt_weaponType = GameObject.Find("Txt_WeaponType").GetComponent<TextMeshProUGUI>();
    }

    public void Refresh(WeaponData weaponData)
    {
        img_weaponInfo.sprite = Resources.Load<Sprite>(weaponData.img);
        txt_weaponName.text = weaponData.name;
        txt_weaponDescribe.text = weaponData.describe;
        txt_weaponType.text = weaponData.isLong == 0 ? "近战武器" : "远程武器";
    }
}
