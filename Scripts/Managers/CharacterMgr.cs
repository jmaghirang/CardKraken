using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMgr : MonoBehaviour
{
    public static CharacterMgr inst;
    private void Awake(){
        inst = this;
    }

    public List<GameObject> currDialogueSet;
    public List<GameObject> grannyDialogue;
    public List<GameObject> foolDialogue;
    public List<GameObject> lover1Dialogue;
    public List<GameObject> lover2Dialogue;

    private InventoryMgr2D inventoryMgr2D;
    private InventoryMgr3D inventoryMgr3D;
    public int currDialogueIndex = 0;
    public bool dialogueDone = true, grannyCookie = false;
    public Sprite COOKIE;

    void Start()
    {
        inventoryMgr2D = InventoryMgr2D.inst;
        inventoryMgr3D = InventoryMgr3D.inst;

        if(inventoryMgr2D.granny)
            currDialogueSet = grannyDialogue;
        else if(inventoryMgr2D.fool)
            currDialogueSet = foolDialogue;
        else if(inventoryMgr2D.lover1)
            currDialogueSet = lover1Dialogue;
        else if(inventoryMgr2D.lover2)
            currDialogueSet = lover2Dialogue;

        if(inventoryMgr2D.characterCard && currDialogueSet.Count > 0)
            currDialogueSet[currDialogueIndex].SetActive(true);
    }

    void Update()
    {
        if(currDialogueIndex == currDialogueSet.Count - 1)
            dialogueDone = true;
        else
            dialogueDone = false;

        if(inventoryMgr2D.characterCard){
            if(!dialogueDone && Input.GetKeyDown(KeyCode.F)){
                currDialogueSet[currDialogueIndex++].SetActive(false);
                currDialogueSet[currDialogueIndex].SetActive(true);

                if(inventoryMgr2D.granny && currDialogueIndex == 2){
                    grannyCookie = true;
                    if(inventoryMgr3D.currInvTags.Count < inventoryMgr3D.maxCards){
                        inventoryMgr3D.currInvTags.Add("Cookie");
                        inventoryMgr3D.currInvSprites.Add(COOKIE);
                        inventoryMgr3D.currInvWeapon.Add(false);
                        inventoryMgr2D.currPanel[(inventoryMgr3D.currInvTags.Count - 1)].GetComponent<UnityEngine.UI.Image>().sprite = COOKIE;
                        inventoryMgr2D.inventoryObject.SetActive(true);
                    }
                }
            }
        }
    }

    public void removeDialogue(){
        foreach(GameObject dialogue in currDialogueSet)
            dialogue.SetActive(false);

        inventoryMgr2D.characterCard = false;
        inventoryMgr2D.granny = false;
        inventoryMgr2D.fool = false;
        inventoryMgr2D.lover1 = false;
        inventoryMgr2D.lover2 = false;
        inventoryMgr2D.inventoryObject.SetActive(true);
    }
}
