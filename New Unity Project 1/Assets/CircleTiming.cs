using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleTiming : MonoBehaviour {

   
    public float CurrentfillDegree;

    public float currentCheckDegree;

    public float spinSpeed=1;

    public float FillRange;

    public bool ClockWise = false;


    [Range(0, 1)]
    public float fillRangeMax = 1;

    public bool isFillRamdom;

    public RectTransform check;
    public RectTransform fill;
    public Image fillImage;
    public Text text;

    public float compatibleOffset=0; // 360  =1

	void Awake () {

        // check =GameObject.Find("FillobjectName").GetComponentInChildren<RectTransform>();
        //  fill = GameObject.Find("checkobjectName").GetComponentInChildren<RectTransform>();
        // fillImage = GameObject.Find("FillobjectName").GetComponent<Image>();

        CurrentfillDegree = Random.Range(0, 360);

        fill.rotation = Quaternion.Euler(0, 0, CurrentfillDegree);

        check.rotation = Quaternion.Euler(0,0,0);

        if (isFillRamdom) {
            fillImage.fillAmount = Mathf.Clamp(Random.Range(0, fillRangeMax), 0, 1 - (CurrentfillDegree / 360));
        }
        else
            fillImage.fillAmount = Mathf.Clamp(fillImage.fillAmount, 0, 1 - (CurrentfillDegree / 360)); 


        //StartCoroutine("Clockwise");

    }

    void Update () {

        compatibleOffset = fillImage.fillAmount * 360;

        FillRange = Mathf.Clamp(CurrentfillDegree + compatibleOffset, 0, 360);


        /*  if (CurrentfillDegree + compatibleOffset > 360)
          {
              FillRange = 360;

              currentCheckDegree = Mathf.Repeat(currentCheckDegree, FillRange);
          }
          else
          currentCheckDegree = Mathf.Repeat(currentCheckDegree,360 );
     */
        currentCheckDegree += spinSpeed ;
        currentCheckDegree = Mathf.Repeat(currentCheckDegree,360);


        check.rotation = Quaternion.Euler(check.rotation.x, check.rotation.y, currentCheckDegree);
       
        if ((currentCheckDegree >= CurrentfillDegree) && (currentCheckDegree <= FillRange))
        {// 
            text.text = "in";
        }
        else {
            text.text = "out";
        }

	}

    IEnumerator Clockwise ()
    {
        while (true) {
            if (!ClockWise)
            {
                spinSpeed *= -1;
                  yield return new WaitForSeconds(0.2f); 
            }
            else { spinSpeed = Mathf.Abs(spinSpeed);

                yield return new WaitForSeconds(0.2f);
            }
        }
        }
     
      
}
