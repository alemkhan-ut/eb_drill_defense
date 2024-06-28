using MadSnail.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Services.EventServices
{
    public static class GlobalEvents
    {
        // Sample:
        // public static ExampleEvent ExampleEvent = new ExampleEvent();

        public static PlayerOnAttackEvent PlayerOnAttackEvent = new PlayerOnAttackEvent();
    }

    // public class ExampleEvent : IGameEvent
    // {
    //     // Properties
    // }

    public class EnemyOnHitEvent : IGameEvent
    {

    }

    public class PlayerOnAttackEvent : IGameEvent
    {

    }
}