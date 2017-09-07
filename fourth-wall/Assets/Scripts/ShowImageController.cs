using UnityEngine;
using UnityEngine.EventSystems; // 1

public class ShowImageController : MonoBehaviour
    , IPointerClickHandler
{
    public AppManager appmanager;

    void Awake()
    {
    }

    void Update()
    {
    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        string imageName = gameObject.GetComponent<UnityEngine.UI.Image>().sprite.name;
        appmanager.ShowPano(imageName);
    }
}