# This fork is a work in progress

It's intented to be a dotnet core 10 and Java 17/21 compatible version of jni4net, with support for Windows and Linux.
Feel free to play with it, but be aware that it is not yet ready for production use.

To get started
----------------
Visit and read [jni4net.github.io](http://jni4net.github.io)

Make sure you understand GPLv3 and MIT licenses.
* runtime is licensed under [MIT](http://opensource.org/licenses/MIT).
* proxygen and tools are licensed under [GPLv3](http://opensource.org/licenses/gpl-3.0.html).

Talk back at [jni4net](mailto:jni4net@googlegroups.com)

How to use
----------------
* Download a platform release archive produced by GitHub Actions, or build it from source below.
* study samples in `content\samples`, read `ReadMe.md` and play along.
 * Try `content\samples\helloWorldFromCLR` there is ReadMe.md inside.
 * Try `content\samples\helloWorldFromJVM` there is ReadMe.md inside.
* [How calling from Java to .NET works](http://zamboch.blogspot.cz/2009/11/how-calling-from-java-to-net-works-in.html)
* [How calling from .NET to Java works](http://zamboch.blogspot.cz/2009/10/how-calling-from-net-to-java-works.html)
* [Troubleshooter](http://jni4net.com/troubleshoot.html)
* [Email group](https://groups.google.com/forum/?hl=en#!forum/jni4net)

How to build this solution on Windows
----------------
make sure you have
* .NET 10 SDK
* Java JDK 17 or JDK 21
* `JAVA_HOME` set properly
* Maven
* CMake and an x64 C++ compiler
* for .NET Framework 4.8 compatibility, the .NET Framework 4.8 Developer Pack and SDK tools
* internet access to download components from maven repository

In a PowerShell prompt in root directory run:

```
mvn --batch-mode -pl jni4net.j,jni4net.tested.j,jni4net.test.j -am -DskipTests package
dotnet build jni4net.sln --configuration Release
cmake -S jni4net.coreclr -B jni4net.coreclr/target/build -DCMAKE_BUILD_TYPE=Release
cmake --build jni4net.coreclr/target/build --config Release
cmake -DREPO_ROOT="$PWD" -DRUNTIME=coreclr -DPLATFORM=windows-x64 -DNATIVE_LIBRARY="$PWD\jni4net.coreclr\target\build\Release\jni4net.coreclr.dll" -DCONFIGURATION=Release -P eng\package-runtime.cmake
```

For the optional Windows x64 .NET Framework 4.8 launcher run:

```
.\eng\prepare-framework-tools.ps1
dotnet build jni4net.n.w64.v40\src\jni4net.n.w64.v40.csproj --configuration Release
cmake -DREPO_ROOT="$PWD" -DRUNTIME=framework -DPLATFORM=windows-x64 -DFRAMEWORK_LAUNCHER="$PWD\jni4net.n.w64.v40\target\Release\jni4net.n.w64.v40-0.8.9.0.dll" -DCONFIGURATION=Release -P eng\package-runtime.cmake
```

How to use it on Linux:
----------------
Linux x64 is supported with .NET 10, JDK 17 or JDK 21, and the CoreCLR native launcher.
Mono is not supported.
