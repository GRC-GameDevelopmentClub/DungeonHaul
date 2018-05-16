/*Copyright (c) Hunter Ahlquist
 *http://hunterahlquist.com/
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DungeonHaul.states;

public class UIManager : MonoBehaviour {
    //HP Bar
    GameObject HPBar;
    GameObject HPBar_fill;
    GameObject Player;
    GameObject MPBar;
    GameObject MPBar_fill;

    [Header("HP Bar")]
    [Tooltip("This is the color that the HP bar will change to when poisoned.")]
    public Color hpfill_poisoned;

    [Tooltip("This is the color that the HP bar will change to when normal.")]
    public Color hpfill_normal;

    [Tooltip("Select 'Is Player' if this script is attached to the player.")]
    public bool isPlayer;

    [Header("MP Bar")]
    [Tooltip("This is the color that the MP bar will change to when normal.")]
    public Color mpfill_normal;

    //Screen fader
    float curAlphaLevel;
    [Header("Screen Fader")]
    [Tooltip("If true, the screen will fade to the selected color")]
    public bool fadeScreen;
    [Tooltip("The screen will fade to this color when 'Fade Screen' is true.")]
    public Color fadeColor;
    
    Image Fader;
    bool fadedScreen;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        HPBar = transform.Find("HPBar").gameObject;
        HPBar_fill = HPBar.transform.Find("Fill Area").transform.Find("Fill").gameObject;
        
        if (isPlayer)
        {
            MPBar = transform.Find("MPBar").gameObject;
            MPBar_fill = MPBar.transform.Find("Fill Area").transform.Find("Fill").gameObject;
            Fader = transform.Find("Fader").gameObject.GetComponent<Image>();
            fadedScreen = true;
            fadeScreen = false;
            Fader.CrossFadeAlpha(0, 0.5f, true);
        }
    }



    private void Update()
    {
        if (isPlayer)
        {

            //check for poison state
            if (Player.GetComponent<PlayerMain>().activeState == AttackStates.poison)
            {
                HPBar_fill.GetComponent<Image>().color = hpfill_poisoned;
            }
            else
            {
                HPBar_fill.GetComponent<Image>().color = hpfill_normal;
            }

            //check if screen will fade
            Fader.color = fadeColor;
            if (!fadeScreen && fadedScreen)
            {
                Fader.CrossFadeAlpha(0,0.5f,true);
                fadedScreen = false;
            } else if (!fadedScreen && fadeScreen)
            {
                Fader.CrossFadeAlpha(1,0.5f,true);
                fadedScreen = true;
            }

        }
        if (!isPlayer)
        {
            if (transform.parent.GetComponent<EnemyMain>().activeState == AttackStates.poison)
            {
                HPBar_fill.GetComponent<Image>().color = hpfill_poisoned;
            }
            else
            {
                HPBar_fill.GetComponent<Image>().color = hpfill_normal;
            }
        }

    }

}
