using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class quizMain : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI qtext;
    [SerializeField] Questionscript qscript;
    [SerializeField] GameObject[] answerbuttons;
    Color32 defaultcolor;
    [SerializeField] int correctAnswer;
    [SerializeField] Sprite correctSprite;
    [SerializeField] Sprite defaultSprite;

    public bool answered = false;

    // Start is called before the first frame update
    void Start()
    {
        defaultcolor = answerbuttons[0].GetComponent<Image>().color;
        qtext.text = qscript.getQuestion();
        answered = false;
        for (int i = 0; i < 4; i++)
        {
            TextMeshProUGUI buttontext = answerbuttons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttontext.text = qscript.getAnswer(i);
            Debug.Log(buttontext.text);
        }
    }
   
    public void onAnswerSelected(int index)
    {
        if (!answered)
        {
            Debug.Log("Button pressed");
            Image BtnImage = answerbuttons[index].GetComponent<UnityEngine.UI.Image>();
            Image CrctImg = answerbuttons[qscript.getCorrectAns()].GetComponent<Image>();
            defaultcolor = BtnImage.GetComponent<Image>().color;
            if (index == qscript.getCorrectAns())
            {
                qtext.text = "CORRECT ANSWER !! ";
                BtnImage.sprite = correctSprite;
                BtnImage.color = Color.green;
            }
            else
            {
                qtext.text = " incorrect answer , correct answer is :";
                BtnImage.color = Color.red;
                CrctImg.color = Color.green;
            }
            answered = true;

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
