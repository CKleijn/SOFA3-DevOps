﻿using Domain.Helpers;
using Domain.Phases;

namespace Domain.Actions
{
    public class NpmEslintAction : Entities.Action
    {
        public NpmEslintAction() : base()
        {
            Command = "npm eslint";
        }

        public override void ConnectToPhase()
        {
            Phase = new AnalysePhase();
        }

        public override void Execute()
        {
            Logger.DisplayCustomAlert(nameof(NpmEslintAction), nameof(Execute), $"Execute {Command}!");
            Logger.DisplayCustomAlert(nameof(NpmEslintAction), nameof(Execute), $"Successfully executed {Command} without any errors!");
        }

        public override string Print()
        {
            return $"{nameof(NpmEslintAction)} {Command}";
        }
    }
}
