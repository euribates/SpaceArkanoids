﻿using UnityEngine;
using System.Collections;

namespace Game {

public class Game : MonoBehaviour {

    static int lives = 3;
    static int score = 0;

    public static void add_score(int points) { score += points; }
    
    public static void remove_live() { 
        if (lives > 0) { 
            lives--; 
        } else {
             Application.Quit();
             lives--;
        }
    }

    void Start () {
        Debug.Log("Game starts");
        InvokeRepeating("launch_missile", 1, 1);    
        }
        
    void launch_missile() {
        Invader[] gos = GameObject.FindObjectsOfType<Invader>();
        int n = Random.Range(0, gos.Length-1);
        Invader invader = gos[n];
        Object new_missile = Instantiate(invader.weapon, invader.transform.position, Quaternion.identity);
        Destroy(new_missile, 6);
        }

    void OnGUI() {
        GUI.Box (
                new Rect (10,10,100,30), 
                "Lives: " + lives
                );
        GUI.Box (
                new Rect (10,30,100,30), 
                "Score: " + score
                );


        }

    }
}