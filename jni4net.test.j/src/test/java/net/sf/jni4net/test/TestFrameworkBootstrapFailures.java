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
import org.junit.Assume;
import org.junit.Before;
import org.junit.Test;

public class TestFrameworkBootstrapFailures {
    private static final String VERSION = "0.8.9.0";
    private static final String LAUNCHER = "jni4net.n.w64.v40-" + VERSION + ".dll";

    @Before
    public void frameworkOnly() {
        Assume.assumeTrue(Boolean.getBoolean("jni4net.test.framework"));
    }

    @Test
    public void reportsMissingFrameworkLauncher() throws Exception {
        Path directory = Files.createTempDirectory("jni4net-framework-missing-launcher-");
        try {
            Result result = launch(directory.resolve(LAUNCHER));
            Assert.assertTrue("Expected bootstrap to fail", result.exitCode != 0);
            Assert.assertTrue(result.output.contains(LAUNCHER));
        } finally {
            Files.deleteIfExists(directory);
        }
    }

    @Test
    public void reportsMissingManagedFrameworkBridge() throws Exception {
        Path directory = Files.createTempDirectory("jni4net-framework-missing-bridge-");
        try {
            Files.copy(
                stageDirectory().resolve(LAUNCHER),
                directory.resolve(LAUNCHER),
                StandardCopyOption.REPLACE_EXISTING);

            Result result = launch(directory.resolve(LAUNCHER));
            Assert.assertTrue("Expected bootstrap to fail", result.exitCode != 0);
            Assert.assertTrue(result.output.contains("missing managed bridge:"));
            Assert.assertTrue(result.output.contains("jni4net.n-" + VERSION + ".dll"));
        } finally {
            Files.deleteIfExists(directory.resolve(LAUNCHER));
            Files.deleteIfExists(directory);
        }
    }

    private static Result launch(Path launcher) throws IOException, InterruptedException {
        Path stage = stageDirectory();
        String classPath = stage.resolve("jni4net.j-" + VERSION + ".jar")
            + File.pathSeparator
            + stage.resolve("jni4net.test.j.classes");
        String executable = new File(
            new File(System.getProperty("java.home"), "bin"),
            "java.exe").getAbsolutePath();

        Process process = new ProcessBuilder(
            executable,
            "-cp",
            classPath,
            BootstrapProbe.class.getName(),
            launcher.toAbsolutePath().toString())
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
        return new File(System.getProperty("jni4net.test.stage", "../target/test-stage-framework"))
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
