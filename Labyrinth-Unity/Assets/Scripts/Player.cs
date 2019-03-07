using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int[] Id = new int[0];
    public string[] Message = new string[0];

    public void SaveNote(int id, string msg)
    {
        Id[id - 1] = id;
        Message[id - 1] = msg;
        PlayerPrefs.SetInt("IdNote" + id, id);
        PlayerPrefs.SetString("MsgNote" + id, msg);
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
        }
    }

    public void LoadAllNotes()
    {
        for (int i = 0; i < Id.Length; i++)
        {
            Id[i] = PlayerPrefs.GetInt("IdNote" + (i + 1));
            Message[i] = PlayerPrefs.GetString("MsgNote" + (i + 1));
        }
    }
}