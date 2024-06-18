using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HumanUI : MonoBehaviour
{
    public Slider sliderhealth;

    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {

        sliderhealth.maxValue = MatchManager.instance.HP;
    }

    // Update is called once per frame
    void Update()
    {
       
        sliderhealth.value = Mathf.Lerp(sliderhealth.value, MatchManager.instance.HP, 6 * Time.deltaTime);
    }
}
