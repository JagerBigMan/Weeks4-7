using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageEvents : MonoBehaviour, IPointerClickHandler  //Used this site to figure out how to use the OnClick function https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.IPointerClickHandler.html
{
    public Sprite defaultSprite;
    public Sprite hoverSprite;
    public GameObject prefabToSpawn;
    public GameObject targetObject;

    public void OnPointerEnter(BaseEventData eventData) //I used this site to learn how to use BaseEventData https://stackoverflow.com/questions/68559980/how-to-access-dynamic-baseeventdata-from-c-sharp-script-using-eventtrigger-unit
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

    public void OnPointerClick(PointerEventData eventData)      //This method will spawn a falling triangle prefab when clicked on the UI image.

    {
        Debug.Log("Clicked");
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Instantiate(prefabToSpawn, mousePosition, Quaternion.identity);
    }

}
