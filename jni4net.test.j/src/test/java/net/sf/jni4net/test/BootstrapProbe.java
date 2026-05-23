package net.sf.jni4net.test;

import java.io.File;

import net.sf.jni4net.Bridge;

public final class BootstrapProbe {
    private BootstrapProbe() {
    }

    public static void main(String[] args) throws Exception {
        Bridge.init(new File(args[0]));
    }
}
