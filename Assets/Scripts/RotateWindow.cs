using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateWindow : ButtonBase {
    RectTransform parent;
    public bool rangeFlag = true;//为true时为横排
	
	void Start () {
        parent = this.transform.parent.GetComponent<RectTransform>();
	}
	
	
	void Update () {
		
	}

    public override void OnClickBtn()
    {
        if (rangeFlag == true)//此时为横排，需要改变为竖排
        {
            parent.pivot = new Vector2(0.5f, 0.5f);
            parent.Rotate(new Vector3(0, 0, -90));
            parent.pivot = new Vector2(0f, 0f);
            this.transform.Find("Text").GetComponent<Text>().text="垂直排列";
            rangeFlag = false;
        }

        else if (rangeFlag == false)
        {
            parent.pivot = new Vector2(0.5f, 0.5f);
            parent.Rotate(new Vector3(0, 0, 90));
            parent.pivot = new Vector2(0f, 1f);
            this.transform.Find("Text").GetComponent<Text>().text = "水平排列";
            rangeFlag = true;
        }
        
    }
}
