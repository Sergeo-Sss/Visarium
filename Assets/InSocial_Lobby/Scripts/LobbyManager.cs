using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    [Header("Groups W-C")]
    public GameObject[] Group;


    [Header("Sounds")]
    public AudioSource player;
    public AudioClip fonsound;
    public AudioClip click;

    [Header("Network room")]
    public ScrollRect scrollRect;
    public GameObject scrollContent;
    public GameObject connectPrefab;

    [Header("Room options")]
    public TMP_InputField roomname;
    public Toggle Visible;
    public Toggle Public;
    public TMP_InputField maxplayers;

    [Header("Login component")]
    public GameObject login;
    public GameObject registr;

    public void GoGroup(int ID)
    {
        player.PlayOneShot(click);
        for (int i = 0; i < Group.Length; i++)
        {
            if (i == ID)
            {
                Group[i].SetActive(true);
                continue;
            }
            Group[i].SetActive(false);
        }
    }

    private void Start()
    {
        //for (int i=0;i<20;i++)
        //{
        //    SetGroup("room "+i.ToString());
        //}
        scrollRect.verticalNormalizedPosition = 1;

    }

    public void SetGroup(string roomname)
    {
        GameObject scrolltemobj = Instantiate(connectPrefab);
        scrolltemobj.transform.Find("room name").GetComponent<TMP_Text>().text = roomname;
        scrolltemobj.transform.SetParent(scrollContent.transform, false);
    }

    public void CreateRoom()
    {
        player.PlayOneShot(click);
        //проверку на условие имени
        SetGroup(roomname.text);
    }
    
    public void ChangeLoginGroup()
    {
        if (login.activeSelf)
        {
            login.SetActive(false);
            registr.SetActive(true);
        }
        else
        {
            login.SetActive(true);
            registr.SetActive(false);
        }
    }
}