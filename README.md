# BasicDataStructures

## What is this project?

This project is a Summer learning and time passing experience for me. I recently took a class in University on Data Structures, Abstraction and Object Oriented Programming. This class was taught in Java and if you are curious I passed with a B :).

## If the class was taught in Java, why is this project in C#?

I simply prefer C# as a language over Java. Java is a decent language and it is really nice for mobile development (Android). I also know less about C# than I do Java and I am using this project as a learning experience to understand the C# language better.

## Are the Data Structures in this project your own ideas?

No, the Data Structures in this project are not my own ideas. I am getting these Data Structure ideas from the textbook of my University class:

*Data Structures and Abstractions with Java* by *Frank M. Carrano* & *Timothy M. Henry*

[Buy on amazon here!](https://www.amazon.com/Data-Structures-Abstractions-Java-4th/dp/0133744051/ref=sr_1_2?ie=UTF8&qid=1527985860&sr=8-2&keywords=Data+Structures+and+Abstractions+with+java)

The code from in the book is looked at as a reference (**NOT COPIED**) for how these Data Structures in the project should work, but some variable names and pieces of code that only exist in C# syntax are different.

Most of these Data Structures acutally exist already in the C# libraries and are most likely more efficient and should be used above the ones in this project...but in the off-chance you like these Data Structures and the way they are programmed more, then by all means, go ahead and use them.

## To-Do List:

- [x] Stacks
    - [x] Array based Implementation
    - [x] Linked Chain based Implementation
- [x] Queues
    - [x] Array based Implementation (Circular Array)
    - [x] Linked Chain based Implementation (Non-Circular Chain)
- [ ] Lists
- [ ] Iterators
- [ ] Trees
- [ ] AVL Trees
- [ ] Good Comments !!
- [ ] Anything else I decide to add

## How can I use these Data Structures in my project?

**THESE DIRECTIONS ARE FOR VISUAL STUDIO CODE**

Make sure you have the following plugins installed in your VSCode first:
- [C#](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp) : By Microsoft
- [C# Extensions](https://marketplace.visualstudio.com/items?itemName=jchannon.csharpextensions) : By Johannon
- [C# FixFormat](https://marketplace.visualstudio.com/items?itemName=Leopotam.csharpfixformat) : By Leopotam
- [.Net Core Test Explorer](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer) *Optional* : by Jun Han (Helpful if you wish to use the NUnit Testing in this project)

If you are on .Net Core 2.0/2.1 (Linux/Unix) you can `git clone` this project, change directory into the classlibrary, and pack the classlibrary to create a .nupkg file in the *bin/Debug/* directory.

```
git clone https://github.com/KaspireFX/BasicDataStructures.git
```

or from gitlab (**More updated**)

```
git clone https://gitlab.com/Kaspire/BasicDataStructures.git
```

You will also need to do a project restore before you can do anything else.

```
cd BasicDataStructures/
dotnet restore
```

Now you are good to go with creating a nuget package file:

```
cd DataStructures/
dotnet pack
```

copy this .nupkg file into your project's directory (I recommend the /bin/Debug/ directory but it can be anywhere you are comfortable with) and add these lines into your project's .csproj file:

```
<PropertyGroup>
    <RestoreSources>$(RestoreSources);../path/to/.nupkg;https://api.nuget.org/v3/index.json</RestoreSources>
</PropertyGroup>
```
The `<PropertyGroup>` should already exist in your project's .csproj file so all you need to do is add the `<RestoreSources>` part.

Then, all you need to do is run a dotnet add command and let it add the .nupkg file to your .csproj file:

```
dotnet add yourproject.csproj basicdatastructures --version #.#.#
```

Replace #.#.# with the current version number. (It is also important that you only use lowercase letters when adding the package).

Just do one more restore command:

```
dotnet restore
```

And you are finished! You should be able to start using the Data Structures in your project! YAY!

Example:
```c#
using System;
using BasicDataStructures.Stacks;
using BasicDataStructures.Queues;

namespace Example {

    public class Example {

        private static ArrayStack<string> Stack = new ArrayStack<string>(5);
        private static LinkedQueue<int> Queue = new LinkedQueue<int>();

        public static void Main(String[] args) {
            Stack.Push("Bob");
            Queue.Enqueue(1);

            Console.WriteLine("Stack Top: {0}", Stack.Peek());
            Console.WriteLine("Front: {0}", Queue.GetFront());
        }
    }
}
```
