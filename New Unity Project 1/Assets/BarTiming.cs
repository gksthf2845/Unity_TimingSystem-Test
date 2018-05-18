using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarTiming : MonoBehaviour
{
    public Image FillTexture;
    public Image Handler;
    public Text text;

    [Range(0, 1)]
    public float fillrange = 1; //허용범위를 확인하려면 업데이트문으로 옮겨서 확인하세요

    RectTransform RectTr;
    RectTransform FiilRecrTr;
    RectTransform HandleTr;


    public float fiilrangeStart;
    public float handlerMoveSpeed;

    public float fillLimitValue;

    private void Awake()
    {
        

        RectTr = GetComponent<RectTransform>();

        FiilRecrTr = FillTexture.GetComponent<RectTransform>();
        HandleTr = Handler.GetComponent<RectTransform>();
        //사이즈
        RectTr.sizeDelta = new Vector2(RectTr.rect.width, RectTr.rect.height);
        //허용범위의 사이즈


        HandleTr.sizeDelta = new Vector2(HandleTr.rect.width, RectTr.rect.height);


        RandomSet();

        // RandomSet();
    }
    public float aa;
    void Update()
    {
        aa =FiilRecrTr.localPosition.x;

        FiilRecrTr.sizeDelta = new Vector2(Mathf.Clamp(FiilRecrTr.rect.width, 0, RectTr.rect.width - FiilRecrTr.localPosition.x), RectTr.rect.height);
        //  fillLimitValue = RectTr.rect.width +  



        //핸들 이동
        HandleTr.transform.position = new Vector3(HandleTr.transform.position.x + handlerMoveSpeed, RectTr.transform.position.y, 0);
            //실시간 범위값 변경
           // FiilRecrTr.sizeDelta = new Vector2(Mathf.Clamp(RectTr.rect.width, RectTr.rect.width,)  , RectTr.rect.height);

            if ((HandleTr.transform.position.x + HandleTr.rect.width) >= RectTr.transform.position.x + RectTr.rect.width)
            {//핸들이 끝까지 갔을때
                handlerMoveSpeed *= -1;
            }

            if (HandleTr.transform.position.x < RectTr.transform.position.x)
            {//핸들이 한번  순회가 끝났을때
            handlerMoveSpeed *= -1;
            //this.gameObject.SetActive(false);
            HandleTr.transform.position = new Vector3(RectTr.transform.position.x, RectTr.transform.position.y, -1);
            }

            //핸들이 범위에 들어왓을때.
            if ((HandleTr.transform.position.x + HandleTr.rect.width) >= FiilRecrTr.transform.position.x &&
               (HandleTr.transform.position.x + HandleTr.rect.width) <= FiilRecrTr.transform.position.x + FiilRecrTr.rect.width)
            {
            text.text = "in";
            }
            else
            {
            text.text = "out";

        }
    }
    public void RandomSet()
    {

        FiilRecrTr.transform.position = new Vector3(0, RectTr.transform.position.y, -1);
        HandleTr.transform.position = new Vector3(RectTr.transform.position.x, RectTr.transform.position.y, -1);

        fiilrangeStart = Random.Range(0, RectTr.rect.width - RectTr.rect.width *0.1f ); //(,fillrange)

        FiilRecrTr.localPosition = new Vector3(fiilrangeStart, FiilRecrTr.localPosition.y, 0);
        //fill의 시작점 + 끝점 < rect의 끝점
    }

}

