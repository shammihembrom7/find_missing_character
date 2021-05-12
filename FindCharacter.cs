using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class FindCharacter : MonoBehaviour
{

    List<char> char_list = new List<char>();
    int ascii_code_sum;


    void Start()
    {
        GenerateRandomizedCharList();
        RemoveRandomCharacter();

        FindMissingCharacter();
    }




    void FindMissingCharacter()
    {
        int a1 = Encoding.ASCII.GetBytes("A")[0];   //Get ASCII code of first character
        int an = Encoding.ASCII.GetBytes("Z")[0];   //Get ASCII code of last character

        ascii_code_sum = (26/2) * (a1 + an);        //Sum of sequence = n/2(a1+an), (Adding ASCII codes of characters a )

        foreach (int a in Encoding.ASCII.GetBytes(new string(char_list.ToArray())))
        {
            ascii_code_sum -= a;                    //Subtract all ASCII codes from the sum, remaining value will be the ASCII code of missing character
        }

        print("ASCII code of missing char: " + ascii_code_sum.ToString());
        print("Missing char was: " + System.Convert.ToChar(ascii_code_sum));
    }






    void RemoveRandomCharacter()
    {
        int v = Random.Range(0, char_list.Count);
        print("Randomly removed character: '"+char_list[v] + "' from the list");
        char_list.RemoveAt(v);
    }

    void GenerateRandomizedCharList()
    {
        List<int> code_list = new List<int>();

        for(int i=65; i<=90; i++)
        {
            code_list.Add(i);
        }

        for(int i = 0; i < 26; i++)
        {
            int v = Random.Range(0, code_list.Count);
            char_list.Add(System.Convert.ToChar(code_list[v]));
            code_list.RemoveAt(v);
        }

        print("Characters A to Z is added to a list at random: "+"[ " + String.Join(", ",char_list) + " ]");
    }
}
