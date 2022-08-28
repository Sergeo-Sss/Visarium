using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class KeyBoard : MonoBehaviour
{
    [Header("Click sound")]
    public AudioClip click;
    public AudioSource player;

    [Header("Layout")]
    public GameObject en;
    public GameObject ru;
    public GameObject num;

    private TMP_InputField input;
    private bool isCaps = true;
    private bool enRu = false;  //false - ru; true - en

    public void GetAxis()
    {
        player.PlayOneShot(click);
        string name = EventSystem.current.currentSelectedGameObject.name;

        if (name == "Caps")
        {
            if (en.activeSelf)
            {
                if (!isCaps)
                {
                    foreach (Transform child in en.transform)
                    {
                        if (child.transform.tag == "Key" && child.transform.childCount != 0)
                        {
                            child.transform.GetChild(0).transform.GetComponent<TMP_Text>().fontStyle = FontStyles.UpperCase;
                        }
                    }
                    isCaps = true;
                }
                else
                {
                    foreach (Transform child in en.transform)
                    {
                        if (child.transform.tag == "Key" && child.transform.childCount != 0)
                        {
                            child.transform.GetChild(0).transform.GetComponent<TMP_Text>().fontStyle = FontStyles.LowerCase;
                        }
                    }
                    isCaps = false;
                }
            }
            else
            {

            }
        }
        else if (name == "Del")
        {
            if(input.text.Length!=0)
                input.text = input.text.Remove(input.text.Length - 1);
        }
        else if (name == "Num")
        {
            num.SetActive(true);

            if (en.activeSelf)
            {
                enRu = true;
            }
            else
            {
                enRu = false;
            }

            en.SetActive(false);
            ru.SetActive(false);
        }
        else if (name == "Rus")
        {
            ru.SetActive(true);
            en.SetActive(false);
        }
        else if (name == "Eng")
        {
            ru.SetActive(false);
            en.SetActive(true);
        }
        else if (name == "abc")
        {
            num.SetActive(false);
            if (enRu)
            {
                en.SetActive(true);
            }
            else
            {
                ru.SetActive(true);
            }
        }
        else if (name == "Comma")
        {
            input.text += ",";
        }
        else if (name == "Space")
        {
            input.text += " ";
        }
        else if (name == "Point")
        {
            input.text += ".";
        }
        else if (name == "Enter")
        {
            input.DeactivateInputField();
            gameObject.SetActive(false);
        }
        else
        {
            //костыль
            if (isCaps)
            {
                input.text += name.ToUpper();
            }
            else
            {
                input.text += name.ToLower();
            } 
        }
    }

    public void KeyboardActive()
    {
        input = EventSystem.current.currentSelectedGameObject.GetComponent<TMP_InputField>();
        gameObject.SetActive(true);
    }
}
