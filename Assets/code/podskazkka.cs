using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class podskazkka : MonoBehaviour
{
    public GameObject note;
    public bool issPlayerNear = false;
   public void Show()
    {
        note.SetActive(true);
    
    }

    public void Hide()

    {


        note.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            issPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            issPlayerNear = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (issPlayerNear)
        {
            Show();
        }
    }
}
