using UnityEngine;
using UnityEngine.EventSystems;

namespace Script
{
    public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] Canvas canvas;
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        public static GameObject ItemBeingDragged;
        Vector3 _startPosition;
        Transform _parent;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvasGroup.alpha = 0.6f;
            _canvasGroup.blocksRaycasts = false;
            _startPosition = transform.position;
            _parent = transform.parent;
            ItemBeingDragged = gameObject;
            transform.SetParent(_parent.root);
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            ItemBeingDragged = null;
            if (transform.parent == _parent || transform.parent == transform.root)
            {
                transform.position = _startPosition;
                transform.SetParent(_parent);
 
            }
 
            Debug.Log("OnEndDrag");
            _canvasGroup.alpha = 1f;
            _canvasGroup.blocksRaycasts = true;
        }
    }
}