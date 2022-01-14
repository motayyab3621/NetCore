using System;
using ExtensionMethodsDemo.Extensions;

namespace ExtensionMethodsDemo
{
    /*
        What is an extension method?
        An extension method is a method that extends something. Extension methods are used to chain things together in a way that really makes it readable what's
        happening. You can take a class and you can chain together.
        
        Extension methods makes things easier. Below is the example of it:
        person.Print().LogInfo().SaveToDatabase(myDBConnection);
        
        Without extension method if we have to achieve the above functionality in one line, we have to use the below code:
        SaveToDatabase(LogInfo(Print(person)))
        
        Clearly, extension methods makes it easy to read by having a dot notation where we chain them together it's much less nesting going on.
        
        There are some benefits to extension methods, now lets talk about when we would use extension methods because the answer is not all the time:
        - Extension methods are usually best when you're extending things you don't own. Example is of third party SimpleLogger and we extended it to be better.
        
        - Another one is if you want to bring in a dependency but you don't want that class to depend on it. Example, in our SaveToDatabase() where the person class
          is a simple data class where it has firstName, lastName and a couple of other properties. We don't necessarily want that to depend on the database but we
          could extend it and pass in myDBConnection connection information into SaveToDatabase() and say save the person into this database.
        
        - Another way that this can be beneficial is we can apply these just the same to interfaces. Let's say we extact interface from SimpleLogger class and then
          change the below code
          
        SimpleLogger logger = new SimpleLogger();
        to
        ISimpleLogger logger = new SimpleLogger();
          
        After doing this we will see that our custom extension methods have stopped working therefore we also have to change SimpleLogger to ISimpleLogger in the
        Extension methods.
        
        How does it benefit us?
        - Well now I have not only extended the SimpleLogger class but any other class that also implements the ISimpleLogger. You can actually extend multiple classes
          with just one extension method. You can bring the same functionality to multiple classes that may not have otherwise had it. Instead of modifying multiple
          classes you modify one extension or create one extension and that applies to all of them. So there's lot of benefits here.
        
        WHEN WOULD YOU NOT USE AN EXTENSION METHOD?
        - The first place where we demonstrated adding to the string PrintToConsole(), if you find yourself doing an awful lot of that and you find that really is a
          time saver and it's a cleaner way of doing things maybe, but don't go crazy extending especially the primitive types but really any of the types that
          Microsoft provides because if you do what you're going to find is you have a mess. Because you already have a list to the primitive types in the Intellisense
          and to that list if you add 50 more commands that will become very complicated to navigate. Be careful of that I would limit this to only the absolute
          necessary things for the Microsoft types. When you get into your own types if you find that provides a value to you and you don't want to modify your existing
          class item for example but you want to extend it that's fine but, if you can modify your existing class item and put the functionality in the class that's
          usually cleaner so don't just create an empty class and then extend it like crazy that's not exactly the purpose or design of this but this will provide
          some benefits to expanding the functionality of the class in a way that wasn't originally intended so you can modify that class without modifying the class
          you can leave the class alone and then extend it.
        
        - We can achieve open closed principle through extension methods.
        
        - Three things to achieve Extension methods:
          1. static class
          2. static method
          3. this keyword
    */

    class Program
    {
        static void Main(string[] args)
        {
            string demo = "This is a demo";
            demo.PrintToConsole();

            /*
                How does it knows the name of the PrintToConsole() method that I added?
                Well, demo is a string type we just extended that string type with an additional method. And, you will notice it takes no parameters although
                PrintToConsole() method expects a parameter.
                
                To this, we did pass in a parameter but that parameter is "demo", which is appended before "PrintToConsole" method. So, your extension methods will
                always have one less parameter than you will list in the definition of extension method.
                
                We can also do something like below code and it will also work fine:
                "This is a demo".PrintToConsole();
                
                "PrintToConsole()" is available to us because we are in the same namespace but if we're not in the same namespace, then we have to include that namespace.
                Instead of creating our own namespace we can merge our code in System namespace, but that is not a recommended way of doing it.
            */

            ISimpleLogger logger = new SimpleLogger();
            logger.Log("Test Error", "Error");
            logger.LogError("This is an error");
            logger.LogWarning("This is a warning");
            Console.WriteLine("Goodbye");

            /*
                We have used both of the functions Log and LogError. LogError is an extension method which is our own custom method and this method is giving us more
                functionalit as compared to the Log method which is provided in SimpleLogger class.
            */
        }
    }

    /*
        How to extend a class rather than extending a data type?
        Let's say we get a class SimpleLogger from a third party vendor and it's not great. Below is the definition of SimpleLogger and it's not really great and this
        is a third party vendor we're forced to work with and we're locked into using this product we have to use this product. We have to make sure that our code
        uses standard messaging around it. That is one way of doing it or the other way is we could write an extension method for it.
    */

    public class SimpleLogger : ISimpleLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Log(string message, string messageType)
        {
            Log($"{messageType}: {message}");
        }
    }
}
