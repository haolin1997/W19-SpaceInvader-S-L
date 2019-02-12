using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeScore : MonoBehaviour
{
    TextMeshProUGUI tm;

    // Start is called before the first frame update
    void Start()
    {
        tm = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tm.text = string.Format("Score: {0:0}", EnemyMovement.destroy_count);
    }
}
