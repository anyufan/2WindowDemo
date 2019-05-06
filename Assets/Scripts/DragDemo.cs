using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDemo : ButtonBase, IPointerDownHandler, IPointerUpHandler
{
    Transform parent;
    RotateWindow rotateButton;
    public bool allowMove = false;
    public bool absorbFlag = false;//吸附标志位
    int x, y;
    

    void Start()
    {

        parent = this.transform.parent;
        rotateButton = this.transform.Find("Button").GetComponent<RotateWindow>();
        tempValue = 25;
        itemWidth = 200;
        itemLen = 100;
    }

    public Vector3 dir;

    float dx;
    float dy;

/// <summary>
/// 箱子的宽
/// </summary>
    public float itemWidth { get; set; }
    /// <summary>
    /// 箱子的长
    /// </summary>
    public float itemLen { get; set; }
    float tempValue;

    public Vector3 getCenterPoitn()
    {
        if(rotateButton.rangeFlag==true)
            return new Vector3(this.transform.position.x + itemWidth / 2, this.transform.position.y - itemLen / 2);
        else
            return new Vector3(this.transform.position.x + itemLen / 2, this.transform.position.y - itemWidth / 2);
    }


    void Update()
    {

        if (allowMove == true)
        {
          //  if (Input.mousePosition.x - Mathf.Floor(Input.mousePosition.x) > 0.5)
          //      x = (int)Mathf.Ceil(Input.mousePosition.x);
          //  else x = (int)Mathf.Floor(Input.mousePosition.x);
          //  
          //  if (Input.mousePosition.y - Mathf.Floor(Input.mousePosition.y) > 0.5)
          //      y = (int)Mathf.Ceil(Input.mousePosition.y);
          //  else y = (int)Mathf.Floor(Input.mousePosition.y);
            //Debug.Log("x:" + x + " y:" + y);
            dx = getCenterPoitn().x - Input.mousePosition.x;
            dy = getCenterPoitn().y - Input.mousePosition.y;
            //print("dx = " + dx);
            if (Mathf.Abs(dx) > tempValue)
            {
                absorbFlag = false;
                this.transform.position = this.transform.position - Vector3.Normalize(new Vector3(dx, 0)) * tempValue;
                absorbFlag = true;
            }

            if (Mathf.Abs(dy) > tempValue)
            {
                absorbFlag = false;
                this.transform.position = this.transform.position - Vector3.Normalize(new Vector3(0, dy)) * tempValue;
                absorbFlag = true;
            }
            //this.transform.position = new Vector3(x,y,0) - new Vector3(100, -50, 0);


            dir = Vector3.Normalize(this.GetComponent<RectTransform>().localPosition - new Vector3());
            dir = new Vector3(dir.x, 0, dir.y);
  
        }

    }

    public override void OnClickBtn()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        for (int i = 0; i < PositionControl.windowArray.Length; i++)
        {
            if (this.transform.gameObject == PositionControl.windowArray[i])
                PositionControl.currentWindow = PositionControl.windowArray[i];
        }
            allowMove = true;
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        absorbFlag = true;
        
        
        allowMove = false;
        
        
    }

    public void AddAbsorption()
    {
        this.transform.Find("Col_1").gameObject.AddComponent<AbsorbCol_1>();
        this.transform.Find("Col_2").gameObject.AddComponent<AbsorbCol_2>();
        this.transform.Find("Col_3").gameObject.AddComponent<AbsorbCol_3>();
        this.transform.Find("Col_4").gameObject.AddComponent<AbsorbCol_4>();
    }
    public void DestroyAbsorption()
    {
        GameObject.Destroy(this.transform.Find("Col_1").gameObject.GetComponent<AbsorbCol_1>());
        GameObject.Destroy(this.transform.Find("Col_2").gameObject.GetComponent<AbsorbCol_2>());
        GameObject.Destroy(this.transform.Find("Col_3").gameObject.GetComponent<AbsorbCol_3>());
        GameObject.Destroy(this.transform.Find("Col_4").gameObject.GetComponent<AbsorbCol_4>());
    }

}
