using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //private RectTransform rectTransform;
    [SerializeField] private GameObject canvas;

    private GameObject objectDragInstance;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        //this.rectTransform = GetComponent<RectTransform>();

        this.canvas = GameObject.FindGameObjectWithTag("Canvas");
        this.canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("On Drag Begin");
        this.canvasGroup.blocksRaycasts = false;
        this.objectDragInstance = Instantiate(this.gameObject, this.canvas.transform);
        this.objectDragInstance.transform.position = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("On Drag");
        this.objectDragInstance.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("On Drag End");
        this.canvasGroup.blocksRaycasts = true;
        Destroy(this.objectDragInstance);
    }
}
