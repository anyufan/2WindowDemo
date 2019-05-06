using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAbsorb_2 : MonoBehaviour {
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
            y = windowCollider.localPosition.y;
            tempVector.y = 0f;
            if (windowCollider.pivot == new Vector2(0, 1)) 
                windowCollider.localPosition = tempVector + new Vector3(0, -windowParent.rect.height + windowCollider.rect.height, 0);
            if(windowCollider.pivot == new Vector2(0, 0))
                windowCollider.localPosition = tempVector + new Vector3(0, -windowParent.rect.height + windowCollider.rect.width, 0);
        }

    }
}
