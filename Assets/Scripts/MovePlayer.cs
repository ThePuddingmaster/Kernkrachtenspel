using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public GameObject player;

    //Main tiles at the start
    public GameObject StartTile;
    public GameObject DreamTile;
    public GameObject DareTile;
    public GameObject DoTile;
    public GameObject ShareTile;

    //These tiles below are only for choice paths fully fleshed out thus far

    //Used tiles for Dream category
    public GameObject DreamTile1A;
    public GameObject DreamTile1B;
    public GameObject DreamTile1C;

    public GameObject DreamTile2C;
    public GameObject DreamTile2D;

    public GameObject DreamTile3D;
    public GameObject DreamTile3E;

    public GameObject DreamTile4D;
    public GameObject DreamTile4E;

    //Used tiles for Dare category
    public GameObject DareTile1A;
    public GameObject DareTile1B;

    public GameObject DareTile2A;
    public GameObject DareTile2B;
    
    public GameObject DareTile3A;
    public GameObject DareTile3B;
    public GameObject DareTile3C;

    public GameObject DareTile4B;
    public GameObject DareTile4C;

    public Button Dromen; //Dutch for 'Dream'
    public Button Durven; //Dutch for 'Dare'


    //These 2/3 choice buttons are not visible at the start of the game, these are activated in the Button Choice Script
    public Button Dromen1;
    public Button Dromen2;
    public Button Dromen3;

    public Button Durven1;
    public Button Durven2;
    public Button Durven3;

    public Button FinalButtonDream;
    public Button FinalButtonDare;

    public string choiceChain;

    //Material colors to change the background with
    public Material Crimson;
    public Material Red;
    public Material SoftRed;
    public Material BrightRed;
    public Material Pink;
    public Material Ochre;
    public Material Yellow;
    public Material SoftYellow;
    public Material BrightYellow;
    public Material VBrightYellow;

    public GameObject CylinderWall; //The wall around the field

    public void Start()
    {
        //First, all hexagonal tiles not adjacent to the start will not be shown
        DreamTile1A.gameObject.SetActive(false);
        DreamTile1B.gameObject.SetActive(false);
        DreamTile1C.gameObject.SetActive(false);

        DreamTile2C.gameObject.SetActive(false);
        DreamTile2D.gameObject.SetActive(false);

        DreamTile3D.gameObject.SetActive(false);
        DreamTile3E.gameObject.SetActive(false);

        DreamTile4D.gameObject.SetActive(false);
        DreamTile4E.gameObject.SetActive(false);

        DareTile1A.gameObject.SetActive(false);
        DareTile1B.gameObject.SetActive(false);

        DareTile2A.gameObject.SetActive(false);
        DareTile2B.gameObject.SetActive(false);

        DareTile3A.gameObject.SetActive(false);
        DareTile3B.gameObject.SetActive(false);
        DareTile3C.gameObject.SetActive(false);

        DareTile4B.gameObject.SetActive(false);
        DareTile4C.gameObject.SetActive(false);

        //Adding listeners to buttons similarly to what happens in the Button Choice Script
        //these effects serve a different function than the UI changing effects, hence they're not located in the same script
        Dromen.onClick.AddListener(ToDream);
        Durven.onClick.AddListener(ToDare);

        Dromen1.onClick.AddListener(DreamLeft);
        Dromen2.onClick.AddListener(DreamRight);
        Dromen3.onClick.AddListener(DreamMiddle);

        Durven1.onClick.AddListener(DareLeft);
        Durven2.onClick.AddListener(DareRight);
        Durven3.onClick.AddListener(DareMiddle);

        FinalButtonDream.onClick.AddListener(FinishRound);
        FinalButtonDare.onClick.AddListener(FinishGame);

        BeginRound();
    }

    //change player position to new tile, remove the category tiles that weren't chosen
    public void ToDream()
    {
        DareTile.gameObject.SetActive(false);
        DoTile.gameObject.SetActive(false);
        ShareTile.gameObject.SetActive(false);

        DreamTile1A.gameObject.SetActive(true);
        DreamTile1B.gameObject.SetActive(true);

        player.transform.position = new Vector3(DreamTile.transform.position.x, DreamTile.transform.position.y, DreamTile.transform.position.z);
        CylinderWall.GetComponent<Renderer>().material = Ochre;
        RenderChoiceDream();
    }

    public void ToDare()
    {
        DoTile.gameObject.SetActive(false);
        ShareTile.gameObject.SetActive(false);

        DareTile1A.gameObject.SetActive(true);
        DareTile1B.gameObject.SetActive(true);

        player.transform.position = new Vector3(DareTile.transform.position.x, DareTile.transform.position.y, DareTile.transform.position.z);
        CylinderWall.GetComponent<Renderer>().material = Crimson;
        RenderChoiceDare();
    }

    void RenderChoiceDream()
    {
        //For simplicity I'm using a near identical version of the switch case that's found in the Button Choice Script. Check that one to see how the choice chain functions
        switch (choiceChain)
        {
            case "":
                break;

            case "b":
                //Remove the tile that wasn't chosen, the one that was chosen will stay visible until the game ends
                DreamTile1A.gameObject.SetActive(false);

                DreamTile1C.gameObject.SetActive(true);
                DreamTile2C.gameObject.SetActive(true);

                //Move to position of chosen tile
                player.transform.position = new Vector3(DreamTile1B.transform.position.x, DreamTile1B.transform.position.y, DreamTile1B.transform.position.z);

                //Apply background color change
                CylinderWall.GetComponent<Renderer>().material = Yellow;
                break;

            case "ba":
                DreamTile1C.gameObject.SetActive(false);

                DreamTile2D.gameObject.SetActive(true);
                DreamTile3D.gameObject.SetActive(true);

                player.transform.position = new Vector3(DreamTile2C.transform.position.x, DreamTile2C.transform.position.y, DreamTile2C.transform.position.z);

                CylinderWall.GetComponent<Renderer>().material = SoftYellow;
                break;

            case "baa":
                DreamTile2D.gameObject.SetActive(false);

                //This choice has a 3rd option, it needs three pickable paths
                DreamTile3E.gameObject.SetActive(true);
                DreamTile4D.gameObject.SetActive(true);
                DreamTile4E.gameObject.SetActive(true);

                player.transform.position = new Vector3(DreamTile3D.transform.position.x, DreamTile3D.transform.position.y, DreamTile3D.transform.position.z);

                CylinderWall.GetComponent<Renderer>().material = BrightYellow;
                break;

            //case for resulting core strength (Player's result) in this case it's "EXCEPTIONEEL"
            case "baac":
                DreamTile3E.gameObject.SetActive(false);
                DreamTile4D.gameObject.SetActive(false);

                player.transform.position = new Vector3(DreamTile4E.transform.position.x, DreamTile4E.transform.position.y, DreamTile4E.transform.position.z);

                CylinderWall.GetComponent<Renderer>().material = VBrightYellow;
                break;
            //Should a value be absent from the game
            default:
                Debug.Log("No can do!");
                break;
        }
    }

    //Similar switch case but for when the player chooses dare category
    void RenderChoiceDare()
    {
        switch (choiceChain)
        {
            case "":
                break;

            case "a":
                Debug.Log("Here I am!");
                DareTile1B.gameObject.SetActive(false);

                DareTile2A.gameObject.SetActive(true);
                DareTile2B.gameObject.SetActive(true);

                player.transform.position = new Vector3(DareTile1A.transform.position.x, DareTile1A.transform.position.y, DareTile1A.transform.position.z);

                CylinderWall.GetComponent<Renderer>().material = Red;
                break;

            case "ab":
                DareTile2A.gameObject.SetActive(false);

                DareTile3B.gameObject.SetActive(true);
                DareTile3C.gameObject.SetActive(true);

                player.transform.position = new Vector3(DareTile2B.transform.position.x, DareTile2B.transform.position.y, DareTile2B.transform.position.z);

                CylinderWall.GetComponent<Renderer>().material = SoftRed;
                break;

            case "abb":
                DareTile3C.gameObject.SetActive(false);

                DareTile3A.gameObject.SetActive(true);
                DareTile4B.gameObject.SetActive(true);
                DareTile4C.gameObject.SetActive(true);

                player.transform.position = new Vector3(DareTile3B.transform.position.x, DareTile3B.transform.position.y, DareTile3B.transform.position.z);

                CylinderWall.GetComponent<Renderer>().material = BrightRed;
                break;

            case "abbc":
                DareTile3A.gameObject.SetActive(false);
                DareTile4C.gameObject.SetActive(false);

                player.transform.position = new Vector3(DareTile4B.transform.position.x, DareTile4B.transform.position.y, DareTile4B.transform.position.z);

                CylinderWall.GetComponent<Renderer>().material = Pink;
                break;

            default:
                Debug.Log("No can do!");
                break;
        }
    }


    void DreamLeft()
    {
        choiceChain = choiceChain.ToString() + "a";
        RenderChoiceDream();
    }
    void DreamMiddle()
    {
        choiceChain = choiceChain + "c";
        RenderChoiceDream();
    }
    void DreamRight()
    {
        choiceChain = choiceChain + "b";
        RenderChoiceDream();
    }

    void DareLeft()
    {
        choiceChain = choiceChain.ToString() + "a";
        RenderChoiceDare();
    }

    void DareMiddle()
    {
        choiceChain = choiceChain + "c";
        RenderChoiceDare();
    }
    void DareRight()
    {
        choiceChain = choiceChain + "b";
        RenderChoiceDare();
    }

    void BeginRound()
    {
        choiceChain = "";
        DreamTile.gameObject.SetActive(true);
        DareTile.gameObject.SetActive(true);
        DoTile.gameObject.SetActive(true);
        ShareTile.gameObject.SetActive(true);

        player.transform.position = new Vector3(StartTile.transform.position.x, StartTile.transform.position.y, StartTile.transform.position.z);
    }

    void FinishRound()
    {
        BeginRound();
    }

    void FinishGame()
    {
        Debug.Log("The game's over!");
    }
}
