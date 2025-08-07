using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageEvents : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite hoverSprite;
    public GameObject prefabToSpawn;
    public GameObject targetObject;

    public void OnPointerEnter(BaseEventData eventData)
    {
        Debug.Log("Pointer Entered");
        if (targetObject != null)
        {
            targetObject.GetComponent<UnityEngine.UI.Image>().sprite = hoverSprite;
        }
    }

    public void OnPointerExit(BaseEventData eventData)
    {
        Debug.Log("Pointer Exit");
        if (targetObject != null)
        {
            targetObject.GetComponent<UnityEngine.UI.Image>().sprite = defaultSprite;
        }
    }

    public void OnPointerClick(BaseEventData eventData)

    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Instantiate(prefabToSpawn, mousePosition, Quaternion.identity);
    }

}
