using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonHaul.states;
using UnityEngine.UI;


public class PlayerMain : MonoBehaviour {
    //Gameplay states
    public bool movementEnabled;
    bool pauseActive;
    public bool attackingEnabled;

    public bool gameOver;

    //Input variables
    bool moveLeft;
    bool moveRight;
    bool shoot;
    bool spell0;
    bool spell1;
    bool spell2;
    bool pause;

    //Components
    GameObject player;
    GameObject projSpawn;

    //States
    public AttackStates activeState;
    float statesTimer;
    bool startState;
    public float statesTimerMax;

    //positive

    //Stats - overall
    public int maxHP;
    public int maxMP;
    //..
    public static int Exp;
    public byte atk;
    public byte def;
    public byte lvl;
    public static int gold;

    //spell slots
    public GameObject sp_basic;

    public Spells sp_slot0;
    public Spells sp_slot1;
    public Spells sp_slot2;

    //stats - current
    public int curHP;
    public int curMP;

    //mechanic stats
    public float movementSpeed;
    public float projRate;
    float apBar;
    //..States
    public bool attacked;

    //Spells unlocked
    bool unlockedSpell00;
    bool unlockedSpell01;

    //UI
    GameObject HPBar;
    GameObject MPBar;
    //..spell slots
    Image spSl0_thumb;
    Image spSl1_thumb;
    Image spSl2_thumb;

    private void Start()
    {
        //define components
        player = this.gameObject;
        projSpawn = GameObject.Find("projSpawn");
        apBar = projRate;
        statesTimer = statesTimerMax;

        HPBar = transform.parent.transform.Find("PlayerUI").transform.Find("HPBar").gameObject;
        MPBar = transform.parent.transform.Find("PlayerUI").transform.Find("MPBar").gameObject;
        spSl0_thumb = transform.parent.transform.Find("PlayerUI").transform.Find("A_Slot").transform.Find("Img_Spell").gameObject.GetComponent<Image>();
        spSl1_thumb = transform.parent.transform.Find("PlayerUI").transform.Find("S_Slot").transform.Find("Img_Spell").gameObject.GetComponent<Image>();
        spSl2_thumb = transform.parent.transform.Find("PlayerUI").transform.Find("D_Slot").transform.Find("Img_Spell").gameObject.GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        if (attackingEnabled)
        {
            if (shoot && !attacked)
            {
                Instantiate(sp_basic, projSpawn.transform.position, projSpawn.transform.rotation);
                attacked = true;
            }
            CoolDownStep();
        }

        //player movement
        if (movementEnabled)
        {
            if (moveLeft && transform.position.x > -4)
            {
                player.transform.position += new Vector3(-1f,0) * (movementSpeed);
            }
            if (moveRight && transform.position.x < 4)
            {
                player.transform.position += new Vector3(1f, 0) * (movementSpeed);
            }
        }
        if (activeState != AttackStates.none)
        {
            StateTimerStep();
        }
        //player states
        //..poison
        if (activeState == AttackStates.poison && startState)
        {
            States.PoisionDamage(gameObject, maxHP);
            startState = false;
            statesTimer = statesTimerMax;
        } if (curHP <= maxHP / 4)
        {
            activeState = AttackStates.none;
        }

        //update spell slots
        //..UI
        spSl0_thumb.sprite = sp_slot0.thumbnail;
        spSl1_thumb.sprite = sp_slot1.thumbnail;
        spSl2_thumb.sprite = sp_slot2.thumbnail;

        //Cast spells
        if (attackingEnabled)
        {

            if (spell0 && !attacked && sp_slot0.mPCost <= curMP) //1st (A) spell slot
            {
                curMP -= sp_slot0.mPCost;
                Instantiate(sp_slot0.atkPref, projSpawn.transform.position, projSpawn.transform.rotation);
                attacked = true;
            }
            if (spell1 && !attacked && sp_slot1.mPCost <= curMP) //2nd (S) spell slot
            {
                curMP -= sp_slot1.mPCost;
                Instantiate(sp_slot1.atkPref, projSpawn.transform.position, projSpawn.transform.rotation);
                attacked = true;
            }
            if (spell2 && !attacked && sp_slot2.mPCost <= curMP) //3rd (D) spell slot
            {
                curMP -= sp_slot2.mPCost;
                Instantiate(sp_slot2.atkPref, projSpawn.transform.position, projSpawn.transform.rotation);
                attacked = true;
            }
        }
        

    }
    private void Update()
    {
        HPBar.GetComponent<Slider>().value = (((float)curHP / (float)maxHP) * 100);
        MPBar.GetComponent<Slider>().value = (((float)curMP / (float)maxMP) * 100);
        //get input states
        //..keyboard
        moveRight = Input.GetKey(KeyCode.RightArrow);
        moveLeft = Input.GetKey(KeyCode.LeftArrow);

        shoot = Input.GetKey(KeyCode.Space);

        spell0 = Input.GetKey(KeyCode.A);
        spell1 = Input.GetKey(KeyCode.S);
        spell2 = Input.GetKey(KeyCode.D);

        //detect game over
        if (curHP <= 0)
            gameOver = true;
        else
            gameOver = false;

        //commands to be run on game over
        if (gameOver)
        {
            movementEnabled = false;
            attackingEnabled = false;
            Time.timeScale = 0;
        }
        //gamepad (to be added later)

    }
    private void CoolDownStep()
    {
        if (attacked)
        {
            if (apBar > 0)
            {
                apBar -= (8 / projRate);
            } else
            {
                apBar = projRate;
                attacked = false;
            }
        }
    }

    void StateTimerStep()
    {
        if (statesTimer <= 0)
        {
            startState = true;
        } else
        {
            statesTimer -= 0.1f;
        }
    }

}
