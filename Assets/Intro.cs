using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Intro : MonoBehaviour
{

    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;

    public Image image1;
    public Image image2;
    public Image image3;

    private string str1;
    private string str2;
    private string str3;

    private float hiderOpacity = 0f;

    public Image hider;
    private int index;
    private float opac;
    private float titleOpac = 0;

    public AudioSource introMusic;
    public AudioSource type;

    public TMP_Text title;

    public Button screen;

    // Start is called before the first frame update
    void Start()
    {
        str1 = "Seorang gadis bernama Geeta sedang memainkan biola miliknya di dalam hutan.";
        str2 = "Geeta terlalu asyik memainkan sebuah musik hingga tidak sadar bahwa tanah yang ia pijak tiba-tiba runtuh membuat sebuah lubang yang dalam.";
        str3 = "Geeta jatuh ke dalam sebuah dunia yang berisi boneka beraneka ragam bentuk dan hidup berdampingan dengan musik. Dengan biola miliknya, Geeta harus bertahan hidup dengan bertarung melawan para boneka dengan memainkan alunan nada dari biolanya.";
        text1.text = "";
        text2.text = "";
        text3.text = "";
        hider.color = new Color(1f, 1f, 1f, 0f);
        image1.color = new Color(1f, 1f, 1f, 0f);
        image2.color = new Color(1f, 1f, 1f, 0f);
        image3.color = new Color(1f, 1f, 1f, 0f);
        title.color = new Color(1f, 1f, 1f, 0f);
        StartCoroutine(StartIntro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartIntro() {

        opac = 0f;
        while (image1.color.a < 1f) {
            yield return new WaitForSeconds(0.1f);
            opac += 0.05f;
            image1.color = new Color(1f, 1f, 1f, opac);
            text1.color = new Color(1f, 1f, 1f, opac);
        }

        index = 0;
        text1.text += "<line-height=180%>";

        while (text1.text.Length < str1.Length + 18) {
            yield return new WaitForSeconds(0.07f);
            text1.text += str1[index];
            if (!str1[index].Equals(" ")) type.Play(0);
            index++;
        }

        yield return new WaitForSeconds(2f);

        while (image1.color.a > 0f) {
            yield return new WaitForSeconds(0.1f);
            opac -= 0.05f;
            image1.color = new Color(1f, 1f, 1f, opac);
            text1.color = new Color(1f, 1f, 1f, opac);
        }

        text1.text = "";

        yield return new WaitForSeconds(0.5f);

        while (image2.color.a < 1f) {
            yield return new WaitForSeconds(0.1f);
            opac += 0.05f;
            image2.color = new Color(1f, 1f, 1f, opac);
            text2.color = new Color(1f, 1f, 1f, opac);
        }
        
        index = 0;
        text2.text += "<line-height=180%>";

        while (text2.text.Length < str2.Length + 18) {
            yield return new WaitForSeconds(0.07f);
            text2.text += str2[index];
            if (!str2[index].Equals(" ")) type.Play(0);
            index++;
        }
        yield return new WaitForSeconds(2f);

        while (image2.color.a > 0f) {
            yield return new WaitForSeconds(0.1f);
            opac -= 0.05f;
            image2.color = new Color(1f, 1f, 1f, opac);
            text2.color = new Color(1f, 1f, 1f, opac);
        }

        text2.text = "";

        yield return new WaitForSeconds(0.5f);

        while (image3.color.a < 1f) {
            yield return new WaitForSeconds(0.1f);
            opac += 0.05f;
            image3.color = new Color(1f, 1f, 1f, opac);
            text3.color = new Color(1f, 1f, 1f, opac);
        }
        
        index = 0;
        text3.text += "<line-height=180%>";

        while (text3.text.Length < str3.Length + 18) {
            yield return new WaitForSeconds(0.07f);
            text3.text += str3[index];
            if (!str3[index].Equals(" ")) type.Play(0);
            index++;
        }
        yield return new WaitForSeconds(2f);

        while (image2.color.a > 0f) {
            yield return new WaitForSeconds(0.1f);
            opac -= 0.05f;
            image2.color = new Color(1f, 1f, 1f, opac);
            text2.color = new Color(1f, 1f, 1f, opac);
        }

        while (image3.color.a > 0f) {
            yield return new WaitForSeconds(0.1f);
            opac -= 0.05f;
            image3.color = new Color(1f, 1f, 1f, opac);
            text3.color = new Color(1f, 1f, 1f, opac);
            hider.color = new Color(0f, 0f, 0f, 1f - opac);
            introMusic.volume -= 0.05f;
        }

        introMusic.Stop();

        StartCoroutine(Geeta());
    }

    public IEnumerator Skip() {

        screen.interactable = false;

        while (hiderOpacity < 1) {
            yield return new WaitForSeconds(0.1f);
            hiderOpacity += 0.05f;
            introMusic.volume -= 0.05f;
            type.volume -= 0.05f;
            hider.color = new Color(0f, 0f, 0f, hiderOpacity);
        }

        introMusic.Stop();
        
        yield return new WaitForSeconds(1.5f);

        StartCoroutine(Geeta());

    }

    public void StartSkip() {
        StartCoroutine(Skip());
    }

    public IEnumerator Geeta() {

        while (title.color.a < 1f) {
            yield return new WaitForSeconds(0.1f);
            titleOpac += 0.05f;
            title.color = new Color(1f, 1f, 1f, titleOpac);
        }

        yield return new WaitForSeconds(1.5f);

        while (title.color.a > 0f) {
            yield return new WaitForSeconds(0.1f);
            titleOpac -= 0.05f;
            title.color = new Color(1f, 1f, 1f, titleOpac);
        }

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(1);

    }

}
