using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//InventoryMgr is designed to control the visuals and data of cards in player's inventory
public class InventoryMgr2D : MonoBehaviour
{
    public static InventoryMgr2D inst;
    private void Awake(){
        inst = this;
    }

    public GameObject cardView;
    
    public GameObject inventoryObject;

    private InventoryMgr3D inventoryMgr3D;
    private CardMgr3D cardMgr3D;
    private CompanionMgr companionMgr;
    public AudioMgr AudioMgr;

    public List<GameObject> inventoryPanels4;
    public List<GameObject> inventoryPanels5;
    public List<GameObject> inventoryPanels6;
    public List<GameObject> inventoryPanels7;
    public List<GameObject> currPanel;
    public int currInventoryIndex;

    public List<GameObject> invPanelsParentObjects;

    public Sprite CAT, BLANK;
    public Sprite STICK, ROCK, LEAF, COOKIE, SHIELD, CANDLE, ROPE, FEATHER, AXE, NEEDLE, ARROWHEAD, DAGGER, MATCHES, SWORD, SPEAR;
    public Sprite CAMPFIRE, SQUIRREL, SNAKE, TREEHOUSE, LAKE, SWORDSTONE, CABIN, CABIN2, CLIFF, WELL, LUMP, PERFECTSTICK;
    public Sprite ATTACK, SLAM, FLING, GRAB, TRIP, RUN;
    public Sprite TASTYSNACK, IMPROVEDTECH, VENOM, FUNGUS;
    public Sprite GRANNY, FOOL, LOVER1, LOVER2;

    public Sprite currSprite;

    public GameObject dragAndDropInstructs;
    public GameObject qInstruct, rInstruct;

    public bool itemCard = false, companionCard = false, eventCard = false, effectCard = false, bossEventCard = false, characterCard = false;
    public bool granny = false, fool = false, lover1 = false, lover2 = false;
    public bool itemInInventory = false;
    public bool venomEffect = false, improvedTechniqueEffect = false, fungusEffect = false;

    void Start()
    {
        inventoryMgr3D = InventoryMgr3D.inst;
        companionMgr = CompanionMgr.inst;
        cardMgr3D = CardMgr3D.inst;

        setInventory();
        rInstruct.SetActive(false);
    }

    void Update()
    {
        if(companionCard){
            dragAndDropInstructs.SetActive(true);
        }else{
            dragAndDropInstructs.SetActive(false);
        }
    }

