using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour
{
    private InventoryMgr2D inventoryMgr;
    void Start()
    {
        inventoryMgr = InventoryMgr2D.inst;
    }

    public GameObject selectedCard;
    public bool mouseSelect;

    private Vector3 offset;

    void Update()
    {
        // handling drag and drop movement
        if(Input.GetMouseButtonDown(0))
        {
            if(inventoryMgr.companionCard){
                startDragAndDrop();
<<<<<<< HEAD
            }else if(inventoryMgr2D.itemCard){
<<<<<<< HEAD
                //startDragAndDrop();
=======
            }else if(inventoryMgr.itemCard){
                startDragAndDrop();
>>>>>>> parent of 358aa00 (Animating Boss Kraken (Idle and Damage))
=======
                startDragAndDrop();
>>>>>>> parent of 22b17cb (all changes before class)
            }
        }

        // if mouse is pressed down on companion card, move game object on screen with mouse movement
        if(mouseSelect)
        {
            selectedCard.transform.position = Input.mousePosition + offset;
        }

        // reseting mouseSelect on mouse up/release
        if(mouseSelect && Input.GetMouseButtonUp(0))
        {
            selectedCard = null;
            mouseSelect = false;
        }
    }

    void FixedUpdate(){
        if(mouseSelect){
            // when cardView overlaps with companion slot, set companion sprite
            if (inventoryMgr.companionCard && Utils.cardsOverlap(inventoryMgr.cardView.GetComponent<RectTransform>(), CompanionMgr.inst.area.GetComponent<RectTransform>())) {
                inventoryMgr.setCompanionSprite();
                CompanionMgr.inst.area.SetActive(false);
            }else if (inventoryMgr.itemCard && Utils.cardsOverlap(inventoryMgr.cardView.GetComponent<RectTransform>(), InventoryMgr2D.inst.currPanel[InventoryMgr3D.inst.currInvTags.Count].GetComponent<RectTransform>())) {
                inventoryMgr.addCardToInv(CardMgr3D.inst.currCard.GetComponent<Card>());
            }
        }
    }

    public void startDragAndDrop(){
        // send graphics raycast (for UI detection) at screen from mouse click position
        GraphicRaycaster graphicsRaycaster = this.GetComponent<GraphicRaycaster>();

        PointerEventData ped = new PointerEventData(null);
        ped.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        graphicsRaycaster.Raycast(ped, results);

        foreach (RaycastResult result in results)
        {
            // if raycast encounters "cardview" with companion card:
            // set mouseSelect to true, set offset between mouse position and game object
            if(result.gameObject.CompareTag("CardView")){
                selectedCard = result.gameObject;
                mouseSelect = true;
                offset = selectedCard.transform.position - Input.mousePosition;
            }
        }
    }
}
