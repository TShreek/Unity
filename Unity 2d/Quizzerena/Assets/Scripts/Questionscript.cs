using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quiz Question", fileName ="Question" )]
public class Questionscript : ScriptableObject
{
    [TextArea(2,6)] 
    [SerializeField] string question = "What are you using for the programming bit?";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int answer = 2;

    public string getQuestion()
    {
        return question;
    }

    public string getAnswer(int index)
    {
        return answers[index];
    }
    public int getCorrectAns()
    {
        return answer;
    }

}