    //sets the child of the current card displaying in the center of the UI to currCard
    public void setCardView(GameObject currentCard)
    {
        itemCard = false;
        companionCard = false;
        eventCard = false;
        effectCard = false;
        bossEventCard = false;
        characterCard = false;
        granny = false;
        fool = false;
        lover1 = false;
        lover2 = false;

        if(currentCard.CompareTag("Cat"))
        {
            currSprite = CAT;
            companionCard = true;
        }
        
        if(currentCard.CompareTag("Stick"))
        {
            currSprite = STICK;
            itemCard = true;   
        }else if(currentCard.CompareTag("Rock"))
        {
            currSprite = ROCK;   
            itemCard = true;
        }else if(currentCard.CompareTag("Leaf"))
        {
            currSprite = LEAF;  
            itemCard = true; 
        }else if(currentCard.CompareTag("Cookie"))
        {
            currSprite = COOKIE;
            itemCard = true;   
        }else if(currentCard.CompareTag("Shield"))
        {
            currSprite = SHIELD;
            itemCard = true;   
        }else if(currentCard.CompareTag("Candle"))
        {
            currSprite = CANDLE;
            itemCard = true;   
        }else if(currentCard.CompareTag("Rope"))
        {
            currSprite = ROPE;
            itemCard = true;   
        }else if(currentCard.CompareTag("Feather"))
        {
            currSprite = FEATHER;
            itemCard = true;   
        }else if(currentCard.CompareTag("Axe"))
        {
            currSprite = AXE;
            itemCard = true;   
        }else if(currentCard.CompareTag("Needle"))
        {
            currSprite = NEEDLE;
            itemCard = true;   
        }else if(currentCard.CompareTag("Arrowhead"))
        {
            currSprite = ARROWHEAD;
            itemCard = true;   
        }else if(currentCard.CompareTag("Dagger"))
        {
            currSprite = DAGGER;
            itemCard = true;   
        }else if(currentCard.CompareTag("Matches"))
        {
            currSprite = MATCHES;
            itemCard = true;   
        }else if(currentCard.CompareTag("Sword"))
        {
            currSprite = SWORD;
            itemCard = true;   
        }else if(currentCard.CompareTag("Spear"))
        {
            currSprite = SPEAR;
            itemCard = true;   
        }

        if(currentCard.CompareTag("Campfire"))
        {
            currSprite = CAMPFIRE; 
            eventCard = true;
        }else if(currentCard.CompareTag("Squirrel"))
        {
            currSprite = SQUIRREL; 
            eventCard = true;
        }else if(currentCard.CompareTag("Snake"))
        {
            currSprite = SNAKE; 
            eventCard = true;
        }else if(currentCard.CompareTag("Treehouse"))
        {
            currSprite = TREEHOUSE; 
            eventCard = true;
        }else if(currentCard.CompareTag("Lake"))
        {
            currSprite = LAKE; 
            eventCard = true;
        }else if(currentCard.CompareTag("Swordstone"))
        {
            currSprite = SWORDSTONE; 
            eventCard = true;
        }else if(currentCard.CompareTag("Cabin"))
        {
            currSprite = CABIN; 
            eventCard = true;
        }else if(currentCard.CompareTag("Cabin2"))
        {
            currSprite = CABIN2; 
            eventCard = true;
        }else if(currentCard.CompareTag("Cliff"))
        {
            currSprite = CLIFF; 
            eventCard = true;
        }else if(currentCard.CompareTag("Well"))
        {
            currSprite = WELL; 
            eventCard = true;
        }else if(currentCard.CompareTag("Lump"))
        {
            currSprite = LUMP; 
            eventCard = true;
        }else if(currentCard.CompareTag("PerfectStick"))
        {
            currSprite = PERFECTSTICK; 
            eventCard = true;
        }

        if(currentCard.CompareTag("TastySnack"))
        {
            currSprite = TASTYSNACK;
            effectCard = true;
        }else if(currentCard.CompareTag("ImprovedTechnique"))
        {
            currSprite = IMPROVEDTECH;
            effectCard = true;
        }else if(currentCard.CompareTag("Fungus"))
        {
            currSprite = FUNGUS;
            effectCard = true;
        }else if(currentCard.CompareTag("Venom"))
        {
            currSprite = VENOM;
            effectCard = true;
        }

        if(currentCard.CompareTag("Attack")){
            currSprite = ATTACK;
            bossEventCard = true;
        }else if(currentCard.CompareTag("Slam")){
            currSprite = SLAM;
            bossEventCard = true;
        }else if(currentCard.CompareTag("Fling")){
            currSprite = FLING;
            bossEventCard = true;
        }else if(currentCard.CompareTag("Grab")){
            currSprite = GRAB;
            bossEventCard = true;
        }else if(currentCard.CompareTag("Trip")){
            currSprite = TRIP;
            bossEventCard = true;
        }if(currentCard.CompareTag("Run")){
            currSprite = RUN;
            bossEventCard = true;
        }

        if(currentCard.CompareTag("Granny")){
            currSprite = GRANNY;
            granny = true;
            characterCard = true;
        }else if(currentCard.CompareTag("Fool")){
            currSprite = FOOL;
            fool = true;
            characterCard = true;
        }else if(currentCard.CompareTag("Lover1")){
            currSprite = LOVER1;
            lover1 = true;
            characterCard = true;
        }else if(currentCard.CompareTag("Lover2")){
            currSprite = LOVER2;
            lover2 = true;
            characterCard = true;
        }

        cardView.GetComponent<UnityEngine.UI.Image>().sprite = currSprite;

        if((eventCard || bossEventCard) && (inventoryMgr3D.currLevel != 0)){
            qInstruct.SetActive(false);
            rInstruct.SetActive(true);
        }
    }

