using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAbsorb_3 : MonoBehaviour {
    public RectTransform windowParent;
    public RectTransform windowCollider;
    public DragDemo dragTrue;
    public DragDemo dragFalse;
    public Vector3 tempVector;
    float x, y;

    void Start()
    {
        windowParent = this.transform.parent.GetComponent<RectTransform>();
    }


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }
    void OnTriggerExit2D(Collider2D other)
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        windowCollider = other.transform.parent.GetComponent<RectTransform>();
        dragTrue = windowCollider.GetComponent<DragDemo>();
        if (dragTrue.absorbFlag == true && dragTrue.allowMove == false && windowCollider.gameObject == PositionControl.currentWindow)
        {
            tempVector = windowCollider.localPosition;
            x = windowCollider.localPosition.x;
            tempVector.x = 0f;
            windowCollider.localPosition = tempVector;
        }

    }
}
