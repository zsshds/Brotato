using UnityEngine;

public class BasePanel : MonoBehaviour
{
    protected bool isRemove = false;
    protected new string name;

    public virtual void OnBind()
    {
        
    }
    
    public virtual void OnShow(string name)
    {
        this.name = name;
        gameObject.SetActive(true);
    }
    
    public virtual void OnClose()
    {
        isRemove = true;
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    
}