    // Setting the inventory based on max cards + curr inventory in InventoryMgr3D
    public void setInventory()
    {
        currInventoryIndex = inventoryMgr3D.maxCards - 4;
        foreach(GameObject panelObject in invPanelsParentObjects)
            panelObject.SetActive(false);
        invPanelsParentObjects[currInventoryIndex].SetActive(true);

        if(inventoryMgr3D.maxCards == 4)
            currPanel = inventoryPanels4;
        else if(inventoryMgr3D.maxCards == 5)
            currPanel = inventoryPanels5;
        else if(inventoryMgr3D.maxCards == 6)
            currPanel = inventoryPanels6;
        else if(inventoryMgr3D.maxCards == 7)
            currPanel = inventoryPanels7;

        //load sprites of all cards in curr inventory
        int index = 0;
        foreach (Sprite s in inventoryMgr3D.currInvSprites)
        {
            currPanel[index].GetComponent<UnityEngine.UI.Image>().sprite = s;
            index++;
        }
    }

    // adding curr card in carview to inventory
    public void addCardToInv(Card currCard)
    {
        if(currCard.tag.Equals("Fungus"))
            inventoryMgr3D.fungus = true;

        foreach(string invTag in InventoryMgr3D.inst.currInvTags){
            if(invTag.Equals(currCard.tag)){
                if(!invTag.Equals("Axe") && !invTag.Equals("Spear") && !invTag.Equals("Sword"))
                    itemInInventory = true;
            }
        }

        if(inventoryMgr3D.currInvTags.Count < inventoryMgr3D.maxCards){
            if(!itemInInventory){
                inventoryMgr3D.currInvTags.Add(currCard.card.tag);
                inventoryMgr3D.currInvSprites.Add(currSprite);
                inventoryMgr3D.currInvWeapon.Add(currCard.weapon);
                currPanel[(inventoryMgr3D.currInvTags.Count - 1)].GetComponent<UnityEngine.UI.Image>().sprite = currSprite;
            }else{
                Debug.Log("Item Already in Inventory");
                cardView.SetActive(false);
                ControlMgr2D.inst.cardUsed = true;
            }
            cardView.SetActive(false);
            ControlMgr2D.inst.cardUsed = true;

            // for Tutorial Level, set tutorialComplete upon user adding either rock or leaf item to inv
            if(inventoryMgr3D.currLevel == 0){
                if(currCard.card.CompareTag("Rock")){
                    CardMgr3D.inst.leaf.SetActive(false);
                    ControlMgr3D.inst.levelComplete = true;
                    inventoryMgr3D.tutorialComplete = true;
                }else if(currCard.card.CompareTag("Leaf")){
                    CardMgr3D.inst.rock.SetActive(false);
                    ControlMgr3D.inst.levelComplete = true;
                    inventoryMgr3D.tutorialComplete = true;
                }
            }else if(inventoryMgr3D.currLevel == 1 || inventoryMgr3D.currLevel == 2){
                // for levels 1 + 2, hide corresponding item in opposite path
                cardMgr3D.hideOtherItem();
            }
        }else{
            Debug.Log("Inventory Full");
            cardView.SetActive(false);
            ControlMgr2D.inst.cardUsed = true;
        }
        itemInInventory = false;
    }

    // set companion sprite in tutorial level
    public void setCompanionSprite(){
        companionMgr.setCompanion(currSprite);
        cardView.SetActive(false);
        ControlMgr2D.inst.cardUsed = true;
        companionCard = false;
    }

