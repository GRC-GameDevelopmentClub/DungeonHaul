using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonHaul.states;

public class PlayerMain : MonoBehaviour {
    //Gameplay states
    public bool movementEnabled;
    bool pauseActive;
    public bool attackingEnabled;

    //Input variables
    bool moveLeft;
    bool moveRight;
    bool shoot;
    bool spell00;
    bool spell01;
    bool pause;

    //Components
    GameObject player;
    GameObject playerView;
    GameObject projSpawn;

    //States
    public AttackStates activeState;
    
    //positive
    bool iFramed;

    //Stats - overall
    int maxHP;
    int maxMP;
    //..
    public int EXp;
    public byte atk;
    public byte def;
    public byte lvl;
    public  int gold;

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

    private void Start()
    {
        //define components
        player = this.gameObject;
        playerView = GameObject.Find("player_view");
        projSpawn = GameObject.Find("projSpawn");
        apBar = projRate;
    }

    private void FixedUpdate()
    {
        if (attackingEnabled)
        {
            if (shoot && !attacked)
            {
                GameObject proj = Instantiate(sp_basic, projSpawn.transform.position, projSpawn.transform.rotation);
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

        
    }
    private void Update()
    {
        //get input states
        //keyboard
        moveRight = Input.GetKey(KeyCode.RightArrow);
        moveLeft = Input.GetKey(KeyCode.LeftArrow);

        shoot = Input.GetKey(KeyCode.Space);


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

}
