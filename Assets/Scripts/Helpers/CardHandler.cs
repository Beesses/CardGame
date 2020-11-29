using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static bool dragDisabled = false;
    private Image _image;

    public static CardHandler draggedItem;
    public static GameObject icon;
    public GameObject PrefabForTable;
    private static GameObject Discription;

    public delegate void DragEvent(CardHandler item);
    public static event DragEvent OnItemDragStartEvent;
    public static event DragEvent OnItemDragEndEvent;

    private static Canvas canvas;
    private static string canvasName = "DragAndDropCanvas";
    private static int canvasSortOrder = 100;

    void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(3, 3, 3);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (dragDisabled == false)
        {
            draggedItem = this;


            icon = new GameObject();
            icon.transform.SetParent(canvas.transform);
            icon.name = "Icon";
            Image myImage = transform.GetChild(0).gameObject.GetComponent<Image>();
            myImage.raycastTarget = false;
            Image iconImage = icon.AddComponent<Image>();
            iconImage.raycastTarget = false;
            iconImage.sprite = myImage.sprite;
            RectTransform iconRect = icon.GetComponent<RectTransform>();
            RectTransform myRect = GetComponent<RectTransform>();
            iconRect.pivot = new Vector2(0.5f, 0.5f);
            iconRect.anchorMin = new Vector2(0.5f, 0.5f);
            iconRect.anchorMax = new Vector2(0.5f, 0.5f);
            iconRect.sizeDelta = new Vector2(myRect.rect.width, myRect.rect.height);
            if (OnItemDragStartEvent != null)
            {
                OnItemDragStartEvent(this);
            }
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if (icon != null)
        {
            icon.transform.position = Input.mousePosition;
        }
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 200) && hit.transform.tag == "Table")
        {
            GameObject Card = Instantiate(PrefabForTable, hit.point, Quaternion.Euler(35,0,0));
            Card.transform.position += Vector3.up * 3;
            ResetConditions();
            Destroy(gameObject);
        }
        else
        {
            ResetConditions();
        }
    }

    private void ResetConditions()
    {
        if (icon != null)
        {
            Destroy(icon);
        }
        if (OnItemDragEndEvent != null)
        {
            OnItemDragEndEvent(this);
        }
        draggedItem = null;
        icon = null;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }
}
