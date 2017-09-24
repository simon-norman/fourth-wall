using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowImageController : MonoBehaviour
    , IPointerClickHandler
{
    public GameObject room;
    public AppManager appManager;
    public GameObject imageNameText;
    public GameObject layoutCanvas;
    public GameObject imageSelectionGrid;

    void Awake()
    {
        layoutCanvas = GameObject.Find("LayoutCanvas");
        imageSelectionGrid = GameObject.Find("ImageSelectionGrid");
    }

    void Update()
    {
    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        imageSelectionGrid.SetActive(false);
        layoutCanvas.GetComponent<Image>().enabled = false;
        string imageName = imageNameText.GetComponent<UnityEngine.UI.Text>().text;
        appManager.ShowPano(imageName);
    }

    public void setMenuItemName(string itemName)
    {
        imageNameText.GetComponent<UnityEngine.UI.Text>().text = itemName;
    }
}