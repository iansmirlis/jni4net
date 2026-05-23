# Hello World From Java

This sample loads .NET 10 from a JVM through the native CoreCLR launcher. Build
and stage repository outputs first by following the root `ReadMe.md`.

From the sample directory on Linux:

```bash
javac --release 8 -cp ../../../target/test-stage/jni4net.j-0.8.9.0.jar \
  -d target/classes java/Program.java
java -cp ../../../target/test-stage/jni4net.j-0.8.9.0.jar:target/classes Program
```

From PowerShell in the sample directory on Windows:

```powershell
javac --release 8 -cp ../../../target/test-stage/jni4net.j-0.8.9.0.jar -d target/classes java/Program.java
java -cp "../../../target/test-stage/jni4net.j-0.8.9.0.jar;target/classes" Program
```

Because `jni4net.j-0.8.9.0.jar`, the native launcher and
`jni4net.n.runtimeconfig.json` are together in `target/test-stage`,
`Bridge.init()` discovers the platform launcher automatically. The sample
prints `Hello .NET world!` followed by managed environment information.
