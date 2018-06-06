# Endless Run Prototype
A Prototype of Endless Run Game with AMVCC Pattern

# Unity with MVC: How to Level Up Your Game Development)

First time programmers usually start learning the trade with the classic Hello World program. From there, bigger and bigger assignments are bound to follow. Each new challenge drives home an important lesson:

The bigger the project, the bigger the spaghetti.

Soon, it is easy to see that in large or small teams, one cannot recklessly do as one pleases. Code must be maintained and may last for a long time. Companies you’ve worked for can’t just look up your contact information and ask you every time they want to fix or improve the codebase (and you don’t want them to either).

This is why software design patterns exist; they impose simple rules to dictate the overall structure of a software project. They help one or more programmers separate core pieces of a large project and organize them in a standardized way, eliminating confusion when some unfamiliar part of the codebase is encountered.

These rules, when followed by everyone, allow legacy code to be better maintained and navigated, and new code to be added more swiftly. Less time is spent planning the methodology of development. Since problems don’t come in one flavor, there isn’t a silver bullet design pattern. One must carefully consider the strong and weak points of each pattern, and find the best fit for the challenge at hand.

In this tutorial I’ll relate my experience with the popular Unity game development platform and the Model-View-Controller (MVC) pattern for game development. In my seven years of development, having wrestled with my fair share of game dev spaghetti, I’ve been achieving great code structure and development speed using this design pattern.

I’ll start by explaining a bit of Unity’s base architecture, the Entity-Component pattern. Then I’ll move on to explain how MVC fits on top of it, and use a little mock project as example.

# Motivation

In the literature of software we will find a great number of design patterns. Even though they have a set of rules, developers will usually do a little rule-bending in order to better adapt the pattern to their specific problem.

This “freedom of programming” is proof that we haven’t yet found a single, definitive method for designing software. Thus, this article isn’t meant to be the ultimate solution for your problem, but rather, to show the benefits and possibilities of two well known patterns: Entity-Component and Model-View-Controller.

# The Entity-Component Pattern

Entity-Component (EC) is a design pattern where we first define the hierarchy of elements that make up the application (Entities), and later, we define the features and data each will contain (Components). In more “programmer” terms, an Entity can be an object with an array of 0 or more Components. Let’s depict an Entity like this:

some-entity [component0, component1, ...]

Here’s a simple example of an EC tree.

- app [Application]
   - game [Game]
      - player [KeyboardInput, Renderer]
      - enemies
         - spider [SpiderAI, Renderer]
         - ogre [OgreAI, Renderer]
      - ui [UI]
         - hud [HUD, MouseInput, Renderer]
         - pause-menu [PauseMenu, MouseInput, Renderer]
         - victory-modal [VictoryModal, MouseInput, Renderer]
         - defeat-modal [DefeatModal, MouseInput, Renderer]

EC is a good pattern for alleviating the problems of multiple inheritance, where a complex class structure can introduce problems like the diamond problem where a class D, inheriting two classes, B and C, with the same base class A, can introduce conflicts because how B and C modify A’s features differently.

EC is a good pattern for alleviating the problems of multiple inheritance, where a complex class structure can introduce problems like the diamond problem where a class D, inheriting two classes, B and C, with the same base class A, can introduce conflicts because how B and C modify A’s features differently.

