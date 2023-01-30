using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text SureText;


    int kalanSure;

    bool sureSaysinmi;

    [SerializeField]
    private GameObject sonucPaneli;

    [SerializeField]
    private GameObject sonuclarObje, zamanObje, dogruYanlisObje, playerObje, puanObje;

    void Start()
    {
        kalanSure = 30;
        sureSaysinmi = true;

        sonucPaneli.SetActive(false);

        sonuclarObje.SetActive(true);
        zamanObje.SetActive(true);
        dogruYanlisObje.SetActive(true);
        playerObje.SetActive(true);
        puanObje.SetActive(true);

        StartCoroutine(SureTimerRoutine());
    }

    IEnumerator SureTimerRoutine()
    {
        while (sureSaysinmi)
        {
            yield return new WaitForSeconds(1f);

            if (kalanSure < 10)
            {
                SureText.text = "0" + kalanSure.ToString();
            }
            else
            {
                SureText.text = kalanSure.ToString();
            }

            if (kalanSure <= 0)
            {
                sureSaysinmi = false;
                SureText.text = "";

                EkraniTemizle();
                sonucPaneli.SetActive(true);

            }
            kalanSure--;
        }
    }


    void EkraniTemizle()
    {


        sonuclarObje.SetActive(false);
        zamanObje.SetActive(false);
        dogruYanlisObje.SetActive(false);
        playerObje.SetActive(false);
        puanObje.SetActive(false);
    }


}
