using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MoneySystem : MonoBehaviour
{
    [SerializeField] int startingGold = 150;
    [SerializeField] int currentGold;

    [SerializeField] TextMeshProUGUI Gold;
    

    public int CurrentGold { get { return currentGold; } }

     void Awake()
    {
        currentGold = startingGold;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Gold.text = currentGold.ToString();
    }

    public void adding(int amount) 
    {
        currentGold += Mathf.Abs(amount);
    }

    public void extract(int amount)
    {
        currentGold -= Mathf.Abs(amount);

        if(currentGold < 0) 
        {
            reload();
        }
    }

   void reload() 
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
