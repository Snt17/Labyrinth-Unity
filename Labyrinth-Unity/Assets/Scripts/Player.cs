using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int[] Id = new int[0];
    public string[] Message = new string[0];
    string IdText = "";
    public GameObject[] Obj;

    public void Start()
    {
        if (PlayerPrefs.HasKey("IdNote"))
        {
            IdText = PlayerPrefs.GetString("IdNote");
        }
    }

    public void SaveNote(int id, string msg)
    {
        IdText = IdText + Convert.ToString(id - 1) + ",";
        PlayerPrefs.SetString("IdNote", IdText);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            for (int i = 0; i < Id.Length; i++)
            {
                Debug.Log(Id[i] + " - " + Message[i]);
            }
        }
        if (Input.GetKeyDown(KeyCode.F9))
        {
            LoadAllNotes();
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
            IdText = "";
        }
    }

    public void LoadAllNotes()
    {
        string IdString = PlayerPrefs.GetString("IdNote");
        string[] idString = IdString.Split(',');

        for (int i = 0; i < idString.Length - 1; i++)
        {
            Id[i] = Convert.ToInt32(idString[i]) + 1;
            Message[i] = Obj[Id[i] - 1].GetComponent<FindingNotes>().Message;
        }
    }
}