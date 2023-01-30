using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Image sonucImage;

    [SerializeField]
    private Text dogruText, yanlisText, puanText, puan1, puan2, puan3;


    [SerializeField]
    private GameObject tekrarOynaBtn, anaMenuBtn;

    float sureTimer;
    bool resimAcilsinmi;


    GameManager gameManager;


    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    private void OnEnable()
    {
        sureTimer = 0;
        resimAcilsinmi = true;
        
       // PlayerPrefs.DeleteAll(); // Kayýtlý tüm anahtar ve verileri siler

        dogruText.text = "";
        yanlisText.text = "";
        puanText.text = "";

        puan1.text = PlayerPrefs.GetInt("Sonuc1").ToString();
        puan2.text = PlayerPrefs.GetInt("Sonuc2").ToString();
        puan3.text = PlayerPrefs.GetInt("Sonuc3").ToString();
    

        tekrarOynaBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        anaMenuBtn.GetComponent<RectTransform>().localScale = Vector3.zero;

        StartCoroutine(ResimAcRoutine());
    }

    void Sonuc(int son)
    {
        if (son > PlayerPrefs.GetInt("Sonuc1"))
        {
      
            PlayerPrefs.SetInt("Sonuc3", PlayerPrefs.GetInt("Sonuc2"));
            PlayerPrefs.SetInt("Sonuc2", PlayerPrefs.GetInt("Sonuc1"));
            PlayerPrefs.SetInt("Sonuc1", son);
        }

        puan1.text = PlayerPrefs.GetInt("Sonuc1").ToString();
        puan2.text = PlayerPrefs.GetInt("Sonuc2").ToString();
        puan3.text = PlayerPrefs.GetInt("Sonuc3").ToString();
      
    }

    IEnumerator ResimAcRoutine()
    {
        int sonucPuan = 0;
        while (resimAcilsinmi)
        {
            sureTimer += .15f;
            sonucImage.fillAmount = sureTimer;

            yield return new WaitForSeconds(0.1f);

            if (sureTimer >= 1)
            {
                sureTimer = 1;
                resimAcilsinmi = false;

                dogruText.text = gameManager.dogruAdet.ToString() + " DOÐRU";
                yanlisText.text = gameManager.yanlisAdet.ToString() + " YANLIÞ";
                puanText.text = gameManager.toplamPuan.ToString() + " PUAN";

                sonucPuan = int.Parse(gameManager.toplamPuan.ToString());

                tekrarOynaBtn.GetComponent<RectTransform>().DOScale(1, .3f);
                anaMenuBtn.GetComponent<RectTransform>().DOScale(1, .3f);
            }
        }
        Sonuc(sonucPuan);
    }

    public void TekrarOyna()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }


}
