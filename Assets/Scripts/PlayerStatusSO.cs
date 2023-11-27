using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStatusSO : ScriptableObject
{
    [SerializeField] int _hp;
    [SerializeField] int _mp;
    [SerializeField] int _attack;
    [SerializeField] int _defence;

    public int HP { get => _hp;}
    public int MP { get => _mp;}
    public int Attack { get => _attack;}
    public int Defence { get => _defence;}

}
