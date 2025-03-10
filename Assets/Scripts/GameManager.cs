using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public RoleData curRoleData;
    public WeaponData curWeaponData;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //Test
        //UIManager.Instance.OpenPanel(UIConst.DifficultySelectPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
