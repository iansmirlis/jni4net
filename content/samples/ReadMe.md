Overall sample guide
---

In this directory are sample applications which should help you to learn how to
use jni4net. Starters should play with them in following order. Each folder
contains `ReadMe.md` file.

Samples assume that you have the .NET 10 SDK and JDK 17 or JDK 21 installed.

1) helloWorldFromCLR - Easiest way to start using jni4net for .NET people.
   This sample uses jni4net bridge to demostrate calls from C# into Java.
   Uses proxies embedded in jni4net itself, so you don't need to worry about it.

2) helloWorldFromJVM - Easiest way to start using jni4net for Java people.
   This sample uses jni4net bridge to demostrate calls from Java into .NET 10
   through the CoreCLR native launcher.
   Uses proxies embedded in jni4net itself, so you don't need to worry about it.

3) runtimeSelection - historical sample; runtime selection is no longer supported.

4) myCSharpDemoCalc - demonstrates how to wrap your own C# library easily.

5) myJavaDemoCalc - demonstrates how to wrap your own Java library easily.

6) fop - this is bit more complex sample of Java library used by C# program.
   Currently, there is no good xsl:fo library for .NET.
   We demostrate how jni4net could solve such situation.

7) winforms - this example shows, how Java program could create WinForms dialog.

8) interfaceFromCLR - shows how to implement Java interface in CLR and pass it to JVM

9) circular - shows how to incrementaly build classes which use each other

10) drools - quite complex samle showing integration of C# program with drools business rule engine in Java

[Tropublehooting](http://jni4net.sourceforge.net/troubleshoot.shtml)
