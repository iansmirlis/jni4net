# Hello World From .NET

This sample starts a JVM from a .NET 10 process and invokes Java library calls.
Build and stage the repository outputs first by following the root
`ReadMe.md`.

From the repository root on Linux:

```bash
dotnet build content/samples/helloWorldFromCLR/helloWorldFromCLR.csproj --configuration Release
cp target/test-stage/jni4net.j-0.8.9.0.jar \
  content/samples/helloWorldFromCLR/bin/Release/net10.0/
JAVA_HOME=/path/to/jdk-17-or-21 \
  dotnet run --project content/samples/helloWorldFromCLR/helloWorldFromCLR.csproj \
  --configuration Release --no-build
```

From PowerShell on Windows:

```powershell
dotnet build content/samples/helloWorldFromCLR/helloWorldFromCLR.csproj --configuration Release
Copy-Item target/test-stage/jni4net.j-0.8.9.0.jar content/samples/helloWorldFromCLR/bin/Release/net10.0/
$env:JAVA_HOME = 'C:\path\to\jdk-17-or-21'
dotnet run --project content/samples/helloWorldFromCLR/helloWorldFromCLR.csproj --configuration Release --no-build
```

The sample adds the staged Java bridge jar to the JVM classpath and prints
`Hello Java world!` followed by Java system properties.
