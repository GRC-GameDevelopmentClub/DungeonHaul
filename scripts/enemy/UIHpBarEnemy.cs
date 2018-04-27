using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHpBarEnemy : MonoBehaviour {

    
    GameObject enemy;
    GameObject canvas;
    float curHP;
    float maxHP;
    Slider sliderHP;

    public bool showingHP;
    public float showHPTime;

    private void Start()
    {
        enemy = this.transform.parent.transform.parent.gameObject;
        canvas = this.transform.parent.gameObject;
        sliderHP = this.GetComponent<Slider>();
        canvas.GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //this.gameObject.SetActive(false);
        showHPTime = 100;
        //sliderHP.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Update is called once per frame
    void Update () {
        this.transform.position = enemy.transform.position + new Vector3(0, 0.5f, 0);
        curHP = enemy.GetComponent<EnemyMain>().curHP;
        maxHP = enemy.GetComponent<EnemyMain>().maxHP;
        sliderHP.value = ((curHP / maxHP) * 100);
    }

    private void FixedUpdate()
    {
        if (showingHP)
        {
            if (showHPTime <= 0)
            {
                showHPTime -= 0.1f;
            } else
            {
                showingHP = false;
                showHPTime = 100;
            }
        }
    }
    
    public void ShowEnemyHPBar()
    {
        this.gameObject.SetActive(true);
        showingHP = true;
    }
}
