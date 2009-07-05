// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by jni4net. See http://jni4net.sourceforge.net/ 
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

package system;

@net.sf.jni4net.attributes.ClrType
public abstract class Console extends system.Object {
    
    //<generated-proxy>
    private static system.Type staticType;
    
    protected Console(net.sf.jni4net.inj.INJEnv env, int handle) {
            super(env, handle);
    }
    
    protected Console() {
            super(((net.sf.jni4net.inj.INJEnv)(null)), 0);
    }
    
    @net.sf.jni4net.attributes.ClrMethod("()LSystem/IO/TextWriter;")
    public native static system.MarshalByRefObject getError();
    
    @net.sf.jni4net.attributes.ClrMethod("()LSystem/IO/TextReader;")
    public native static system.MarshalByRefObject getIn();
    
    @net.sf.jni4net.attributes.ClrMethod("()LSystem/IO/TextWriter;")
    public native static system.MarshalByRefObject getOut();
    
    @net.sf.jni4net.attributes.ClrMethod("()LSystem/Text/Encoding;")
    public native static system.ICloneable getInputEncoding();
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/Text/Encoding;)V")
    public native static void setInputEncoding(system.ICloneable value);
    
    @net.sf.jni4net.attributes.ClrMethod("()LSystem/Text/Encoding;")
    public native static system.ICloneable getOutputEncoding();
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/Text/Encoding;)V")
    public native static void setOutputEncoding(system.ICloneable value);
    
    @net.sf.jni4net.attributes.ClrMethod("()V")
    public native static void Beep();
    
    @net.sf.jni4net.attributes.ClrMethod("(II)V")
    public native static void Beep(int frequency, int duration);
    
    @net.sf.jni4net.attributes.ClrMethod("()V")
    public native static void Clear();
    
    @net.sf.jni4net.attributes.ClrMethod("()LSystem/ConsoleColor;")
    public native static system.Enum getBackgroundColor();
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/ConsoleColor;)V")
    public native static void setBackgroundColor(system.Enum value);
    
    @net.sf.jni4net.attributes.ClrMethod("()LSystem/ConsoleColor;")
    public native static system.Enum getForegroundColor();
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/ConsoleColor;)V")
    public native static void setForegroundColor(system.Enum value);
    
    @net.sf.jni4net.attributes.ClrMethod("()V")
    public native static void ResetColor();
    
    @net.sf.jni4net.attributes.ClrMethod("(IIIIII)V")
    public native static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop);
    
    @net.sf.jni4net.attributes.ClrMethod("(IIIIIICLSystem/ConsoleColor;LSystem/ConsoleColor;)V")
    public native static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, system.Enum sourceForeColor, system.Enum sourceBackColor);
    
    @net.sf.jni4net.attributes.ClrMethod("()I")
    public native static int getBufferHeight();
    
    @net.sf.jni4net.attributes.ClrMethod("(I)V")
    public native static void setBufferHeight(int value);
    
    @net.sf.jni4net.attributes.ClrMethod("()I")
    public native static int getBufferWidth();
    
    @net.sf.jni4net.attributes.ClrMethod("(I)V")
    public native static void setBufferWidth(int value);
    
    @net.sf.jni4net.attributes.ClrMethod("(II)V")
    public native static void SetBufferSize(int width, int height);
    
    @net.sf.jni4net.attributes.ClrMethod("()I")
    public native static int getWindowHeight();
    
    @net.sf.jni4net.attributes.ClrMethod("(I)V")
    public native static void setWindowHeight(int value);
    
    @net.sf.jni4net.attributes.ClrMethod("()I")
    public native static int getWindowWidth();
    
    @net.sf.jni4net.attributes.ClrMethod("(I)V")
    public native static void setWindowWidth(int value);
    
    @net.sf.jni4net.attributes.ClrMethod("(II)V")
    public native static void SetWindowSize(int width, int height);
    
    @net.sf.jni4net.attributes.ClrMethod("()I")
    public native static int getLargestWindowWidth();
    
    @net.sf.jni4net.attributes.ClrMethod("()I")
    public native static int getLargestWindowHeight();
    
    @net.sf.jni4net.attributes.ClrMethod("()I")
    public native static int getWindowLeft();
    
    @net.sf.jni4net.attributes.ClrMethod("(I)V")
    public native static void setWindowLeft(int value);
    
    @net.sf.jni4net.attributes.ClrMethod("()I")
    public native static int getWindowTop();
    
    @net.sf.jni4net.attributes.ClrMethod("(I)V")
    public native static void setWindowTop(int value);
    
    @net.sf.jni4net.attributes.ClrMethod("(II)V")
    public native static void SetWindowPosition(int left, int top);
    
    @net.sf.jni4net.attributes.ClrMethod("()I")
    public native static int getCursorLeft();
    
    @net.sf.jni4net.attributes.ClrMethod("(I)V")
    public native static void setCursorLeft(int value);
    
    @net.sf.jni4net.attributes.ClrMethod("()I")
    public native static int getCursorTop();
    
    @net.sf.jni4net.attributes.ClrMethod("(I)V")
    public native static void setCursorTop(int value);
    
    @net.sf.jni4net.attributes.ClrMethod("(II)V")
    public native static void SetCursorPosition(int left, int top);
    
    @net.sf.jni4net.attributes.ClrMethod("()I")
    public native static int getCursorSize();
    
    @net.sf.jni4net.attributes.ClrMethod("(I)V")
    public native static void setCursorSize(int value);
    
    @net.sf.jni4net.attributes.ClrMethod("()Z")
    public native static boolean getCursorVisible();
    
    @net.sf.jni4net.attributes.ClrMethod("(Z)V")
    public native static void setCursorVisible(boolean value);
    
    @net.sf.jni4net.attributes.ClrMethod("()LSystem/String;")
    public native static java.lang.String getTitle();
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/String;)V")
    public native static void setTitle(java.lang.String value);
    
    @net.sf.jni4net.attributes.ClrMethod("()LSystem/ConsoleKeyInfo;")
    public native static system.ValueType ReadKey();
    
    @net.sf.jni4net.attributes.ClrMethod("(Z)LSystem/ConsoleKeyInfo;")
    public native static system.ValueType ReadKey(boolean intercept);
    
    @net.sf.jni4net.attributes.ClrMethod("()Z")
    public native static boolean getKeyAvailable();
    
    @net.sf.jni4net.attributes.ClrMethod("()Z")
    public native static boolean getNumberLock();
    
    @net.sf.jni4net.attributes.ClrMethod("()Z")
    public native static boolean getCapsLock();
    
    @net.sf.jni4net.attributes.ClrMethod("()Z")
    public native static boolean getTreatControlCAsInput();
    
    @net.sf.jni4net.attributes.ClrMethod("(Z)V")
    public native static void setTreatControlCAsInput(boolean value);
    
    @net.sf.jni4net.attributes.ClrMethod("()LSystem/IO/Stream;")
    public native static system.io.Stream OpenStandardError();
    
    @net.sf.jni4net.attributes.ClrMethod("(I)LSystem/IO/Stream;")
    public native static system.io.Stream OpenStandardError(int bufferSize);
    
    @net.sf.jni4net.attributes.ClrMethod("()LSystem/IO/Stream;")
    public native static system.io.Stream OpenStandardInput();
    
    @net.sf.jni4net.attributes.ClrMethod("(I)LSystem/IO/Stream;")
    public native static system.io.Stream OpenStandardInput(int bufferSize);
    
    @net.sf.jni4net.attributes.ClrMethod("()LSystem/IO/Stream;")
    public native static system.io.Stream OpenStandardOutput();
    
    @net.sf.jni4net.attributes.ClrMethod("(I)LSystem/IO/Stream;")
    public native static system.io.Stream OpenStandardOutput(int bufferSize);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/IO/TextReader;)V")
    public native static void SetIn(system.MarshalByRefObject newIn);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/IO/TextWriter;)V")
    public native static void SetOut(system.MarshalByRefObject newOut);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/IO/TextWriter;)V")
    public native static void SetError(system.MarshalByRefObject newError);
    
    @net.sf.jni4net.attributes.ClrMethod("()I")
    public native static int Read();
    
    @net.sf.jni4net.attributes.ClrMethod("()LSystem/String;")
    public native static java.lang.String ReadLine();
    
    @net.sf.jni4net.attributes.ClrMethod("()V")
    public native static void WriteLine();
    
    @net.sf.jni4net.attributes.ClrMethod("(Z)V")
    public native static void WriteLine(boolean value);
    
    @net.sf.jni4net.attributes.ClrMethod("(C)V")
    public native static void WriteLine(char value);
    
    @net.sf.jni4net.attributes.ClrMethod("([C)V")
    public native static void WriteLine(char[] buffer);
    
    @net.sf.jni4net.attributes.ClrMethod("([CII)V")
    public native static void WriteLine(char[] buffer, int index, int count);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/Decimal;)V")
    public native static void WriteLine(system.Decimal value);
    
    @net.sf.jni4net.attributes.ClrMethod("(D)V")
    public native static void WriteLine(double value);
    
    @net.sf.jni4net.attributes.ClrMethod("(F)V")
    public native static void WriteLine(float value);
    
    @net.sf.jni4net.attributes.ClrMethod("(I)V")
    public native static void WriteLine(int value);
    
    @net.sf.jni4net.attributes.ClrMethod("(J)V")
    public native static void WriteLine(long value);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/Object;)V")
    public native static void WriteLine(system.Object value);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/String;)V")
    public native static void WriteLine(java.lang.String value);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/String;LSystem/Object;)V")
    public native static void WriteLine(java.lang.String format, system.Object arg0);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/String;LSystem/Object;LSystem/Object;)V")
    public native static void WriteLine(java.lang.String format, system.Object arg0, system.Object arg1);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/String;LSystem/Object;LSystem/Object;LSystem/Object;)V")
    public native static void WriteLine(java.lang.String format, system.Object arg0, system.Object arg1, system.Object arg2);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/String;LSystem/Object;LSystem/Object;LSystem/Object;LSystem/Object;)V")
    public native static void WriteLine(java.lang.String format, system.Object arg0, system.Object arg1, system.Object arg2, system.Object arg3);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/String;[LSystem/Object;)V")
    public native static void WriteLine(java.lang.String format, system.Object[] arg);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/String;LSystem/Object;)V")
    public native static void Write(java.lang.String format, system.Object arg0);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/String;LSystem/Object;LSystem/Object;)V")
    public native static void Write(java.lang.String format, system.Object arg0, system.Object arg1);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/String;LSystem/Object;LSystem/Object;LSystem/Object;)V")
    public native static void Write(java.lang.String format, system.Object arg0, system.Object arg1, system.Object arg2);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/String;LSystem/Object;LSystem/Object;LSystem/Object;LSystem/Object;)V")
    public native static void Write(java.lang.String format, system.Object arg0, system.Object arg1, system.Object arg2, system.Object arg3);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/String;[LSystem/Object;)V")
    public native static void Write(java.lang.String format, system.Object[] arg);
    
    @net.sf.jni4net.attributes.ClrMethod("(Z)V")
    public native static void Write(boolean value);
    
    @net.sf.jni4net.attributes.ClrMethod("(C)V")
    public native static void Write(char value);
    
    @net.sf.jni4net.attributes.ClrMethod("([C)V")
    public native static void Write(char[] buffer);
    
    @net.sf.jni4net.attributes.ClrMethod("([CII)V")
    public native static void Write(char[] buffer, int index, int count);
    
    @net.sf.jni4net.attributes.ClrMethod("(D)V")
    public native static void Write(double value);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/Decimal;)V")
    public native static void Write(system.Decimal value);
    
    @net.sf.jni4net.attributes.ClrMethod("(F)V")
    public native static void Write(float value);
    
    @net.sf.jni4net.attributes.ClrMethod("(I)V")
    public native static void Write(int value);
    
    @net.sf.jni4net.attributes.ClrMethod("(J)V")
    public native static void Write(long value);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/Object;)V")
    public native static void Write(system.Object value);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/String;)V")
    public native static void Write(java.lang.String value);
    
    public static system.Type typeof() {
        return system.Console.staticType;
    }
    
    private static void InitJNI(net.sf.jni4net.inj.INJEnv env, system.Type staticType) {
        system.Console.staticType = staticType;
    }
    //</generated-proxy>
}