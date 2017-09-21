using UnityEngine;
using UnityEngine.EventSystems; // 1

public class ShowImageController : MonoBehaviour
    , IPointerClickHandler
{
    public GameObject room;
    public AppManager appManager;
    public GameObject imageNameText;

    void Awake()
    {

    }

    void Update()
    {
    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        string imageName = imageNameText.GetComponent<UnityEngine.UI.Text>().text;
        appManager.ShowPano(imageName);
    }

    public void setMenuItemName(string itemName)
    {
        imageNameText.GetComponent<UnityEngine.UI.Text>().text = itemName;
    }
}