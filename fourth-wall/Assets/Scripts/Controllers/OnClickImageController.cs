using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClickImageController : MonoBehaviour
    , IPointerClickHandler {

    private ShowImageController showImageController;
    private GameObject imageSelectionGrid;

    void Awake()
    {
        imageSelectionGrid = GameObject.Find("ImageSelectionGrid");
        showImageController = imageSelectionGrid.GetComponent<ShowImageController>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        string imageName = gameObject.transform.Find("ImageName").GetComponent<UnityEngine.UI.Text>().text;
        showImageController.OpenImage(imageName);
    }
}
