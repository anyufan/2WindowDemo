using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbCol_3 : MonoBehaviour {
    public RectTransform windowParent;
    public RectTransform windowCollider;
    public DragDemo dragTrue;
    public DragDemo dragFalse;
    public Vector3 tempVector;
    float x, y;
    // Use this for initialization
    void Start()
    {
        windowParent = this.transform.parent.GetComponent<RectTransform>();
        dragTrue = windowParent.GetComponent<DragDemo>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
        //windowCollider = other.transform.parent.GetComponent<RectTransform>();
        //dragFalse = windowCollider.GetComponent<DragDemo>();

    }
    void OnTriggerExit2D(Collider2D other)
    {
        //windowCollider = null;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("OnTriggerStay2D：" + this.transform.name);
        windowCollider = other.transform.parent.GetComponent<RectTransform>();
        dragFalse = windowCollider.GetComponent<DragDemo>();
        if (other.gameObject.name == "Col_4")
        {
            if (windowParent.GetComponent<RectTransform>().pivot == new Vector2(0, 1) && windowCollider.GetComponent<RectTransform>().pivot == new Vector2(0, 1))
            {
                if (dragTrue.absorbFlag == true && dragTrue.allowMove == false && windowParent.gameObject == PositionControl.currentWindow)
                {
                    Debug.Log("OnTriggerStay2D：" + this.transform.name + "-" + other.gameObject.name);
                    //保留拖动窗体的y坐标值，修改其x坐标值为碰撞窗体的坐标值加宽
                    tempVector = windowParent.localPosition;
                    x = windowCollider.localPosition.x;
                    tempVector.x = 0f;
                    windowParent.localPosition = tempVector + new Vector3(x + dragFalse.itemWidth, 0, 0);
                }
            }
            if (windowParent.GetComponent<RectTransform>().pivot == new Vector2(0, 0) && windowCollider.GetComponent<RectTransform>().pivot == new Vector2(0, 0))
            {
                if (dragTrue.absorbFlag == true && dragTrue.allowMove == false && windowParent.gameObject == PositionControl.currentWindow)
                {
                    Debug.Log("OnTriggerStay2D：" + this.transform.name + "-" + other.gameObject.name);
                    //保x，改y
                    tempVector = windowParent.localPosition;
                    y = windowCollider.localPosition.y;
                    tempVector.y = 0f;
                    windowParent.localPosition = tempVector + new Vector3(0, y - dragFalse.itemWidth, 0);
                }
            }
        }

        if (other.gameObject.name == "Col_2")
        {
            if (windowParent.GetComponent<RectTransform>().pivot == new Vector2(0, 0) && windowCollider.GetComponent<RectTransform>().pivot == new Vector2(0, 1))
            {
                if (dragTrue.absorbFlag == true && dragTrue.allowMove == false && windowParent.gameObject == PositionControl.currentWindow)
                {
                    Debug.Log("OnTriggerStay2D：" + this.transform.name + "-" + other.gameObject.name);
                    //保x，改y
                    tempVector = windowParent.localPosition;
                    y = windowCollider.localPosition.y;
                    tempVector.y = 0f;
                    windowParent.localPosition = tempVector + new Vector3(0, y - dragFalse.itemLen, 0);
                }
            }
        }

        if (other.gameObject.name == "Col_1")
        {
            if (windowParent.GetComponent<RectTransform>().pivot == new Vector2(0, 1) && windowCollider.GetComponent<RectTransform>().pivot == new Vector2(0, 0))
            {
                if (dragTrue.absorbFlag == true && dragTrue.allowMove == false && windowParent.gameObject == PositionControl.currentWindow)
                {
                    Debug.Log("OnTriggerStay2D：" + this.transform.name + "-" + other.gameObject.name);
                    //保y，改x
                    tempVector = windowParent.localPosition;
                    x = windowCollider.localPosition.x;
                    tempVector.x = 0f;
                    windowParent.localPosition = tempVector + new Vector3(x + dragFalse.itemLen, 0, 0);
                }
            }
        }

        //if (other.gameObject.name == "Col_4")
        //{
        //    if (windowParent.GetComponent<RectTransform>().pivot == new Vector2(0, 0) && windowCollider.GetComponent<RectTransform>().pivot == new Vector2(0, 0))
        //    {
        //        if (dragTrue.absorbFlag == true && dragTrue.allowMove == false && windowParent.gameObject == PositionControl.currentWindow)
        //        {
        //            //保x，改y
        //            tempVector = windowParent.localPosition;
        //            y = windowCollider.localPosition.y;
        //            tempVector.y = 0f;
        //            windowParent.localPosition = tempVector + new Vector3(0, y - dragFalse.itemWidth, 0);
        //        }
        //    }
        //}
        
    }
}
