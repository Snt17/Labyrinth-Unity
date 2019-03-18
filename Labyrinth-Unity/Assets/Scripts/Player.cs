﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int[] Ids = new int[0];
    public string[] Messages = new string[0];
    private string IdToString = "";
    public GameObject[] Object;

    public void Start()
    {
        if (PlayerPrefs.HasKey("Notes"))
        {
            IdToString = PlayerPrefs.GetString("Notes");
        }
    }

    public void SaveNote(int id)
    {
        string[] idtostring = IdToString.Split(',');
        int count = 0;

        for (int i = 0; i < idtostring.Length - 1; i++)
        {
            if (Convert.ToInt32(idtostring[i]) == (id - 1))
            {
                count++;
            }
        }
        if (count == 0)
        {
            IdToString = IdToString + Convert.ToString(id - 1) + ",";
        }
        PlayerPrefs.SetString("Notes", IdToString);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            for (int i = 0; i < Ids.Length; i++)
            {
                Debug.Log(Ids[i] + " - " + Messages[i]);
            }
        }
 
        if (Input.GetKeyDown(KeyCode.F9))
        {
                LoadAllNotes();
        }
 
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
            IdToString = "";
        }
    }

    public void LoadAllNotes()
    {
        string[] idtostring = PlayerPrefs.GetString("Notes").Split(',');

        for (int i = 0; i < idtostring.Length - 1; i++)
        {
            Ids[i] = Convert.ToInt32(idtostring[i]) + 1;
            Messages[i] = Object[Ids[i] - 1].GetComponent<FindingNotes>().Message;
        }
    }
}