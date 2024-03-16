﻿using Domain.Interfaces.States;

namespace Domain.States.Pipeline
{
    public class FailedState : IPipelineState
    {
        private Entities.Pipeline _context { get; init; }
        public Entities.Pipeline Context { get => _context; init => _context = value; }

        public FailedState(Entities.Pipeline context)
        {
            _context = context;
        }

        public void ExecutePipeline() => throw new NotImplementedException();

        public void CancelPipeline() => throw new NotImplementedException();

        public void FailPipeline() => throw new NotImplementedException();

        public void FinalizePipeline() => throw new NotImplementedException();
    }
}
