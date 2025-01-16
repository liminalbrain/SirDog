using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
   public int NumberOfTreats { get; private set; }

    public void TreatCollected()
    {
        NumberOfTreats++;
    }
}
