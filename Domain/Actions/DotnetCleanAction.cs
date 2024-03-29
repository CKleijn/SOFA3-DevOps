﻿using Domain.Helpers;
using Domain.Phases;

namespace Domain.Actions
{
    public class DotnetCleanAction : Entities.Action
    {
        public DotnetCleanAction() : base()
        {
            Command = "npm run copy files";
        }

        public override void ConnectToPhase()
        {
            Phase = new UtilityPhase();
        }

        public override void Execute()
        {
            Logger.DisplayCustomAlert(nameof(DotnetCleanAction), nameof(Execute), $"Execute {Command}!");
            Logger.DisplayCustomAlert(nameof(DotnetCleanAction), nameof(Execute), $"Successfully executed {Command} without any errors!");
        }

        public override string Print()
        {
            return $"{nameof(DotnetCleanAction)} {Command}";
        }
    }
}
