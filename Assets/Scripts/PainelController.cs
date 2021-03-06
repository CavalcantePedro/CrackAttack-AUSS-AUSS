﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PainelController : MonoBehaviour
{

    [SerializeField] private int index;
    [SerializeField] private Animator pnAnim;
    [SerializeField] private GameObject right;
    [SerializeField] private GameObject left;

    void Start()
    {
        /* 
            0 = Language
            1 = Controllers
            2 = Visão
        */

        index = 1;
        left.SetActive(false);
    }

    public void LeftBtn(){
        if(index == 1){
            pnAnim.SetTrigger("SlideRight_1");
            right.SetActive(false);
            left.SetActive(true);
            index++;
        }
        else if(index == 0)
        {
            pnAnim.SetTrigger("SlideRight_0");
            left.SetActive(true);
            index++;
        }
        else
        {
            print("Erro: Invalid index");
        }
    }

    public void RightBtn(){
        if(index == 2)
        //o valor foi alterado para um para remover o daltonismo , voltar para 2 em breve
        {
            pnAnim.SetTrigger("SlideLeft_0");
            right.SetActive(true);
            left.SetActive(false);
            index--;
        }
        else if(index == 1)
        {
            pnAnim.SetTrigger("SlideLeft_-1");
            left.SetActive(false);
            index--;
        }
        else
        {
            print("Erro: Invalid index");
        }
    }
}
