using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseButton : MonoBehaviour
{
    private Animator animator;
    private bool isClosed;




    // Start is called before the first frame update
    void Start()
    {
        //if (!GameManager.instance.useTallyScreen0)
        //{
         //   ClosePanel();
        //}
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePanel()
    {
        Debug.Log(isClosed + " 1");

        if (animator.GetBool("ClosePanel") == false)
        {
            ClosePanel();
            Debug.Log("ClosePanel value is: " + animator.GetBool("ClosePanel"));
        }
        else if(animator.GetBool("ClosePanel") == true)
        {
            OpenPanel();
            Debug.Log("ClosePanel value is: " + animator.GetBool("ClosePanel"));

        }


        Debug.Log(isClosed + " 2");

    }

    public void ClosePanel()
    {
        animator.SetTrigger("ClosePanel");
        isClosed = true;

    }

    public void OpenPanel()
    {
        animator.SetTrigger("OpenPanel");
        isClosed = false;
    }
}
