using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    private Image healthCarrot, healthPear;

    [SerializeField]
    private Text textCoin, textCarrot, textPear;

    float maxCarrot, maxPear;

    // Start is called before the first frame update
    void Start()
    {
        healthCarrot.fillAmount = 0.5f;
        healthPear.fillAmount = 0.5f;
        maxCarrot = 20;
        maxPear = 20;
    }

    // Update is called once per frame
    void Update()
    {
        CheckBalance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("carrot") || collision.CompareTag("pear") || collision.CompareTag("coin"))
        {
            if (healthCarrot.fillAmount >= 0 && healthCarrot.fillAmount <= 1 && healthPear.fillAmount >= 0 && healthPear.fillAmount <= 1)
            {
                if (collision.CompareTag("carrot"))
                {
                    AscendingCarrot();
                    AudioManager.instance.PlaySound("candy");
                }
                if (collision.CompareTag("pear"))
                {
                    AscendingPear();
                    AudioManager.instance.PlaySound("candy");
                }
                if (collision.CompareTag("coin"))
                {
                    ValueTextCoin();
                    AudioManager.instance.PlaySound("diamond");
                }
            }
            Destroy(collision.gameObject);
        }
    }

    void CheckBalance()
    {
        if (healthCarrot.fillAmount <= 0f || healthPear.fillAmount <= 0f)
        {
            UIManager.instance.ShowDeathUI();
        }
    }

    void FillAmountFruitBar()
    {
        if (GameManager.instance.pointCarrot == maxCarrot || GameManager.instance.pointPear == maxPear)
        {
            maxCarrot += 10;
            maxPear += 10;
        }
        healthCarrot.fillAmount = GameManager.instance.pointCarrot / maxCarrot;
        healthPear.fillAmount = GameManager.instance.pointPear / maxPear;
    }

    void AscendingCarrot()
    {
        GameManager.instance.hitCarrot++;
        GameManager.instance.pointCarrot++;
        textCarrot.text = GameManager.instance.pointCarrot.ToString();
        DecreasePear();
        FillAmountFruitBar();
    }

    void AscendingPear()
    {
        GameManager.instance.hitPear++;
        GameManager.instance.pointPear++;
        textPear.text = GameManager.instance.pointPear.ToString();
        DecreaseCarrot();
        FillAmountFruitBar();
    }

    void DecreaseCarrot()
    {
        GameManager.instance.pointCarrot--;
        textCarrot.text = GameManager.instance.pointCarrot.ToString();
    }

    void DecreasePear()
    {
        GameManager.instance.pointPear--;
        textPear.text = GameManager.instance.pointPear.ToString();
    }

    void ValueTextCoin()
    {
        GameManager.instance.hitCoin++;
        GameManager.instance.pointCoin++;
        textCoin.text = GameManager.instance.pointCoin.ToString();
    }

    public void ResetFruitBar()
    {
        healthCarrot.fillAmount = 0.5f;
        healthPear.fillAmount = 0.5f;
        textCarrot.text = "10";
        textPear.text = "10";
        textCoin.text = "0";
        maxCarrot = 20;
        maxPear = 20;
    }
}
