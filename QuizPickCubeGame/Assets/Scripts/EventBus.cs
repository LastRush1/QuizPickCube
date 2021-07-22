using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus
{
    private static Dictionary<Type, List<IGlobalSubscriber>> s_Subscribers
       = new Dictionary<Type, List<IGlobalSubscriber>>();


}