![alt text](https://uploads.toptal.io/blog/image/91482/toptal-blog-image-1438268683860-d3025ae9dd53822d1a460760d8f07623.jpg)

These kinds of problems can be common in game development where inheritance is often used extensively.

By breaking down the features and data handlers into smaller Components, they can be attached and reused in different Entities without relying on multiple inheritance (which, by the way, isn’t even a feature of C# or Javascript, the main languages used by Unity).

# Where Entity-Component Falls Short

Being one level above OOP, EC helps to defragment and better organize your code architecture. However, in large projects we are still “too free” and we can find ourselves in a “feature ocean”, having a hard time finding the right Entities and Components, or figuring out how they should interact. There are infinite ways to assemble Entities and Components for a given task.

One way to avoid a mess is to impose some additional guidelines on top of Entity-Component. For example, one way I like to think about software is to divide it up into three different categories:

    Some handle the raw data, allowing it to be created, read, updated, deleted or searched (i.e., the CRUD concept).
    Others implement the interface for other elements to interact with, detecting events related to their scope and triggering notifications when they occur.
    Finally, some elements are responsible for receiving these notifications, making business logic decisions, and deciding how the data should be manipulated.

Fortunately, we already have a pattern that behaves in this exact way.

# The Model-View-Controller (MVC) Pattern

The Model-View-Controller pattern (MVC) splits the software into three major components: Models (Data CRUD), Views (Interface/Detection) and Controllers (Decision/Action). MVC is flexible enough to be implemented even on top of ECS or OOP.

Game and UI development have the usual workflow of waiting for a user’s input, or other triggering condition, sending notification of those events somewhere appropriate, deciding what to do in response, and updating the data accordingly. These actions clearly show the compatibility of these applications with MVC.

This methodology introduces another abstraction layer that will help with the software planning, and also allow new programmers to navigate even in a bigger codebase. By splitting the thinking process into data, interface, and decisions, developers can reduce the number of source files that must be searched in order to add or fix functionality.

# Unity and EC

Let’s first take a closer look at what Unity gives us up front.

Unity is an EC-based development platform, where all Entities are instances of GameObject and the features that makes them be “visible,” “moveable,” “interactable,” and so on, are provided by classes extending Component.

The Unity editor’s Hierarchy Panel and Inspector Panel provide a powerful way to assemble your application, attach Components, configure their initial state and bootstrap your game with a lot less source code than it would normally.
Still, as we’ve discussed, we can hit the “too many features” problem and find ourselves in a gigantic hierarchy, with features scattered everywhere, making the life of a developer a lot harder.

# Adapting MVC to a Game Development Environment

Now, I would like to introduce two small modifications to the generic MVC pattern, which help adapt it to unique situations I’ve come across building Unity projects with MVC:


    The MVC class references easily get scattered throughout the code.
        Within Unity, developers typically must drag and drop instances around to make them accessible, or else reach them through cumbersome find statements like GetComponent( ... ).
        Lost-reference hell will ensue if Unity crashes or some bug makes all the dragged references disappear.
        This makes it necessary to have a single root reference object, through which all instances in the Application can be reached and recovered.
    Some elements encapsulate general functionality that should be highly reusable, and which does not naturally fall into one of the three main categories of Model, View, or Controller. These I like to call simply Components. They are also “Components” in the Entity-Component sense, but merely act as helpers in the MVC framework.
        For example, a Rotator Component, which only rotates things by a given angular velocity and doesn’t notify, store, or decide anything.

To help alleviate these two issues, I came up with a modified pattern I call AMVCC, or Application-Model-View-Controller-Component.

![alt text](https://uploads.toptal.io/blog/image/91487/toptal-blog-image-1438268986192-dc455bb88c34cd8c689ae9edb33f5eba.jpg)


    Application - Single entry point to your application and container of all critical instances and application-related data.
    MVC - You should know this by now. :)
    Component - Small, well-contained script that can be reused.

These two modifications have satisfied my needs for all projects I’ve used them in.

Bigger projects will have a lot of notifications. So, to avoid getting a big switch-case structure, it is advisable to create different controllers and make them handle different notification scopes.

# AMVCC in the Real World

This example has shown a simple use case for the AMVCC pattern. Adjusting your way of thinking in terms of the three elements of MVC, and learning to visualize the entities as an ordered hierarchy, are the skills that ought to be polished.

In bigger projects, developers will be faced with more complex scenarios and doubts about whether something should be a View or a Controller, or if a given class should be more thoroughly separated in smaller ones.

# Rules of Thumb (by Eduardo)

There isn’t any “Universal Guide for MVC sorting” anywhere. But there are some simple rules that I typically follow to help me determine whether to define something as a Model, View, or Controller, and also when to split a given class in smaller pieces.

Usually this happens organically while I think about the software architecture or during scripting.

# Class Sorting

# Models

    Hold the application’s core data and state, such as player health or gun ammo.
    Serialize, deserialize, and/or convert between types.
    Load/save data (locally or on the web).
    Notify Controllers of the progress of operations.
    Store the Game State for the Game’s Finite State Machine.
    Never access Views.

# Views

    Can get data from Models in order to represent up-to-date game state to the user. For example, a View method player.Run() can internally use model.speed to manifest the player abilities.
    Should never mutate Models.
    Strictly implements the functionalities of its class. For example:
        A PlayerView should not implement input detection or modify the Game State.
        A View should act as a black box that has an interface, and notifies of important events.
        Does not store core data (like speed, health, lives,…).

# Controllers

    Do not store core data.
    Can sometimes filter notifications from undesired Views.
    Update and use the Model’s data.
    Manages Unity’s scene workflow.
