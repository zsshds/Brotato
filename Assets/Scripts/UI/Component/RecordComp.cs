using System;
using Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecordComp : MonoBehaviour
{
    private TextMeshProUGUI txt_Record;
    private void Awake()
    {
        txt_Record = GameObject.Find("Txt_Record").GetComponent <TextMeshProUGUI>();
    }
    public void Refresh(RoleData roleData)
    {
            txt_Record.text = GetRecord(roleData.record);
    }
    private String GetRecord(int rocord)
    {
        return rocord < 0 ? "尚无记录" : "通关危险" + rocord;
    }
}