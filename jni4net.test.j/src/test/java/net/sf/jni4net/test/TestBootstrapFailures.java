package net.sf.jni4net.test;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardCopyOption;

import org.junit.Assert;
import org.junit.Test;

public class TestBootstrapFailures {
    private static final String VERSION = "0.8.9.0";

    @Test
    public void reportsMissingNativeLauncher() throws Exception {
        Path directory = Files.createTempDirectory("jni4net-missing-launcher-");
        try {
            Result result = launch(directory);
            Assert.assertTrue("Expected bootstrap to fail", result.exitCode != 0);
            Assert.assertTrue(result.output.contains(System.mapLibraryName("jni4net.coreclr")));
        } finally {
            Files.deleteIfExists(directory);
        }
    }

    @Test
    public void reportsMissingRuntimeConfiguration() throws Exception {
        Path directory = Files.createTempDirectory("jni4net-missing-config-");
        try {
            Files.copy(
                stageDirectory().resolve(System.mapLibraryName("jni4net.coreclr")),
                directory.resolve(System.mapLibraryName("jni4net.coreclr")),
                StandardCopyOption.REPLACE_EXISTING);

            Result result = launch(directory);
            Assert.assertTrue("Expected bootstrap to fail", result.exitCode != 0);
            Assert.assertTrue(result.output.contains("missing runtime configuration:"));
            Assert.assertTrue(result.output.contains("jni4net.n.runtimeconfig.json"));
        } finally {
            Files.deleteIfExists(directory.resolve(System.mapLibraryName("jni4net.coreclr")));
            Files.deleteIfExists(directory);
        }
    }

    private static Result launch(Path directory) throws IOException, InterruptedException {
        Path stage = stageDirectory();
        String classPath = stage.resolve("jni4net.j-" + VERSION + ".jar")
            + File.pathSeparator
            + stage.resolve("jni4net.test.j.classes");
        String executable = new File(
            new File(System.getProperty("java.home"), "bin"),
            System.getProperty("os.name").startsWith("Windows") ? "java.exe" : "java").getAbsolutePath();

        Process process = new ProcessBuilder(
            executable,
            "-cp",
            classPath,
            BootstrapProbe.class.getName(),
            directory.toAbsolutePath().toString())
            .redirectErrorStream(true)
            .start();
        StringBuilder output = new StringBuilder();
        BufferedReader reader = new BufferedReader(
            new InputStreamReader(process.getInputStream(), StandardCharsets.UTF_8));
        String line;
        while ((line = reader.readLine()) != null) {
            output.append(line).append('\n');
        }
        int exitCode = process.waitFor();
        return new Result(exitCode, output.toString());
    }

    private static Path stageDirectory() throws IOException {
        return new File(System.getProperty("jni4net.test.stage", "../target/test-stage"))
            .getCanonicalFile()
            .toPath();
    }

    private static final class Result {
        private final int exitCode;
        private final String output;

        private Result(int exitCode, String output) {
            this.exitCode = exitCode;
            this.output = output;
        }
    }
}
