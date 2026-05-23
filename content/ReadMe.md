To get started
----------------
Visit and read [jni4net.github.io](http://jni4net.github.io)

Make sure you understand GPLv3 and MIT licenses.
* runtime is licensed under [MIT](http://opensource.org/licenses/MIT).
* proxygen and tools are licensed under [GPLv3](http://opensource.org/licenses/gpl-3.0.html).

Talk back at [jni4net](mailto:jni4net@googlegroups.com) or [Pavel Savara](mailto:pavel.savara@gmail.com)


To use this bridge at runtime you need
----------------
* Windows x64 or Linux x64
* .NET 10 Runtime, or .NET Framework 4.8 on Windows x64 using its compatibility launcher
* JRE 17 or JRE 21
* JAVA_HOME environment set properly,
* On 64bit system: 64bit Java installation, PATH leads to 64bit (server) version
* on console run: `java -version` to check it

How to use
----------------
* Download the release archive for your runtime and platform, or build it from source.
* study samples inside `samples`, read `samples\ReadMe.md` play along.
 * Try `samples\helloWorldFromCLR` there is ReadMe.md inside.
 * Try `samples\helloWorldFromJVM` there is ReadMe.md inside.
* [How calling from Java to .NET works](http://zamboch.blogspot.cz/2009/11/how-calling-from-java-to-net-works-in.html)
* [How calling from .NET to Java works](http://zamboch.blogspot.cz/2009/10/how-calling-from-net-to-java-works.html)
* [Troubleshooter](http://jni4net.sourceforge.net/troubleshoot.shtml)
* [Email group](https://groups.google.com/forum/?hl=en#!forum/jni4net)


To use this jni4net bridge for development you need as well
----------------
* JDK 17 or JDK 21
* .NET 10 SDK
* Maven build tool
* CMake and an x64 C++ compiler for the CoreCLR native launcher
* .NET Framework 4.8 Developer Pack and SDK tools for the optional Windows x64 compatibility launcher
* Eclipse or any other Java IDE

Folder structure of release archives
----------------

The selected runtime archive contains its corresponding files from this list.

```
lib\     - contains .NET DLLs and Java .jar files of jni4net.
           The DLLs and .jar file should reside in same directory
           (as well as rest of your .NET DLLs)
   \jni4net.n.dll                    - .NET 10 side of the bridge
   \jni4net.n.runtimeconfig.json     - .NET 10 runtime configuration
   \System.CodeDom.dll               - .NET 10 bridge dependency
   \jni4net.j-0.x.0.0.jar           - Java side of the bridge
   \jni4net.coreclr.dll              - Native helper for .NET 10 on Windows x64
   \libjni4net.coreclr.so            - Native helper for .NET 10 on Linux x64
   \jni4net.n-0.x.0.0.dll           - .NET Framework 4.8 side, Windows x64 only
   \jni4net.n.w64.v40-0.x.0.0.dll  - .NET Framework 4.8 native helper, Windows x64 only
   \jni4net-MIT.txt                 - License for redistributable runtime files
samples\ - contains sample applications and tutorials, see `ReadMe.md` in there for details
```
