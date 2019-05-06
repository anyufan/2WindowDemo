using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbsorbCol_1 : MonoBehaviour {
    RectTransform windowParent;
    RectTransform windowCollider;
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
        //windowCollider = other.transform.parent.GetComponent<RectTransform>();
        //dragFalse = windowCollider.GetComponent<DragDemo>();

    }
    void OnTriggerExit2D(Collider2D other)
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        //windowCollider为被碰撞的物体，windowParent为正在拖动的这个窗体本身，应该是拖动的窗体被吸附到windowCollider
        //上，dragTrue和dragFalse分别为windowParent和windowCollider的拖动脚本，我在其中设置了吸附标志变量用于控制窗体只有
        //在松开鼠标的那一刻才会发生吸附效果。
        windowCollider = other.transform.parent.GetComponent<RectTransform>();
        dragFalse = windowCollider.GetComponent<DragDemo>();
        if (other.gameObject.name == "Col_2")//通过判断与不同的碰撞体碰撞，以确定是哪一种碰撞情况
        {
            //通过判断pivot的值来判断该窗体是否经过旋转，此时是横放还是竖放。
            if (windowParent.GetComponent<RectTransform>().pivot == new Vector2(0, 1) && windowCollider.GetComponent<RectTransform>().pivot == new Vector2(0, 1))
            {
                //currentWindow代表当前拖动的窗体，即保证每次只有一个窗体的触发器启用，不然会出现抖动以及其他未知的问题
                //这点很重要，之前因为每个窗体都有四个碰撞体，且都挂有相同的脚步，互相很容易产生干扰，要保证每次吸附
                //只有一个碰撞体脚本生效，对其产生吸附，而这个窗体就是被拖动的那个窗体，
                //通过思考想到了先存储所有窗体的引用，然后在拖动一个窗体的同时，保存该拖动窗体的引用，在发生吸附作用
                //前进行判断，以保证一次只有一条边的吸附。

                /*情况A，横放窗体碰横放窗体*/
                if (dragTrue.absorbFlag == true && dragTrue.allowMove == false && windowParent.gameObject == PositionControl.currentWindow)
                {
                    
                    Debug.Log("OnTriggerStay2D：" + this.transform.name + "-" + other.gameObject.name);
                    //以下产生具体的吸附效果，需要根据吸附情况的不同进行相应计算和重写
                    tempVector = windowParent.localPosition;
                    y = windowCollider.localPosition.y;
                    tempVector.y = 0f;
                    windowParent.localPosition = tempVector + new Vector3(0, y - 100, 0);
                }
            }
            /*情况D，竖放窗体碰撞竖放窗体*/
            if (windowParent.GetComponent<RectTransform>().pivot == new Vector2(0, 0) && windowCollider.GetComponent<RectTransform>().pivot == new Vector2(0, 0))
            {
                if (dragTrue.absorbFlag == true && dragTrue.allowMove == false && windowParent.gameObject == PositionControl.currentWindow)
                {
                    Debug.Log("OnTriggerStay2D：" + this.transform.name + "-" + other.gameObject.name);
                    //保y，改x
                    tempVector = windowParent.localPosition;
                    x = windowCollider.localPosition.x;
                    tempVector.x = 0f;
                    windowParent.localPosition = tempVector + new Vector3(x - dragFalse.itemLen, 0, 0);
                }
            }

        }
        /*情况B，竖放窗体碰撞横放窗体*/
        if (other.gameObject.name == "Col_3")
        {
            if (windowParent.GetComponent<RectTransform>().pivot == new Vector2(0, 0) && windowCollider.GetComponent<RectTransform>().pivot == new Vector2(0, 1))
            {
                if (dragTrue.absorbFlag == true && dragTrue.allowMove == false && windowParent.gameObject == PositionControl.currentWindow)
                {
                    Debug.Log("OnTriggerStay2D：" + this.transform.name + "-" + other.gameObject.name);
                    //保y，改x
                    tempVector = windowParent.localPosition;
                    x = windowCollider.localPosition.x;
                    tempVector.x = 0f;
                    windowParent.localPosition = tempVector + new Vector3(x - dragFalse.itemLen, 0, 0);
                }
            }
        }
        /*情况C，横放窗体碰撞竖放窗体*/
        if (other.gameObject.name == "Col_4")
        {
            if (windowParent.GetComponent<RectTransform>().pivot == new Vector2(0, 1) && windowCollider.GetComponent<RectTransform>().pivot == new Vector2(0, 0))
            {
                if (dragTrue.absorbFlag == true && dragTrue.allowMove == false && windowParent.gameObject == PositionControl.currentWindow)
                {
                    Debug.Log("OnTriggerStay2D：" + this.transform.name + "-" + other.gameObject.name);
                    //保x，改y
                    tempVector = windowParent.localPosition;
                    y = windowCollider.localPosition.y;
                    tempVector.y = 0f;
                    windowParent.localPosition = tempVector + new Vector3(0, y  - dragFalse.itemWidth, 0);
                }
            }
        }

        // if (other.gameObject.name == "Col_2")
        //{
        //    if (windowParent.GetComponent<RectTransform>().pivot == new Vector2(0, 0) && windowCollider.GetComponent<RectTransform>().pivot == new Vector2(0, 0))
        //    {
        //        if (dragTrue.absorbFlag == true && dragTrue.allowMove == false && windowParent.gameObject == PositionControl.currentWindow)
        //        {
        //            //保y，改x
        //            tempVector = windowParent.localPosition;
        //            x = windowCollider.localPosition.x;
        //            tempVector.x = 0f;
        //            windowParent.localPosition = tempVector + new Vector3(x - dragFalse.itemLen, 0, 0);
        //        }
        //    }
        //}
    }
}
