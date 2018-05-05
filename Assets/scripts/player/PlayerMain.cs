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
    bool spell00;
    bool spell01;
    bool spell02;
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
    public GameObject sp_slot00;
    public GameObject sp_slot01;

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

    private void Start()
    {
        //define components
        player = this.gameObject;
        projSpawn = GameObject.Find("projSpawn");
        apBar = projRate;
        statesTimer = statesTimerMax;

        HPBar = transform.parent.transform.Find("PlayerUI").transform.Find("HPBar").gameObject;
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

            
        
    }
    private void Update()
    {
        HPBar.GetComponent<Slider>().value = curHP;
        //get input states
        //keyboard
        moveRight = Input.GetKey(KeyCode.RightArrow);
        moveLeft = Input.GetKey(KeyCode.LeftArrow);

        shoot = Input.GetKey(KeyCode.Space);

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
                apBar -= (projRate / 32);
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
