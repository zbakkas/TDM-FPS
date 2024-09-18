using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class inventorySeyn : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selecter ,noselectr;

    private void Awake()
    {
        Deselect();
    }
    public void select()
    {
        image.color = selecter;
    }
    public void Deselect()
    {
        image.color = noselectr;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            inventoruIteeem draggblritem = dropped.GetComponent<inventoruIteeem>();
            draggblritem.parentAfterDrag = transform;


        }

    }
}