    // function to process completing normal events
    public bool completeEventCard(int index){

        bool complete = false;

        // complete event returns false if index is not within curr inventory range
        if(index > inventoryMgr3D.currInvTags.Count){
            Debug.Log("index outside of range of inventory");
            return complete;
        }
        
        if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Venom")){
            venomEffect = true;
            useEffectCard(index);
            return complete;
        }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Fungus")){
            fungusEffect = true;
            inventoryMgr3D.fungus = false;
            useEffectCard(index);
            return complete;
        }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "ImprovedTechnique")){
            improvedTechniqueEffect = true;
            useEffectCard(index);
            return complete;
        }

        // specific event conditions for each normal event
        if(cardMgr3D.currCard.CompareTag("Campfire")){
            if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Stick")){
                ControlMgr2D.inst.snack = true;
                complete = true;
            }
        }else if(cardMgr3D.currCard.CompareTag("Squirrel")){
            if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Cookie")){
                ControlMgr2D.inst.technique = true;
                complete = true;
            }else if(inventoryMgr3D.currInvWeapon[index-1]){
                complete = true;
            }
        }else if(cardMgr3D.currCard.CompareTag("Snake")){
            if(inventoryMgr3D.currInvWeapon[index-1]){
                complete = true;
            }else{
                ControlMgr2D.inst.venom = true;
                complete = true;
            }
        }else if(cardMgr3D.currCard.CompareTag("Treehouse")){
            if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Rope")){
                ControlMgr2D.inst.axe = true;
                complete = true;
            }else{
                ControlMgr2D.inst.matches = true;
                complete = true;
            }
        }else if(cardMgr3D.currCard.CompareTag("Lake")){
            ControlMgr2D.inst.fungus = true;
            complete = true;
        }else if(cardMgr3D.currCard.CompareTag("Swordstone")){
            ControlMgr2D.inst.sword = true;
            complete = true;
        }else if(cardMgr3D.currCard.CompareTag("Cabin")){
            if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Candle")){
                ControlMgr2D.inst.spear = true;
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Matches")){
                ControlMgr2D.inst.spear = true;
                complete = true;
            }
        }else if(cardMgr3D.currCard.CompareTag("Cabin2")){
            if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Candle")){
                ControlMgr2D.inst.spear = true;
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Matches")){
                ControlMgr2D.inst.spear = true;
                complete = true;
            }
        }else if(cardMgr3D.currCard.CompareTag("Cliff")){
            if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Rope")){
                ControlMgr2D.inst.axe = true;
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Leaf")){
                ControlMgr2D.inst.axe = true;
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Feather")){
                ControlMgr2D.inst.axe = true;
                complete = true;
            }else{
                complete = true;
            }
        }else if(cardMgr3D.currCard.CompareTag("Well")){
            if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Rope")){
                ControlMgr2D.inst.axe = true;
                complete = true;
            }else{
                complete = true;
            }
        }else if(cardMgr3D.currCard.CompareTag("Lump")){
            if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Axe") || String.Equals(inventoryMgr3D.currInvTags[index-1], "Shield") || String.Equals(inventoryMgr3D.currInvTags[index-1], "Dagger")){
                ControlMgr2D.inst.sword = true;
                complete = true;
            }else{
                complete = true;
            }
        }else if(cardMgr3D.currCard.CompareTag("PerfectStick")){
            if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Stone") || String.Equals(inventoryMgr3D.currInvTags[index-1], "Arrowhead") || String.Equals(inventoryMgr3D.currInvTags[index-1], "Dagger")){
                ControlMgr2D.inst.spear = true;
                complete = true;
            }else{
                complete = true;
            }
        }if(cardMgr3D.currCard.CompareTag("Attack")){
            int attackIncrease = improvedTechniqueEffect ? 1 : 0;
            if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Rock")){
                inventoryMgr3D.AttackKraken(1 + attackIncrease);
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Sword")){
                inventoryMgr3D.AttackKraken(5 + attackIncrease);
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Axe")){
                inventoryMgr3D.AttackKraken(4 + attackIncrease);
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Spear")){
                inventoryMgr3D.AttackKraken(4 + attackIncrease);
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Needle")){
                inventoryMgr3D.AttackKraken(2 + attackIncrease);
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Arrowhead")){
                inventoryMgr3D.AttackKraken(3 + attackIncrease);
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Dagger")){
                inventoryMgr3D.AttackKraken(3 + attackIncrease);
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Matches")){
                inventoryMgr3D.AttackKraken(2 + attackIncrease);
                complete = true;
            }
        }else if(cardMgr3D.currCard.CompareTag("Slam")){
            if(inventoryMgr3D.currInvWeapon[index-1])
                complete = true;
            else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Shield"))
                complete = true;
        }else if(cardMgr3D.currCard.CompareTag("Fling")){
            if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Feather")){
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Candle")){
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Match")){
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Leaf")){
                complete = true;
            }
        }else if(cardMgr3D.currCard.CompareTag("Grab")){
            complete = true;
        }else if(cardMgr3D.currCard.CompareTag("Trip")){
            if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Dagger")){
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Sword")){
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Arrowhead")){
                complete = true;
            }else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Axe")){
                complete = true;
            }
        }else if(cardMgr3D.currCard.CompareTag("Run")){
            if(inventoryMgr3D.currInvWeapon[index-1])
                complete = true;
            else if(String.Equals(inventoryMgr3D.currInvTags[index-1], "Rope"))
                complete = true;
        }

        // if event was completed, remove cardView
        cardView.SetActive(!complete);

        // if a weapon was used after improved technique, deactivate effect
        if( improvedTechniqueEffect && inventoryMgr3D.currInvWeapon[index-1]){
            improvedTechniqueEffect = false;
        }

        // remove selected item from inventory if venom effect was not just used
        if(!venomEffect){
            inventoryMgr3D.currInvSprites.RemoveAt(index-1);
            inventoryMgr3D.currInvTags.RemoveAt(index-1);
            inventoryMgr3D.currInvWeapon.RemoveAt(index-1);
            currPanel[index-1].GetComponent<UnityEngine.UI.Image>().sprite = BLANK;
        }else{
            venomEffect = false;
        }

        // if fungus effect is active, fail current event (regardless of prev stuff)
        if( fungusEffect ){
            fungusEffect = false;
            ControlMgr2D.inst.eventFailed = true;
            Debug.Log("Fungus effect caused event fail");
        }else{
            ControlMgr2D.inst.eventFailed = !complete;
        }

        // for levels 1 + 2, if event completed remove corresponding event in other path
        if(complete && (inventoryMgr3D.currLevel == 1 || inventoryMgr3D.currLevel == 2))
            CardMgr3D.inst.hideOtherEvent();

        return complete;
    }

    // function to update inventory when effect card at given index is used (called in completeEventCard)
    public void useEffectCard(int index){
        inventoryMgr3D.currInvSprites.RemoveAt(index-1);
        inventoryMgr3D.currInvTags.RemoveAt(index-1);
        inventoryMgr3D.currInvWeapon.RemoveAt(index-1);

        //load sprites of all cards in curr inventory
        int i = 0;
        foreach (Sprite s in inventoryMgr3D.currInvSprites)
        {
            currPanel[i].GetComponent<UnityEngine.UI.Image>().sprite = s;
            i++;
        }

        while(i < inventoryMgr3D.maxCards){
            currPanel[i].GetComponent<UnityEngine.UI.Image>().sprite = BLANK;
            i++;
        }

        if(inventoryMgr3D.currInvTags.Count == 0){
            ControlMgr2D.inst.eventFailed = true;
        }
    }

    // completion of effect cards
    public bool completeEffectCard()
    {
        // currently only tastySnack has implementation, increases inventory size
        if(cardMgr3D.currCard.CompareTag("TastySnack")){
            inventoryMgr3D.maxCards += 1;
            cardView.SetActive(false);
            setInventory();

            if(inventoryMgr3D.currLevel == 1){
                ControlMgr3D.inst.levelComplete = true;
                inventoryMgr3D.levelOneComplete = true;
                cardMgr3D.clearSticks();
            }else if(inventoryMgr3D.currLevel == 2){
                ControlMgr3D.inst.levelComplete = true;
                inventoryMgr3D.levelTwoComplete = true;
                cardMgr3D.clearSticks();
            }
            return true;
        }
        return false;
    }
}
