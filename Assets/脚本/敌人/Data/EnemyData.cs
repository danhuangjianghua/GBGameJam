using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyData : ScriptableObject
{
    public EnemyDataType type;

    public  virtual void returnType(ref EnemyBehavior behaviour,GameObject g)
    {

    }
}
