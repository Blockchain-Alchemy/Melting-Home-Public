using System.Collections;
using UnityEngine;
using System;

[Serializable] 
public class TransactionData 
{
    public TransactionItem[] items;
 
    public static TransactionData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<TransactionData>(jsonString);
    }
}

[Serializable]
public class TransactionItem
{
    public string name;
    public int value;
}