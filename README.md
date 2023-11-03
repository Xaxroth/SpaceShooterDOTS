# SpaceShooterDOTS
This is a Space-Shooter Game that I made with Unity's ECS (DOTS). It is my first project with this workflow, and I managed to create a scalable prototype which can handle a large number of instances at once through the data-oriented functionality provided.
I decided to create a system that creates all the desired asteroids pre-emptively, instead of spawning them during runtime. Since arrays and lists aren't supported in Unity DOTS, I figured that this was the best way of "pooling" the asteroids.
I also made use of MonoBehavior for certain functionalities, such as my AsteroidManager which enables the editing of asteroid properties. I also used MonoBehavior-inherited scripts to establish stats and properties for things such as projectiles and asteroids.

Most of my systems utilize Unity's [BurstCompile] attribute, which automatically marks my heavier jobs, such as movement or spawning projectiles, to be handled by the BurstCompiler. This helps by running the jobs in parallel on multiple CPU cores, elleviating
some of the stress that can come with handling large amounts of objects, especially since each asteroid has its own systems and jobs that it executes individually. This significantly improved the performance of my movement jobs that asteroids were performing individually, especially when the entity count started reaching several thousand during my testing. Since the BurstCompiler also optimizes the code for its target platform, it made sense to
BurstCompile virtually everything, especially things that would run constantly like OnUpdate() in my systems.

While Unity's physics system was highlighted as very performant, I did not find success with it, and my FPS would drop several hundred FPS once I started implementing PhysicsBodies and PhysicsShapes. Instead, I went with another approach with compares the
position between all projectiles and asteroids present in the scene, and checking whether or not the projectiles are close enough to the center of an asteroid, which would destroy it. This made my game much more performant, even from the UnityEditor,
although it can be argued that it is more inaccurate and questionable to run such an operation in Update. However, with the optimized Unity.math libraries, my performance did not seem to suffer, despite me checking and comparing a large number of entities in OnUpdate().

Since spawning entities in runtime tanked my performance somewhat, I decided on pooling and re-using all the entities that I initially spawn, which saved me alot of performance spikes when creating/destroying an object.

Not spawning during runtime
![Not spawning](https://github.com/Xaxroth/SpaceShooterDOTS/assets/113028378/4157ad89-6da6-46bd-ac35-68718c5d5d57)

Spawning/destroying during runtime
![spawning](https://github.com/Xaxroth/SpaceShooterDOTS/assets/113028378/ff283b66-7b7b-4f70-abde-743511275959)

By setting an entity's different components through my entity's aspect, I could simply modify the localtransform component of the asteroid, giving the illusion of new asteroids spawning whereas they were just being repositioned when they got hit, their processes/jobs still running as normal.

Included in the "Releases" tab, a standalone .exe can be found through the .zip file.

