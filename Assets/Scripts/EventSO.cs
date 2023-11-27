using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EventSO : ScriptableObject
{
    public List<Events> eventsList = new List<Events>();

    [System.Serializable]
    public class Events
    {
        [SerializeField] string personName;
        [TextArea]
        [SerializeField] string eventDescription;

        public string PersonName { get => personName; }
        public string EventDescription { get => eventDescription; }
    }
}
