using UnityEngine;
using UnityEngine.EventSystems;

namespace Script
{
    public class ItemSlot : MonoBehaviour, IDropHandler
    {
 
        public GameObject Item
        {
            get
            {
                if (transform.childCount > 0 )
                {
                    return transform.GetChild(0).gameObject;
                }
 
                return null;
            }
        }
        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("OnDrop");
 
            if (!Item)
            {
 
                DragDrop.ItemBeingDragged.transform.SetParent(transform);
                DragDrop.ItemBeingDragged.transform.localPosition = new Vector2(0, 0);
 
            }
 
 
        }


 
 
 
 
    }
}