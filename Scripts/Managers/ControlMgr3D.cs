using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMgr3D : MonoBehaviour
{
    public static ControlMgr3D inst;  
    private void Awake(){
        inst = this;
    }

    private CameraMgr cameraMgr;
    public CardMgr3D cardMgr3D;
    private InventoryMgr3D inventoryMgr3D;
    private SceneMgr sceneMgr;
    private AudioMgr audioMgr;
    public GameObject instructions;

    public bool pressF = false;
    public bool cardPresent = false;
    public bool inventoryOpen = false, manualOpen = false;

    public bool levelComplete = false;
    public int cardRange;

    void Start()
    {
        cameraMgr = CameraMgr.inst;
        cardMgr3D = CardMgr3D.inst;
        inventoryMgr3D = InventoryMgr3D.inst;
        audioMgr = AudioMgr.inst;
        sceneMgr = SceneMgr.inst;

<<<<<<< HEAD
            if(!inventoryMgr3D.levelTwoComplete){
                villagePaths[2].SetActive(false);
            }
<<<<<<< HEAD
        }else if(inventoryMgr3D.currLevel == 1 && inventoryMgr3D.levelOneComplete){
            levelComplete = true;
        }else if(inventoryMgr3D.currLevel == 2 && inventoryMgr3D.levelTwoComplete){
=======
        // setting for village level to allow use of portals
        if(inventoryMgr3D.currLevel == 4){
>>>>>>> parent of 358aa00 (Animating Boss Kraken (Idle and Damage))
            levelComplete = true;
=======
>>>>>>> parent of 22b17cb (all changes before class)
        }
    }

    void Update()
    {
        // loading gameboard scene when card is in front of player + they press 'f' key
        if(!inventoryOpen && pressF && Input.GetKeyDown(KeyCode.F)){
            cardMgr3D.currCard.SetActive(false);
            inventoryOpen = true;
            manualOpen = false;
            sceneMgr.OpenInventory();
            audioMgr.PlayCardflip();
        }

        // open inventory on keypress 'Q'
        if(!inventoryOpen && Input.GetKeyDown(KeyCode.Q)){
            inventoryOpen = true;
            manualOpen = true;
            sceneMgr.OpenInventory();
            audioMgr.PlayOpenInv();
        }

        if (inventoryOpen && Input.GetKeyDown(KeyCode.Q))
        {
            audioMgr.PlayCloseInv();
        }
    }

    void FixedUpdate()
    {
        // when inventory is closed:
        // check for obstacles (walls/cards) in front of player using raycast
        // check for loading zone collider using downward raycast
        if (!inventoryOpen){
            RaycastHit hit;

            //detection of card infront of objects
            if (Physics.Raycast (cameraMgr.cameraObj.transform.position, cameraMgr.cameraObj.transform.TransformDirection(Vector3.forward), out hit, cardRange)){
                // if a card object is encountered, setting obj to currCard and allow for inv to open (pressF bool)
                if(!hit.collider.gameObject.CompareTag("Wall")){
                    pressF = true;            
                    cardPresent = true;
                    cardMgr3D.currCard = hit.collider.gameObject;
                    cameraMgr.obstacle = true;
                    Debug.Log("Camera Obstacle: " + hit.collider.gameObject);
                }
            }else{
                pressF = false;
                cameraMgr.obstacle = false;
            }

            instructions.SetActive(pressF);

            // Detection of wall collider in front of camera
            if(Physics.Raycast(cameraMgr.cameraObj.transform.position, cameraMgr.cameraObj.transform.TransformDirection(Vector3.forward), out hit, 3))
            {
                if(hit.collider.gameObject.CompareTag("Wall")){
                    cameraMgr.obstacle = true;
                }
            }

            // downward raycast (on levelComplete) to detect if over loading zone
            if(levelComplete && Physics.Raycast(cameraMgr.cameraObj.transform.position, cameraMgr.cameraObj.transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            {
                Debug.Log("hit collider: " + hit.collider.gameObject);

                if(hit.collider.gameObject.CompareTag("LoadZoneVillage"))
                {
                    inventoryMgr3D.currLevel = 4;
                    sceneMgr.LoadScene();
                }else if(hit.collider.gameObject.CompareTag("LoadZoneLvl1"))
                {
                    inventoryMgr3D.currLevel = 1;
                    sceneMgr.LoadScene();
                }else if(inventoryMgr3D.levelOneComplete && hit.collider.gameObject.CompareTag("LoadZoneLvl2"))
                {
                    inventoryMgr3D.currLevel = 2;
                    sceneMgr.LoadScene();
                }
                else if(inventoryMgr3D.levelTwoComplete && hit.collider.gameObject.CompareTag("LoadZoneBoss"))
                {
                    inventoryMgr3D.currLevel = 3;
                    sceneMgr.LoadScene();
                }
            }
        }
    }
}
