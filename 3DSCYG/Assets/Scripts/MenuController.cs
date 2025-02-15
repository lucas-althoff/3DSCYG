using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Canvas))]
[DisallowMultipleComponent]
public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Page InitialPage;
    [SerializeField]
    private GameObject FirstFocusItem;

    private Canvas RootCanvas;

    private Stack<Page> PageStack = new Stack<Page>();

    private void Awake()
    {
        RootCanvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        if (FirstFocusItem != null)
        {
            EventSystem.current.SetSelectedGameObject(FirstFocusItem);
        }

        if (InitialPage != null)
        {
            PushPage(InitialPage);
        }
    }

    private void OnCancel()
    {
        if (RootCanvas.enabled && RootCanvas.gameObject.activeInHierarchy)
        {
            if (PageStack.Count != 0)
            {
                PopPage();
            }
        }
    }

    public bool IsPageInStack(Page Page)
    {
        return PageStack.Contains(Page);
    }

    public bool IsPageOnTopOfStack(Page Page)
    {
        return PageStack.Count > 0 && Page == PageStack.Peek();
    }

    public void PushPage(Page Page)
    {
        Page.Enter(true);

        if (PageStack.Count > 0)
        {
            Page currentPage = PageStack.Peek();

            if (currentPage.ExitOnNewPagePush)
            {
                currentPage.Exit(false);
            }
        }

        PageStack.Push(Page);
        
    }

    public void PushTwoPages(Page Page, Page Page2)
    {
        Page.Enter(true);
        Page2.Enter(true);
        
        if (PageStack.Count > 0)
        {
            Page currentPage = PageStack.Peek();

            if (currentPage.ExitOnNewPagePush)
            {
                currentPage.Exit(false);
            }
        }

        PageStack.Push(Page);
        PageStack.Push(Page2);
        
    }

    public void PopPage()
    {
        if (PageStack.Count > 1)
        {
            Page page = PageStack.Pop();
            page.Exit(true);

            Page newCurrentPage = PageStack.Peek();
            if (newCurrentPage.ExitOnNewPagePush)
            {
                newCurrentPage.Enter(false);
            }
        }
        else
        {
            Debug.LogWarning("Trying to pop a page but only 1 page remains in the stack!");
        }
    }

    public void PopAllPages()
    {
        for (int i = 1; i < PageStack.Count; i++)
        {
            PopPage();
        }
    }

   public void initAgain(Page Page)
    {
        EventSystem.current.SetSelectedGameObject(FirstFocusItem);
        PushPage(Page);
    }

    public void invokePush2sec(Page Page)
    {
        StartCoroutine(Push2sec(Page.GetComponent<Page>()));
    }

    IEnumerator Push2sec(Page Page) 
    {
        // if (!activeSelf) 
        // {
        //     Page.SetActive(true);
        // }
         
        yield return new WaitForSeconds(2);
        PushPage(Page);
        Debug.Log("Will leave page after 2 seconds");
    }

    public void loadExit() 
    {
        Invoke("PopAllPages", 2);
        SceneManager.LoadScene("MissaoLazerCulturaArte1");

        Debug.Log("Will leave page after 2 seconds");
    }
}
