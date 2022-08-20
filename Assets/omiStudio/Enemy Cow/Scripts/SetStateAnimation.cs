using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetStateAnimation : MonoBehaviour
{
  // Start is called before the first frame update
  public GameObject cow1, cow2;
  public Button btn1;


  public void setIdle()
  {
    
    cow1.GetComponent<Animator>().SetInteger("State", 0);
    cow2.GetComponent<Animator>().SetInteger("State", 0);

  }
  public void setWalk()
  {
   
    cow1.GetComponent<Animator>().SetInteger("State", 1);
    cow2.GetComponent<Animator>().SetInteger("State", 1);

  }

  public void setRun()
  {
   
    cow1.GetComponent<Animator>().SetInteger("State", 2);
    cow2.GetComponent<Animator>().SetInteger("State", 2);

  }

  




  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
