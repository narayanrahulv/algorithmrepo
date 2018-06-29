using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the checkMagazine function below.
    static void checkMagazine(string[] magazine, string[] note) {
        Dictionary<string, int> wordCountM = new Dictionary<string, int>(); 
        Dictionary<string, int> wordCountN = new Dictionary<string, int>(); 
        
        int value;
        for(int i=0; i<magazine.Length; i++){
            if (wordCountM.TryGetValue(magazine[i], out value))
            {
                wordCountM[magazine[i]] = value + 1;
            }
            else {
                wordCountM.Add(magazine[i],1);
            }
        }

        int valueN;
        for(int j=0; j<note.Length; j++){
            if (wordCountN.TryGetValue(note[j], out valueN))
            {
                wordCountN[note[j]] = valueN + 1;
            }
            else {
                wordCountN.Add(note[j],1);
            }
        }
        
        bool result = true;
        
        foreach(KeyValuePair<string,int> item in wordCountN){
           if(!wordCountM.Contains(item)){
               if(wordCountM.ContainsKey(item.Key) && wordCountM[item.Key] < item.Value)
               result = false;
           }
        }
        
        if(result == true){
            Console.WriteLine("Yes");
        }
        else{
            Console.WriteLine("No");
        }
    }

    static void Main(string[] args) {
        string[] mn = Console.ReadLine().Split(' ');

        int m = Convert.ToInt32(mn[0]);

        int n = Convert.ToInt32(mn[1]);

        string[] magazine = Console.ReadLine().Split(' ');

        string[] note = Console.ReadLine().Split(' ');

        checkMagazine(magazine, note);
    }
}
