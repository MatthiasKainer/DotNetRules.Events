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
        public BaseUserEvent(string application, string user)
            : base(application, user)
        {
        }

        public virtual void ApplyTo(User user)
        {
        }
    }

The ApplyTo will be used by each Event to apply the changes related to the Event. The user will be able to replay all events in order:

    using System.Linq;

    public class User
    {
        public string Name { get; set; }

        public void ApplyAll(params BaseUserEvent[] events)
        {
            events.ToList().ForEach(_ => _.ApplyTo(this));
        }
    }
    
Now we create our first event - the user joined! Our event looks like the following: 

    public class UserJoined : BaseUserEvent
    {
        public UserJoined(string application, string user)
            : base(application, user)
        {
        }

        public override void ApplyTo(User user)
        {
            user.Name = this.User;
        }
    }
    
As we created the event we can now create a method in our user service to publish the event: 

    public void Join(string application, string user)
    {
        new UserJoined(application, user).Publish();
    }

Now the event is published, but nobody is handling it (yet). This project comes with an interface that allows you to store the events where you like. The following snippet writes the event to the MongoDb implementation DotNetRules.Events.Data.MongoDb:

    using DotNetRules.Runtime;

    using DotNetRules.Events.Data.MongoDb;

    [Policy(typeof(UserJoined))]
    public class WhenUserJoined : PolicyBase<UserJoined>
    {
        Then add_to_event_store = () => new EventStore().AddToStore(Subject);
    }
    
