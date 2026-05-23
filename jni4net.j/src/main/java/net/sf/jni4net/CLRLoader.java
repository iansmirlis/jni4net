/* Copyright (C) 2009 by Pavel Savara
This file is part of jni4net library - bridge between Java and .NET
http://jni4net.sourceforge.net/

This content is released under the (http://opensource.org/licenses/MIT) MIT License, see license/jni4net-MIT.txt.
*/

package net.sf.jni4net;

import java.io.IOException;
import java.io.InputStream;
import java.io.File;
import java.net.URISyntaxException;
import java.net.URL;
import java.util.Properties;

/**
 * @author Pavel Savara (original)
 */
class CLRLoader {
    private static final String NATIVE_LIBRARY_NAME = "jni4net.coreclr";
	private static String version;

    public static void 	init(File fileOrDirectory) throws IOException {
		if (!Bridge.isRegistered) {
			if (fileOrDirectory.isDirectory()) {
                init(new File(fileOrDirectory, System.mapLibraryName(NATIVE_LIBRARY_NAME)).getAbsoluteFile());
				return;
			}
			try {
                final String file = fileOrDirectory.getPath();
                System.load(file);
				final int res = Bridge.initDotNet();
				if (res != 0) {
					System.err.println("Can't initialize jni4net Bridge from " + file);
					throw new net.sf.jni4net.inj.INJException("Can't initialize jni4net Bridge. Code:"+res);
				}
				Bridge.isRegistered = true;
			} catch (Throwable th) {
				System.err.println("Can't initialize jni4net Bridge" + th.getMessage());
				throw new net.sf.jni4net.inj.INJException("Can't initialize jni4net Bridge", th);
			}
		}
	}

	static File findDefaultDll() throws IOException {
		final java.security.CodeSource source = Bridge.class.getProtectionDomain().getCodeSource();
        final File location;
        try {
            location = new File(source.getLocation().toURI()).getCanonicalFile();
        } catch (URISyntaxException e) {
            throw new IOException(e.getMessage());
        }
        final File directory = location.isDirectory() ? location : location.getParentFile();
        final File path = new File(directory, System.mapLibraryName(NATIVE_LIBRARY_NAME));
        if (!path.exists()) {
            throw new IOException("Can't find " + path + ". Pass the staged native-library directory to Bridge.init(File).");
        }
        return path;
	}

	public static String getProperty(String property) {
		final URL resource = CLRLoader.class.getClassLoader().getResource("META-INF/jni4net.properties");
		if (resource != null) {
			try {
				Properties p = new Properties();
				InputStream ins = resource.openStream();
				p.load(ins);
				ins.close();
				return p.getProperty(property, null);
			}
			catch (IOException ignore) {
			}
		}
		return null;
	}

	public static synchronized String getVersion() {
		if (version == null) {
			version = getProperty("jni4net.version");
		}
		return version;
	}
}
