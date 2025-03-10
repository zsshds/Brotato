using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using UnityEngine.UI;

public class DifficultyComp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public DifficultyData _DifficultyData;
    public Image img_Bg;
    public Image img_Difficulty;
    public Button btn_Difficulty;
    
    private void Awake()
    {
        img_Bg = GetComponent<Image>();
        img_Difficulty = transform.GetChild(0).GetComponent<Image>();
        btn_Difficulty = GetComponent<Button>();
        btn_Difficulty.onClick.AddListener(() =>
        {
            //OnSelectRole(_roleData);
        });
    }
    
    public void Refresh(DifficultyData difficultyData)
    {
        _DifficultyData = difficultyData;
        img_Difficulty.sprite = Resources.Load<SpriteAtlas>("Image/难度/危险等级").GetSprite(difficultyData.name);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        img_Bg.color = new Color(207/255f,207/255f,207/255f);
        DiffcultySelectPanel.Instance.comp_DiffcultyDetails.Refresh(_DifficultyData);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        img_Bg.color = new Color(34/255f, 34/355f, 34/255f);
    }
}
