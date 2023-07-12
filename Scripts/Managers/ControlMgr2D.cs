using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMgr2D : MonoBehaviour
{
    public static ControlMgr2D inst;
    private void Awake(){
        inst = this;
    }

    private ControlMgr3D controlMgr3D;
    private CameraMgr cameraMgr;
    private InventoryMgr2D inventoryMgr2D;
    private CardMgr2D cardMgr2D;
    public AudioMgr AudioMgr;

    public bool cardUsed = false;
    public bool completeEvent = false, completeEffect = false;
    public bool eventFailed = false;

    public bool snack = false, technique = false, fungus = false, venom = false;
    public bool axe = false, matches = false, spear = false, sword = false;

    void Start()
    {
        controlMgr3D = ControlMgr3D.inst;
        cameraMgr = CameraMgr.inst;
        inventoryMgr2D = InventoryMgr2D.inst;
        cardMgr2D = CardMgr2D.inst;
        cardUsed = false;
        completeEvent = false;
        snack = false;
        technique = false;
        fungus = false;
        venom = false;
        axe = false;
        spear = false;
        sword = false;
        matches = false;

        //on gameboard load - sets the card currently in view to match the one in gameboard
        if(!controlMgr3D.manualOpen && controlMgr3D.cardPresent){
            inventoryMgr2D.setCardView(controlMgr3D.cardMgr3D.currCard);
            inventoryMgr2D.cardView.SetActive(true);
        }

        if(inventoryMgr2D.characterCard){
            inventoryMgr2D.inventoryObject.SetActive(false);
        }else{
            inventoryMgr2D.inventoryObject.SetActive(true);
        }

        //controlling companion dialogue for Tutorial Level, based on currCard cardtype
        if(InventoryMgr3D.inst.currLevel == 0){
            if(inventoryMgr2D.itemCard && InventoryMgr3D.inst.currInvTags.Count == 0){
                CompanionMgr.inst.setDialogue(0);
            }

            if(inventoryMgr2D.eventCard){
                CompanionMgr.inst.setDialogue(1);
            }

            if(inventoryMgr2D.effectCard){
                CompanionMgr.inst.setDialogue(2);
            }
        }
    }

    void Update()
    {
        // closing GameBoard scene on press of key 'Q'
        if(!inventoryMgr2D.eventCard && Input.GetKeyDown(KeyCode.Q)){
            AudioMgr.PlayCloseInv();
            //reactive the card in 3D world if it has not been used
            if (controlMgr3D.cardPresent)
            {
                if (!cardUsed)
                {
                    controlMgr3D.cardMgr3D.currCard.SetActive(true);
                }
                else
                {
                    controlMgr3D.cardPresent = false;
                }
            }

            if(inventoryMgr2D.characterCard){
                inventoryMgr2D.cardView.SetActive(false);
                inventoryMgr2D.inventoryObject.SetActive(true);
                CharacterMgr.inst.removeDialogue();
            }

            controlMgr3D.inventoryOpen = false;
            SceneManager.UnloadSceneAsync("GameBoard");
        }

        // control for retreating to village at 'R' keypress 
        // only event cards, not available in tutorial level
        if((InventoryMgr3D.inst.currLevel != 0) && (inventoryMgr2D.eventCard || inventoryMgr2D.bossEventCard) && Input.GetKeyDown(KeyCode.R)){
            InventoryMgr3D.inst.currLevel = 4;
            SceneManager.LoadScene("VillageCardWorld");
        }

        // adding item or effect card to inventory at keypress F
        // does not work on "TastySnack" effect
        if((inventoryMgr2D.itemCard || inventoryMgr2D.effectCard) && Input.GetKeyDown(KeyCode.F)){
            if(!controlMgr3D.cardMgr3D.currCard.CompareTag("TastySnack")){
                inventoryMgr2D.addCardToInv(controlMgr3D.cardMgr3D.currCard.GetComponent<Card>());
            }
            AudioMgr.PlayCard();
        }

        // use effect card on key press 'E'
        if(inventoryMgr2D.effectCard && Input.GetKeyDown(KeyCode.E)){
            completeEffect = inventoryMgr2D.completeEffectCard();
            cardUsed = completeEffect;
        }

        // ====================================
        // Event Completion Controls
        // ====================================

        // check for inventory keypresses when event card is active
        if(inventoryMgr2D.eventCard || inventoryMgr2D.bossEventCard){
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                AudioMgr.PlayCombinecard();
                completeEvent = inventoryMgr2D.completeEventCard(1);
            }else if(Input.GetKeyDown(KeyCode.Alpha2)){
                completeEvent = inventoryMgr2D.completeEventCard(2);
            }else if(Input.GetKeyDown(KeyCode.Alpha3)){
                completeEvent = inventoryMgr2D.completeEventCard(3);
            }else if(Input.GetKeyDown(KeyCode.Alpha4)){
                completeEvent = inventoryMgr2D.completeEventCard(4);
            }else if(Input.GetKeyDown(KeyCode.Alpha5)){
                completeEvent = inventoryMgr2D.completeEventCard(5);
            }else if(Input.GetKeyDown(KeyCode.Alpha6)){
                completeEvent = inventoryMgr2D.completeEventCard(6);
            }else if(Input.GetKeyDown(KeyCode.Alpha7)){
                completeEvent = inventoryMgr2D.completeEventCard(7);
            }
            cardUsed = completeEvent;
        }

        // if event completed: set effect + gained item cards active in 3D world
        if(completeEvent){
            if(snack){
                controlMgr3D.cardMgr3D.tastySnack.SetActive(true);
                
                if(InventoryMgr3D.inst.currLevel == 1)
                    controlMgr3D.cardMgr3D.tastySnack1.SetActive(true);
            }

            if(technique)
                controlMgr3D.cardMgr3D.improvedTechnique.card.SetActive(true);

            if(venom)
                controlMgr3D.cardMgr3D.venom.card.SetActive(true);

            if(axe){
                controlMgr3D.cardMgr3D.axe.transform.SetParent(controlMgr3D.cardMgr3D.currCard.transform.parent.gameObject.transform, false);
                controlMgr3D.cardMgr3D.axe.card.SetActive(true);
            }

            if(spear){
                controlMgr3D.cardMgr3D.spear.transform.SetParent(controlMgr3D.cardMgr3D.currCard.transform.parent.gameObject.transform, false);
                controlMgr3D.cardMgr3D.spear.card.SetActive(true);
            }

            if(sword){
                controlMgr3D.cardMgr3D.sword.transform.SetParent(controlMgr3D.cardMgr3D.currCard.transform.parent.gameObject.transform, false);
                controlMgr3D.cardMgr3D.sword.card.SetActive(true);
            }

            if(matches)
                controlMgr3D.cardMgr3D.matches.card.SetActive(true);

            if(fungus)
                controlMgr3D.cardMgr3D.fungus.card.SetActive(true);

            controlMgr3D.inventoryOpen = false;
            controlMgr3D.cardPresent = false;
            SceneManager.UnloadSceneAsync("GameBoard");
        }

        // if event failed: wipe inventory and return to village card world
        if(eventFailed){
            if(!InventoryMgr3D.inst.fungus){
                InventoryMgr3D.inst.wipeInventory();
                InventoryMgr3D.inst.currLevel = 4;
                SceneManager.LoadScene("VillageCardWorld");
            }else{
                InventoryMgr3D.inst.useFungusEffect();
                controlMgr3D.cardMgr3D.currCard.SetActive(false);
                controlMgr3D.cardPresent = false;
                controlMgr3D.inventoryOpen = false;
                SceneManager.UnloadSceneAsync("GameBoard");
            }   
        }

        // remove companion dialogue upon card use
        if(cardUsed || completeEvent){
            CompanionMgr.inst.removeDialogue();
        }
    }
}
