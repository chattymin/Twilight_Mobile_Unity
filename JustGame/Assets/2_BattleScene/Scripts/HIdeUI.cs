using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIdeUI : MonoBehaviour
{
    public const int speed = 20;
   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (StateSetting.CompareStates("BattleST")) {
            if (this.transform.position.y > -255)
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed, this.transform.position.z);
        }
        else{
            if (this.transform.position.y < 30)
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed, this.transform.position.z);
        }
    }
}
