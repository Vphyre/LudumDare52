using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public List<GameObject> dialogs;
    private Collider2D dialogCollider;
    void Start()
    {
        if (PlayerPrefs.GetInt("NoDialog") > 0)
        {
            gameObject.SetActive(false);
            return;
        }
        dialogCollider = GetComponent<Collider2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetDialog();
        }
    }
    private void GetDialog()
    {
        if (GameManager.Instance.dayCount == 0)
        {
            dialogs[0].SetActive(true);
            TurnOffCollider();
        }
        if (GameManager.Instance.dayCount == 1)
        {
            dialogs[1].SetActive(true);
            TurnOffCollider();
        }
        if (GameManager.Instance.dayCount == 2)
        {
            dialogs[2].SetActive(true);
            TurnOffCollider();
        }
        if (GameManager.Instance.dayCount == 3)
        {
            dialogs[3].SetActive(true);
            TurnOffCollider();
        }
        if (GameManager.Instance.dayCount == 4)
        {
            dialogs[4].SetActive(true);
            TurnOffCollider();
        }
        if (GameManager.Instance.dayCount == 5)
        {
            dialogs[5].SetActive(true);
            TurnOffCollider();
        }
        if (GameManager.Instance.dayCount == 6)
        {
            // dialogs[6].SetActive(true);
            TurnOffCollider();
        }
        if (GameManager.Instance.dayCount == 7)
        {
            dialogs[6].SetActive(true);;
            TurnOffCollider();
        }
    }
    public void TurnOnCollider()
    {
        dialogCollider.enabled = true;
    }
    public void TurnOffCollider()
    {
        dialogCollider.enabled = false;
    }
}
