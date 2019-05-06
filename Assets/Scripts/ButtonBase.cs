using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  abstract class ButtonBase : MonoBehaviour {



    Button btn;
    /// <summary>
    /// Awake()
    /// Start()
    /// Update()
    /// OnDestroy()
    /// OnApplicationQuit()
    /// </summary>
    public void Awake()
    {
        btn = this.transform.GetComponent<Button>();
        btn.onClick.AddListener(OnClickBtn);
    }
    public abstract void OnClickBtn();
    
}
