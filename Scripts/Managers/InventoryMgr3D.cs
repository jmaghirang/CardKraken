using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMgr3D : MonoBehaviour
{
    public static InventoryMgr3D inst;
    private void Awake(){
        inst = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public List<string> currInvTags;

    public int maxCards;

    public List<Sprite> currInvSprites;

    public List<bool> currInvWeapon;

    public Sprite currCompanion, BLANK;

    public int currLevel; //0 = tutorial, 1 = level 1, 2 = level 2, 3 = boss level, 4 = village
    public bool tutorialComplete = false, levelOneComplete = false, levelTwoComplete = false;

    public bool newToVillage = true;

    public int krakenHealth = 10;
    public bool krakenDefeated = false;

    public bool fungus = false;

    // function to wipe inventory (called on event failure)
    public void wipeInventory(){
        currInvSprites.Clear();
        currInvTags.Clear();
        currInvWeapon.Clear();
    }

    // handling successful weapon use against kraken
    public void AttackKraken(int damage){
        Debug.Log("Attack Kraken with damage: " + damage);
        krakenHealth -= damage;
        if(krakenHealth <= 0){
            krakenDefeated = true;
        }
    }

    public void useFungusEffect(){
        Debug.Log("used fungus card to survive failed event!");

        int index = 0;
        foreach(string s in currInvTags){
            if(s.Equals("Fungus"))
                break;
            else
                index++;
        }

        currInvTags.RemoveAt(index);
        currInvSprites.RemoveAt(index);
        currInvWeapon.RemoveAt(index);

        //load sprites of all cards in curr inventory
        int i = 0;
        foreach (Sprite s in currInvSprites)
        {
            InventoryMgr2D.inst.currPanel[i].GetComponent<UnityEngine.UI.Image>().sprite = s;
            i++;
        }

        while(i < maxCards){
            InventoryMgr2D.inst.currPanel[i].GetComponent<UnityEngine.UI.Image>().sprite = BLANK;
            i++;
        }

        fungus = false;
    }
}
