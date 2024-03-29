﻿using Domain.Helpers;
using Domain.Phases;

namespace Domain.Actions
{
    public class DotnetPublishAction : Entities.Action
    {
        public DotnetPublishAction() : base()
        {
            Command = "dotnet publish";
        }

        public override void ConnectToPhase()
        {
            Phase = new DeployPhase();
        }

        public override void Execute()
        {
            Logger.DisplayCustomAlert(nameof(DotnetPublishAction), nameof(Execute), $"Execute {Command}!");
            Logger.DisplayCustomAlert(nameof(DotnetPublishAction), nameof(Execute), $"Successfully executed {Command} without any errors!");
        }

        public override string Print()
        {
            return $"{nameof(DotnetPublishAction)} {Command}";
        }
    }
}
