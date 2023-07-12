using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
CardMgr3D is a child of CardMgr class
Designed to manage all cards in 3D (CardWorld) scene
*/
public class CardMgr3D : MonoBehaviour
{
    public static CardMgr3D inst;
    private void Awake(){
        inst = this;
    }

    public List<Card> allItemCards;
    public List<Card> allEventCards;
    public Card improvedTechnique, venom, fungus, matches;
    //public List<Card> axes;
    public Card axe, spear, sword;

    public List<GameObject> itemSlots;
    public List<GameObject> eventSlots;
    public List<GameObject> effectSlots;
    public GameObject currCard;  
    public GameObject tastySnack, tastySnack1;
    public GameObject stick0, stick1, leaf, rock;
    public GameObject campfire0, campfire1;
    public Card cookie;

    void Start()
    {
        //Loading Cards randomly in gameplay for levels 1 + 2
        if(InventoryMgr3D.inst.currLevel == 1 || InventoryMgr3D.inst.currLevel == 2){

            //randomly load item Cards into available slots
            foreach(GameObject itemSlot in itemSlots){
                int random = Random.Range(1, allItemCards.Count);
                allItemCards[(random - 1)].transform.SetParent(itemSlot.transform, false);
                allItemCards[(random -1)].card.SetActive(true);
                allItemCards.RemoveAt(random - 1);
            }  

            //randomly load event cards into available slots
            int index = 0;
            foreach(GameObject eventSlot in eventSlots){
                int random = Random.Range(1, allEventCards.Count);
                allEventCards[(random - 1)].transform.SetParent(eventSlot.transform, false);
                allEventCards[(random -1)].card.SetActive(true);
                
                //for specific event cards, set corresponding location of items/effects for after
                if(allEventCards[(random -1)].CompareTag("Squirrel"))
                {
                    improvedTechnique.transform.SetParent(effectSlots[index].transform, false);
                }else if(allEventCards[(random -1)].CompareTag("Snake"))
                {
                    venom.transform.SetParent(effectSlots[index].transform, false);
                }else if(allEventCards[(random -1)].CompareTag("Lake"))
                {
                    fungus.transform.SetParent(effectSlots[index].transform, false);
                }else if(allEventCards[(random -1)].CompareTag("Treehouse")){
                    matches.transform.SetParent(effectSlots[index].transform, false);
                }

                allEventCards.RemoveAt(random - 1);
                index++;
            }

            //check if levels 1 or 2 have been played through previously
            if((InventoryMgr3D.inst.currLevel == 1) && InventoryMgr3D.inst.levelOneComplete){
                clearSticks();
            }else if((InventoryMgr3D.inst.currLevel == 2) && InventoryMgr3D.inst.levelTwoComplete){
                clearSticks();
            }
        }else if(InventoryMgr3D.inst.currLevel == 3){
            //for game level 3 (boss level) randomly load events into available slots
            foreach(GameObject eventSlot in eventSlots){
                int random = Random.Range(1, allEventCards.Count);
                allEventCards[(random - 1)].transform.SetParent(eventSlot.transform, false);
                allEventCards[(random -1)].card.SetActive(true);

                allEventCards.RemoveAt(random - 1);
            }
        }
    }

    // when an item is used in game levels 1 or 2, 
    // call this function to make the corresponding item card on the opposite path dissapear
    public void hideOtherItem()
    {
        string currTag = currCard.transform.parent.gameObject.tag;
        string oppositeTag = currTag;
        if(System.String.Equals(currTag, "L0"))
            oppositeTag = "R0";
        else if(System.String.Equals(currTag, "R0"))
            oppositeTag = "L0";

        if(System.String.Equals(currTag, "L1"))
            oppositeTag = "R1";
        else if(System.String.Equals(currTag, "R1"))
            oppositeTag = "L1";

        if(System.String.Equals(currTag, "L2"))
            oppositeTag = "R2";
        else if(System.String.Equals(currTag, "R2"))
            oppositeTag = "L2";

        foreach(GameObject itemSlot in itemSlots){
            if(itemSlot.CompareTag(oppositeTag))
                itemSlot.SetActive(false);
        }
    }

    // when an event is completed in game levels 1 or 2, 
    // call this function to make the corresponding event card on the opposite path dissapear
    public void hideOtherEvent()
    {
        string currTag = currCard.transform.parent.gameObject.tag;
        string oppositeTag = currTag;
        if(System.String.Equals(currTag, "L0"))
            oppositeTag = "R0";
        else if(System.String.Equals(currTag, "R0"))
            oppositeTag = "L0";

        if(System.String.Equals(currTag, "L1"))
            oppositeTag = "R1";
        else if(System.String.Equals(currTag, "R1"))
            oppositeTag = "L1";

        if(System.String.Equals(currTag, "L2"))
            oppositeTag = "R2";
        else if(System.String.Equals(currTag, "R2"))
            oppositeTag = "L2";

        if(System.String.Equals(currTag, "L3"))
            oppositeTag = "R3";
        else if(System.String.Equals(currTag, "R3"))
            oppositeTag = "L3";

        foreach(GameObject eventSlot in eventSlots){
            if(eventSlot.CompareTag(oppositeTag))
                eventSlot.SetActive(false);
        }
    }

    // function to set tastysnack event progression inactive
    public void clearSticks(){
        tastySnack.SetActive(false);
        tastySnack1.SetActive(false);
        campfire0.SetActive(false);
        campfire1.SetActive(false);
        stick0.SetActive(false);
        stick1.SetActive(false);
    }
}
