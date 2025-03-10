using System.Collections;
using System.Collections.Generic;
using Model;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class DiffcultyDetailsComp : MonoBehaviour
{
    private Image img_DiffcultyInfo;
    private TextMeshProUGUI txt_DiffcultyName;
    private TextMeshProUGUI txt_DiffcultyDescribe;
    private void Awake()
    {
        img_DiffcultyInfo = GameObject.Find("Img_DifficultyInfo").GetComponent<Image>();
        txt_DiffcultyName = GameObject.Find("Txt_DifficultyName").GetComponent<TextMeshProUGUI>();
        txt_DiffcultyDescribe = GameObject.Find("Txt_DifficultyDescribe").GetComponent<TextMeshProUGUI>();
    }

    public void Refresh(DifficultyData difficultyData)
    {
        img_DiffcultyInfo.sprite = Resources.Load<SpriteAtlas>("Image/难度/危险等级").GetSprite(difficultyData.name);
        txt_DiffcultyName.text = difficultyData.name;
        txt_DiffcultyDescribe.text = difficultyData.describe;
    }
}
