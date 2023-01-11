using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChoiceScript : MonoBehaviour
{
    //DEFINING BUTTONS AND TEXT ELEMENTS

    //4 main category buttons at the start of the game, Dream, Dare, Do and Share
    public Button DreamButton;
    public Button DareButton;
    public Button DoButton;
    public Button ShareButton;

    //Choice buttons and their corresponding text elements in 'DROMEN' category. There's 3 of them in total because most choices have 2 options, some have a third
    public Button DreamA;
    public Text DreamAtext;
    public Button DreamB;
    public Text DreamBtext;
    public Button DreamC;
    public Text DreamCtext;

    public Button DreamResult;
    public Text DreamResultText;

    //Choice buttons and their corresponding text elements in 'DURVEN' category. Same story as with 'DROMEN' but with different names
    public Button DareA;
    public Text DareAtext;
    public Button DareB;
    public Text DareBtext;
    public Button DareC;
    public Text DareCtext;

    public Button DareResult;
    public Text DareResultText;

    public string choiceChain; //This string will identify the path players take by using singular letters. Further explained at function ChooseLeft()
    public string kernKracht;

    void Start()
    {
        //At the start, the game is displaying only the 4 starting ones, all other buttons are invisible at that time
        //Also adding a listener to the buttons to help give them an action to perform once pressed (onClick event)

        DreamButton.gameObject.SetActive(true); 
        DreamButton.onClick.AddListener(ChooseDream);
        DareButton.gameObject.SetActive(true);
        DareButton.onClick.AddListener(ChooseDare);
        DoButton.gameObject.SetActive(true);
        ShareButton.gameObject.SetActive(true);

        //assigning different onClick events to the three options (third one is only present sometimes)
        DreamA.onClick.AddListener(ChooseLeftDream);
        DreamB.onClick.AddListener(ChooseRightDream);
        DreamC.onClick.AddListener(ChooseMiddleDream);

        DareA.onClick.AddListener(ChooseLeftDare);
        DareB.onClick.AddListener(ChooseRightDare);
        DareC.onClick.AddListener(ChooseMiddleDare);

        //At first these options aren't visible yet. Players need to choose a category first, THEN they can make individual choices in the corresponding category
        DreamA.gameObject.SetActive(false);
        DreamB.gameObject.SetActive(false);
        DreamC.gameObject.SetActive(false);
        DareA.gameObject.SetActive(false);
        DareB.gameObject.SetActive(false);
        DareC.gameObject.SetActive(false);

        //The results should obviously not exist yet either, but it will need a listener so that it can help continue the game to the second round / end
        DreamResult.gameObject.SetActive(false);
        DareResult.gameObject.SetActive(false);
        DreamResult.onClick.AddListener(EndRoundDream); //Hardcoded into only being able to do 'DROMEN' first, 'DURVEN' second. **A way to measure which round was picked is still needed!**
    }

    public void ChooseDream()
    {
        //Category buttons are turned off, and the two first choice options become available, later sometimes a third, but all first choices have 2 options
        DreamButton.gameObject.SetActive(false);
        DareButton.gameObject.SetActive(false);
        DoButton.gameObject.SetActive(false);
        ShareButton.gameObject.SetActive(false);

        DreamA.gameObject.SetActive(true);
        DreamB.gameObject.SetActive(true);

        //Call upon a switch case to check and send back data at the start. In this case, players need to see the start of the choice tree
        RenderChoicesDream();
    }

    //This function constantly checks the letter codes in choice tree, to see which choice should be displayed during game play ( See ChoiceLeft() )
    void RenderChoicesDream()
    {
        switch (choiceChain)
        {
            case "":
                Debug.Log("Chose DROMEN");
                DreamAtext.text = "NIEUWSGIERIG";
                DreamBtext.text = "SPEELS";
                break;

            case "b":
                Debug.Log("Chose SPEELS");
                DreamAtext.text = "LOS EN VRIJ";
                DreamBtext.text = "UITDAGEND";
                break;
            case "ba":
                Debug.Log("Chose LOS EN VRIJ");
                DreamAtext.text = "WETEN WAT JE WIL";
                DreamBtext.text = "LEKKER CHAOTISCH";
                break;
            case "baa":
                Debug.Log("Chose WETEN WAT JE WIL");
                DreamC.gameObject.SetActive(true);
                DreamAtext.text = "JE EIGEN WEG LOPEN";
                DreamBtext.text = "SNELHEID & VERANDERING";
                DreamCtext.text = "LAT HOOG LEGGEN";
                break;

            //case for resulting core strength (Player's result) in this case it's "EXCEPTIONEEL"
            case "baac":
                Debug.Log("Chose LAT HOOG LEGGEN");
                DreamA.gameObject.SetActive(false);
                DreamB.gameObject.SetActive(false);
                DreamC.gameObject.SetActive(false);
                DreamResult.gameObject.SetActive(true);
                kernKracht = "EXCEPTIONEEL";
                DreamResultText.text = kernKracht;
                break;

            //Should a value be absent from the game
            default:
                Debug.Log("Impossible index value");
                break;

        }
    }

    //With Round 1 ended, all visible buttons should return. Only 'DROMEN' is shut off because it was already picked in round 1
    void EndRoundDream()
    {
        DareButton.gameObject.SetActive(true);
        DoButton.gameObject.SetActive(true);
        ShareButton.gameObject.SetActive(true);
        DreamResult.gameObject.SetActive(false);
        choiceChain = "";
    }

    public void ChooseDare()
    {
        DreamButton.gameObject.SetActive(false);
        DareButton.gameObject.SetActive(false);
        DoButton.gameObject.SetActive(false);
        ShareButton.gameObject.SetActive(false);

        DareA.gameObject.SetActive(true);
        DareB.gameObject.SetActive(true);

        RenderChoicesDare();
    }
    void RenderChoicesDare()
    {
        switch (choiceChain)
        {
            case "":
                DareC.gameObject.SetActive(false);
                Debug.Log("Chose DURVEN");
                DareAtext.text = "NIEUWE DINGEN STARTEN";
                DareBtext.text = "VOLHOUDEN, NIET OPGEVEN";
                break;

            case "a":
                Debug.Log("Chose NIEUWE DINGEN STARTEN");
                DareAtext.text = "METEEN ZEGGEN EN DOEN";
                DareBtext.text = "RICHTING BEPALEN";
                break;
            case "ab":
                Debug.Log("Chose RICHTING BEPALEN");
                DareAtext.text = "AAN HET STUUR ZITTEN";
                DareBtext.text = "VOORUITGAAN!";
                break;
            case "abb":
                Debug.Log("Chose VOORUITGAAN!");
                DareC.gameObject.SetActive(true);
                DareAtext.text = "SNEL IN ACTIE KOMEN";
                DareBtext.text = "DOELEN HALEN";
                DareCtext.text = "VERDER GAAN EN GROEIEN";
                break;

            case "abbc":
                Debug.Log("Chose LAT HOOG LEGGEN");
                DareA.gameObject.SetActive(false);
                DareB.gameObject.SetActive(false);
                DareC.gameObject.SetActive(false);
                DareResult.gameObject.SetActive(true);
                kernKracht = "GRENSVERLEGGEND";
                DareResultText.text = kernKracht;
                break;

            //Should a value be absent from the game
            default:
                Debug.Log("Impossible index value");
                break;

        }
    }
    /*
     The player's choices add letters on the choice chain, each determining the result
    a = choosing left
    b = choosing right
    c = choosing the middle
    */
    void ChooseLeftDream()
    {
        choiceChain = choiceChain.ToString() + "a";
        Debug.Log("Adding 'a' to string!");
        Debug.Log(choiceChain);
        RenderChoicesDream();
    }

    void ChooseMiddleDream()
    {
        choiceChain = choiceChain + "c";
        Debug.Log("Adding 'c' to string!");
        Debug.Log(choiceChain);
        RenderChoicesDream();
    }
    void ChooseRightDream()
    {
        choiceChain = choiceChain + "b";
        Debug.Log("Adding 'b' to string!");
        Debug.Log(choiceChain);
        RenderChoicesDream();
    }
    void ChooseLeftDare()
    {
        choiceChain = choiceChain.ToString() + "a";
        Debug.Log("Adding 'a' to string!");
        Debug.Log(choiceChain);
        RenderChoicesDare();
    }

    void ChooseMiddleDare()
    {
        choiceChain = choiceChain + "c";
        Debug.Log("Adding 'c' to string!");
        Debug.Log(choiceChain);
        RenderChoicesDare();
    }
    void ChooseRightDare()
    {
        choiceChain = choiceChain + "b";
        Debug.Log("Adding 'b' to string!");
        Debug.Log(choiceChain);
        RenderChoicesDare();
    }
}