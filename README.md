DotNetRules.Events
==================

A lightweight EventSourcing library on top of DotNetRules

## About

This library is the minimalset for an eventsourcing framework for DotNetRules. It consists of only two (relevant) objects: 

* Event: The core event class. This is representing the schema of the file that is stored in the database. 
* BaseEvent: The BaseEvent for all the events you want to publish

## Usage

More often you are publishing events in a bounded context. It's a good practice to create a base event class for your entity. Let's consider an entity "User". Our base class would look like the following: 

    using DotNetRules.Events;

    public class BaseUserEvent : BaseEvent
    {
        public BaseUserEvent(string guild, string user)
            : base(guild, user)
        {
        }

        public virtual void ApplyTo(User user)
        {
        }
    }
