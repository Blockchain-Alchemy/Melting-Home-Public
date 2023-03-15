using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class DonationManager : MonoBehaviour
{
    // We Register the External Call Here
    [DllImport("__Internal")]
    private static extern void SendTransaction(string jsonString);

    public TextMeshProUGUI data_text;
    public GameObject inputField;
    public Animator penguin;
    public LoadingScreenManager loader;
    public int cause1;
    public int cause2;
    public int cause3;
    public int cause4;
    public string email;
    public string cause1s;
    public string cause2s;
    public string cause3s;
    public string cause4s;
    private int totalDonation;
    private TransactionData transaction_data;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void AddCause1(){
        cause1++;
        UpdateAll();
    }
    public void AddCause2(){
        cause2++;
        UpdateAll();
    }
    public void AddCause3(){
        cause3++;
        UpdateAll();
    }
    public void AddCause4(){
        cause4++;
        UpdateAll();
    }
    public void UpdateAll(){
        data_text.text = "";
        if(cause1>0)
            cause1s = cause1 + " Sol @ WAI \n";
        if(cause2>0)
            cause2s = cause2 + " Sol @ IFAW \n";
        if(cause3>0)
            cause3s = cause3 + " Sol @ TBZ \n";
        if(cause4>0)
            cause3s = cause4 + " Sol @ BlockAlc \n";
        
        totalDonation = (cause1+ cause2+ cause3+cause4);
        data_text.text = cause1s + cause2s + cause3s + cause4s + "\n TOTAL \n"+ totalDonation + " Sol"; 

        if(totalDonation == 0 )
            penguin.SetInteger("animation", 5);
        if(totalDonation == 1 )
            penguin.SetInteger("animation", 3);
        if(totalDonation == 2 )
            penguin.SetInteger("animation", 4);
        if(totalDonation == 3 )
            penguin.SetInteger("animation", 1);
        if(totalDonation >= 4 )
            penguin.SetInteger("animation", 2);
        
    }
    public void ClearAll(){
        cause1 = 0;
        cause2 = 0;
        cause3 = 0;
        cause4 = 0;
        UpdateAll();

    }
	
	  public void GoPlay2(){
         Debug.Log("Go Play 2  Has Been Called!");
      }
    public void GoPlay(){
        Debug.Log("Go Play Has Been Called!");

        email = inputField.GetComponent<TMP_InputField>().text;
        Transaction transaction = new Transaction();
        transaction.email = email;
        if (totalDonation > 0){
			transaction.email = email;
			transaction.cause1 = cause1;
			transaction.cause2 = cause2;
			transaction.cause3 = cause3;
			transaction.cause4 = cause4;
	    // SendTransaction(transaction_data);
        }
        string transaction_data = JsonUtility.ToJson(transaction);
        SendTransaction(transaction_data);
    }
    public void TransactionComplete(){
        loader.LoadScene("main_scene");
        Debug.Log("Transaction Complete Has Been Called!");
    }
    public void TransactionFailed(string error){
        Debug.Log("Transaction Failed Has Been Called! Error: " + error);
    }

	[Serializable]
	public class Transaction
	{
		public string email;
		public int cause1;
		public int cause2;
		public int cause3;
		public int cause4;
	}
}
