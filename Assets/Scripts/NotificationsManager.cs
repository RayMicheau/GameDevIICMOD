using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NotificationsManager : MonoBehaviour {

    //Internal reference to all listeners for notifications
    private Dictionary<string, List<Component>> 
        Listeners = new Dictionary<string, List<Component>>();
    
    //add a listener for notification
    public void AddListener(Component sender, string NotificationName)
    {
        if(!Listeners.ContainsKey(NotificationName))
        {
            Listeners.Add(NotificationName, new List<Component>());
        }

        Listeners[NotificationName].Add(sender);
    }

    //Remove a listener for a notification
    public void RemoveListener(Component sender, string NotificationName)
    {
        if(!Listeners.ContainsKey(NotificationName))
        {
            return;
        }
        foreach(Component Listener in Listeners[NotificationName])
        {
            Listener.SendMessage(NotificationName, sender, 
                SendMessageOptions.DontRequireReceiver);
        }
    }

    //Function to remove redundant listeners - deleted and removed listeners
    public void RemoveRedundancies()
    {
        Dictionary<string, List<Component>> TmpListeners = new Dictionary<string, List<Component>>();

        //Cycle through all dictionary entries
        foreach(KeyValuePair<string, List<Component>> Item in Listeners)
        {
            //Cycle through all listener objects in list, remove null objects
            for(int i = Item.Value.Count-1; i>=0; i--)
            {
                //if null, remove the item
                if(Item.Value[i] == null)
                {
                    Item.Value.RemoveAt(i);
                }
            }

            //if items remain in list for this notification, then add this to tmp dictionary
            if(Item.Value.Count > 0)
            {
                TmpListeners.Add(Item.Key, Item.Value);
            }
        }

        //Replace listeners object with new, optimized dictionary
        Listeners = TmpListeners;
    }

    //Called when a new level is loaded; remove redundant entries from dictionary;
    //in case left-over was from previous scene
    void OnLevelWasLoaded()
    {
        //Clear Redundancies
        RemoveRedundancies();
    }
        
}
