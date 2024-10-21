using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragged : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Image image;
    public Transform transformParentCurrent;
    public GameObject[] Animation;

    public AudioManager SFX;

    private void Start()
    {
        SFX = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        SFX.PlayerSFX(SFX.pickItem);
        transformParentCurrent = transform.parent;
        transform.SetParent(transform.root); // trả về đối tượng cao cấp nhất
        image.raycastTarget = false;
        Animation[0].gameObject.SetActive(true);
        Animation[2].gameObject.SetActive(false);

    }
    public void OnDrag(PointerEventData eventData)
    {
      
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData) 
    {
        SFX.PlayerSFX(SFX.drop);
        transform.SetParent(transformParentCurrent);
        image.raycastTarget = true;
        Animation[1].gameObject.SetActive(true);
       
    }
}
