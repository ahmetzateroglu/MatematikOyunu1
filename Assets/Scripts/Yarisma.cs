using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Yarisma : MonoBehaviour
{


    private Sesler Ses;
    public GameObject obje;

    // panel için 
    public GameObject panelim;
    public Text totalpuanpaneltext; 
    public Text dogrusayisipaneltext;
    public Text yanlissayisipaneltext;
    public Text puanpaneltext;
    public Text rekabetciskorpaneltext;

    public int dogrusayisi = 0;
    public int yanlissayisi = 0;

    //

    public Button buton1, buton2, buton3, buton4; 
    public Color yesilRenk, kirmiziRenk, beyazRenk; 

    public Text soruismi, cevapa, cevapb, cevapc, cevapd, skorsayisiyazi, süreyazi, puanyazi; 

    public int cevap, skorsayisi; 
    public int puan = 0;
    public int sayac = 0;

    public float süre;

    public string kategori; 
    public int zorluk;

    public int totalpuan; 
                         
    public int enyuksekpuan; 

    public int karisiktoplama; 
    public int karisikcikarma;
    public int karisikcarpma;
    public int karisikbolme;
    // 


    public int seslerackapa;
    public int timersesackapa;
    //
    public List<bool> sorulanlar;


    Sorular sr; 



    void Start()
    {


        karisiktoplama = PlayerPrefs.GetInt("karisiktoplama");
        karisikcikarma = PlayerPrefs.GetInt("karisikcikarma");
        karisikcarpma = PlayerPrefs.GetInt("karisikcarpma");
        karisikbolme = PlayerPrefs.GetInt("karisikbolme");

        seslerackapa = PlayerPrefs.GetInt("seslerackapa");
        timersesackapa = PlayerPrefs.GetInt("timersesackapa");

        totalpuan = PlayerPrefs.GetInt("totalpuan"); 
        enyuksekpuan = PlayerPrefs.GetInt("enyuksekpuan"); 

        puan = 0;
        sayac = 0;

        panelim.SetActive(false);

        sr = GetComponent<Sorular>();

        for (int i = 0; i < sr.sorular.Count; i++)
        {
            sorulanlar.Add(false);

        }
     
            SoruEkle();        
        

        Debug.Log(MainMenu.secilenkategori);

        Ses = obje.GetComponent<Sesler>();
    }


    void Update()
    {




        if (süre > 0 && süre != 99)                                                                           
        {
            süre -= Time.deltaTime;
            süreyazi.text = süre.ToString("00");
        }

        if (süre <= 0) 
        {
            Debug.Log("Süre Bitti Kaybettin");
            puan -= 1;
            puanyazi.text = puan.ToString();
            SoruEkle();

        }



    }




    public void SoruEkle()
    {

        if (timersesackapa == 1) 
        {
            Invoke("TimerSes", 6.0f);

        }



        Debug.Log(kategori);
        Debug.Log(zorluk);

        buton1.image.color = beyazRenk;
        buton2.image.color = beyazRenk;
        buton3.image.color = beyazRenk;
        buton4.image.color = beyazRenk;



        if (sayac < 5) 
        {

            int sorusayi = Random.Range(0, sorulanlar.Count);

            if (sorulanlar[sorusayi] == false)
            {

                sorulanlar[sorusayi] = true;


                kategori = sr.sorular[sorusayi].kategori;
                zorluk = sr.sorular[sorusayi].zorluk;


                if (MainMenu.secilenzorluk == zorluk)
                {

                    if (MainMenu.secilenkategori == "rekabetci")  
                    {


                        Debug.Log("rekabetcii");
                        
                        if ((kategori == "toplama") || (kategori == "cikarma") || (kategori == "carpma") || (kategori == "bolme"))
                        {

                            cevap = sr.sorular[sorusayi].cevap;

                            skorsayisi++;
                            skorsayisiyazi.text = "" + skorsayisi;
                            süre = 10; 
                            soruismi.text = sr.sorular[sorusayi].soruismi;
                            cevapa.text = sr.sorular[sorusayi].cevapa;
                            cevapb.text = sr.sorular[sorusayi].cevapb;
                            cevapc.text = sr.sorular[sorusayi].cevapc;
                            cevapd.text = sr.sorular[sorusayi].cevapd;
                        }
                        else
                            SoruEkle(); 
                    }


                    else if (MainMenu.secilenkategori == "karisik")
                    {

                        if ((karisiktoplama == 1 && kategori == "toplama") || (karisikcikarma == 1 && kategori == "cikarma") || (karisikcarpma == 1 && kategori == "carpma") || (karisikbolme == 1 && kategori == "bolme"))
                        {

                        
                            cevap = sr.sorular[sorusayi].cevap;

                            skorsayisi++;
                            skorsayisiyazi.text = "" + skorsayisi;
                            süre = 10; 
                            soruismi.text = sr.sorular[sorusayi].soruismi;
                            cevapa.text = sr.sorular[sorusayi].cevapa;
                            cevapb.text = sr.sorular[sorusayi].cevapb;
                            cevapc.text = sr.sorular[sorusayi].cevapc;
                            cevapd.text = sr.sorular[sorusayi].cevapd;
                        }
                        else
                            SoruEkle(); 

                    }


                    else if ((MainMenu.secilenkategori) == kategori) 
                    {
                      

                        cevap = sr.sorular[sorusayi].cevap;

                        skorsayisi++;
                        skorsayisiyazi.text = "" + skorsayisi;
                        süre = 10; 
                        soruismi.text = sr.sorular[sorusayi].soruismi;
                        cevapa.text = sr.sorular[sorusayi].cevapa;
                        cevapb.text = sr.sorular[sorusayi].cevapb;
                        cevapc.text = sr.sorular[sorusayi].cevapc;
                        cevapd.text = sr.sorular[sorusayi].cevapd;

                    }
                    else
                    {
                        SoruEkle();
                    }

                }
                else
                {
                    SoruEkle();
                }




            }
            else
            {
                SoruEkle();
            }
        }
        else 
        {


            Debug.Log("Oyunu Kazandýn");

            süre = 99; 


            totalpuan += puan;             

            puanpaneltext.text = puan.ToString();
            dogrusayisipaneltext.text = dogrusayisi.ToString();
            yanlissayisipaneltext.text = yanlissayisi.ToString();
            totalpuanpaneltext.text = totalpuan.ToString();   
            rekabetciskorpaneltext.text = enyuksekpuan.ToString();
            PlayerPrefs.SetInt("totalpuan", totalpuan);   

            panelim.SetActive(true);

        }





    }




    public void CevapVer(int deger)
    {


        if (süre != 99) 
        {

            if (timersesackapa == 1)  
            {
                Ses.TimerSesiKapa();
                CancelInvoke(); 
                             

            }


            if (MainMenu.secilenkategori == "rekabetci")
            {
                if (deger == cevap)
                {
                    
                    if (seslerackapa == 1)
                    {
                        Ses.DogruSesiCal();  
                    }


                    if (deger == 1)
                        buton1.image.color = yesilRenk;
                    if (deger == 2)
                        buton2.image.color = yesilRenk;
                    if (deger == 3)
                        buton3.image.color = yesilRenk;
                    if (deger == 4)
                        buton4.image.color = yesilRenk;

                    Invoke("SoruEkle", (float)1.2); 


                    süre = 99; 

                    puan += 3;
                    puanyazi.text = puan.ToString();

                    dogrusayisi += 1;


                }
                else
                {
                    
                    if (seslerackapa == 1)
                    {
                        Ses.YanlisSesiCal();
                    }

                    if (deger == 1)
                        buton1.image.color = kirmiziRenk;
                    if (deger == 2)
                        buton2.image.color = kirmiziRenk;
                    if (deger == 3)
                        buton3.image.color = kirmiziRenk;
                    if (deger == 4)
                        buton4.image.color = kirmiziRenk;


                    if (cevap == 1)
                        buton1.image.color = yesilRenk;
                    if (cevap == 2)
                        buton2.image.color = yesilRenk;
                    if (cevap == 3)
                        buton3.image.color = yesilRenk;
                    if (cevap == 4)
                        buton4.image.color = yesilRenk;


                    Invoke("SoruEkle", (float)1.2);
                    süre = 99;
                    Debug.Log("Yanlýþ Cevap");

                    puan -= 1;
                    puanyazi.text = puan.ToString();

                    yanlissayisi += 1;
                    if( puan>=enyuksekpuan)
                    {
                        Debug.Log("Tebrikler Yeni Rekor");
                        enyuksekpuan = puan;                   
                        PlayerPrefs.SetInt("enyuksekpuan", puan); 
                    }
                    else
                    {
                        Debug.Log("Rekor Kýrýlamadý");

                    }

                    totalpuan += puan;            
                    totalpuanpaneltext.text = totalpuan.ToString();  
                    rekabetciskorpaneltext.text = enyuksekpuan.ToString();
                    PlayerPrefs.SetInt("totalpuan", totalpuan);  
                    puanpaneltext.text = puan.ToString();
                    dogrusayisipaneltext.text = dogrusayisi.ToString();
                    yanlissayisipaneltext.text = yanlissayisi.ToString();           
                    panelim.SetActive(true); 

                }

            }
            else  
            {
                if (deger == cevap)
                {
                    sayac++;
                    if (seslerackapa == 1)
                    {
                        Ses.DogruSesiCal(); 
                    }


                    if (deger == 1)
                        buton1.image.color = yesilRenk;
                    if (deger == 2)
                        buton2.image.color = yesilRenk;
                    if (deger == 3)
                        buton3.image.color = yesilRenk;
                    if (deger == 4)
                        buton4.image.color = yesilRenk;

                    Invoke("SoruEkle", (float)1.2);  

                    
                    süre = 99; 

                    puan += 3;
                    puanyazi.text = puan.ToString();

                    dogrusayisi += 1;

                  
                }
                else
                {
                    sayac++;
                    if (seslerackapa == 1)
                    {
                        Ses.YanlisSesiCal();
                    }


                 
                    if (deger == 1)
                        buton1.image.color = kirmiziRenk;
                    if (deger == 2)
                        buton2.image.color = kirmiziRenk;
                    if (deger == 3)
                        buton3.image.color = kirmiziRenk;
                    if (deger == 4)
                        buton4.image.color = kirmiziRenk;


                    if (cevap == 1) 
                        buton1.image.color = yesilRenk;
                    if (cevap == 2)
                        buton2.image.color = yesilRenk;
                    if (cevap == 3)
                        buton3.image.color = yesilRenk;
                    if (cevap == 4)
                        buton4.image.color = yesilRenk;

                  
                    Invoke("SoruEkle", (float)1.2);
                    süre = 99;
                    Debug.Log("Yanlýþ Cevap");

                    puan -= 1;
                    puanyazi.text = puan.ToString();

                    yanlissayisi += 1;

                }

            }

            


        }
    }

    public void AnaMenuDon()
    {
        SceneManager.LoadScene(0);
    }

    public void YeniTest()
    {
        

        SceneManager.LoadScene(1);

    }

    public void TimerSes()
    {

        Ses.TimerSesiCal();
       
    }



}
