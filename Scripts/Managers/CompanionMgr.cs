using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//CompanionMgr is a class to control the visuals and AI of companion
public class CompanionMgr : MonoBehaviour
{
    public static CompanionMgr inst;
    private void Awake(){
        inst = this;
    }

    public GameObject companion;
    public GameObject area; // secondary image used to make drag n drop more accurate
    public List<GameObject> dialogue;

    public InventoryMgr3D inventoryMgr;

    void Start()
    {
        inventoryMgr = InventoryMgr3D.inst;

        if(inventoryMgr.currLevel != 0)
            setCompanion(inventoryMgr.currCompanion);

        if(inventoryMgr.currLevel == 4 && inventoryMgr.newToVillage){
            setDialogue(0);
        }
    }

    void Update()
    {
    }

    public void setCompanion(Sprite currSprite){
        companion.GetComponent<UnityEngine.UI.Image>().sprite = currSprite;
        inventoryMgr.currCompanion = currSprite;
    }

    public void setDialogue(int index){
        dialogue[index].SetActive(true);
    }

    public void removeDialogue(){
        foreach(GameObject option in dialogue)
            option.SetActive(false);
    }
}
