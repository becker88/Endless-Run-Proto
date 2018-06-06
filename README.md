# Endless Run Prototype
A Prototype of Endless Run Game with AMVCC Pattern

#Unity with MVC: How to Level Up Your Game Development
First time programmers usually start learning the trade with the classic Hello World program. From there, bigger and bigger assignments are bound to follow. Each new challenge drives home an important lesson:

The bigger the project, the bigger the spaghetti.

Soon, it is easy to see that in large or small teams, one cannot recklessly do as one pleases. Code must be maintained and may last for a long time. Companies you’ve worked for can’t just look up your contact information and ask you every time they want to fix or improve the codebase (and you don’t want them to either).

This is why software design patterns exist; they impose simple rules to dictate the overall structure of a software project. They help one or more programmers separate core pieces of a large project and organize them in a standardized way, eliminating confusion when some unfamiliar part of the codebase is encountered.

These rules, when followed by everyone, allow legacy code to be better maintained and navigated, and new code to be added more swiftly. Less time is spent planning the methodology of development. Since problems don’t come in one flavor, there isn’t a silver bullet design pattern. One must carefully consider the strong and weak points of each pattern, and find the best fit for the challenge at hand.

In this tutorial I’ll relate my experience with the popular Unity game development platform and the Model-View-Controller (MVC) pattern for game development. In my seven years of development, having wrestled with my fair share of game dev spaghetti, I’ve been achieving great code structure and development speed using this design pattern.

I’ll start by explaining a bit of Unity’s base architecture, the Entity-Component pattern. Then I’ll move on to explain how MVC fits on top of it, and use a little mock project as example.

#Motivation

In the literature of software we will find a great number of design patterns. Even though they have a set of rules, developers will usually do a little rule-bending in order to better adapt the pattern to their specific problem.

This “freedom of programming” is proof that we haven’t yet found a single, definitive method for designing software. Thus, this article isn’t meant to be the ultimate solution for your problem, but rather, to show the benefits and possibilities of two well known patterns: Entity-Component and Model-View-Controller.

#The Entity-Component Pattern

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
