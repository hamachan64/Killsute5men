using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStatusSO : ScriptableObject
{
    public List<EnemyStatus> enemyStatusList = new List<EnemyStatus>();

    [System.Serializable]
    public class EnemyStatus
    {
        [SerializeField] string enemyName;
        [TextArea]
        [SerializeField] string description;
        [SerializeField] enemyType type;
        [SerializeField] int _hp;
        [SerializeField] int _mp;
        [SerializeField] int _attack;
        [SerializeField] int _defence;
        [SerializeField] float _speed;

        public enum enemyType
        {
            nomal,
            fire,
            water,
        }
        public int HP { get => _hp;}
        public int MP { get => _mp;}
        public int Attack { get => _attack;}
        public int Defence { get => _defence;}
        public float speed { get => _speed;}

    }
}
