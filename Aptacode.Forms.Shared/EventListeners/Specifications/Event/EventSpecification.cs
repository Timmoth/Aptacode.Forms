﻿using System;
using System.Linq.Expressions;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.EventListeners.Events;

namespace Aptacode.Forms.Shared.EventListeners.Specifications.Event
{
    public sealed class EventTypeSpecification : Specification<FormElementEvent>
    {
        public EventTypeSpecification(string eventType)
        {
            EventType = eventType;
        }

        public string EventType { get; set; }

        public override Expression<Func<FormElementEvent, bool>> ToExpression() =>
            formEvent => formEvent.EventType == EventType;
    }

    public sealed class EventElementNameSpecification : Specification<FormElementEvent>
    {
        public EventElementNameSpecification(string elementName)
        {
            ElementName = elementName;
        }

        public string ElementName { get; set; }

        public override Expression<Func<FormElementEvent, bool>> ToExpression() =>
            formEvent => formEvent.ElementName == ElementName;
    }
}