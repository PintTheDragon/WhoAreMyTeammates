﻿using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Diagnostics.Tracing;
using WhoAreMyTeammates.Handlers;
using Server = Exiled.Events.Handlers.Server;

namespace WhoAreMyTeammates
{
    public class WhoAreMyTeammates : Plugin<Config>
    {
        public override string Name { get; } = "WhoAreMyTeamates?";
        public override string Author { get; } = "XoMiya-WPC & TheUltiOne";
        public override string Prefix { get; } = "Who_Are_My_Teammates";
        public override Version Version { get; } = new Version("3.2.0");

        public static WhoAreMyTeammates Instance;

        private EventHandlers events;

        public override void OnEnabled()
        {
            events = new EventHandlers();
            Server.RoundStarted += events.OnRoundStarted;
            Log.Info("Thanks for installing Who Are My Teammates :)");
            Instance = this;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Server.RoundStarted -= events.OnRoundStarted;
            events = null;
            base.OnDisabled();
        }
    }
}