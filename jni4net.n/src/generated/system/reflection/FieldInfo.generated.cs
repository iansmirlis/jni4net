//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by jni4net. See http://jni4net.sourceforge.net/ 
//     Runtime Version:2.0.50727.5446
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace System.Reflection {
    
    
    #region Component Designer generated code 
    public partial class FieldInfo_ {
        
        public static global::java.lang.Class _class {
            get {
                return global::System.Reflection.@__FieldInfo.staticClass;
            }
        }
    }
    #endregion
    
    #region Component Designer generated code 
    [global::net.sf.jni4net.attributes.JavaProxyAttribute(typeof(global::System.Reflection.FieldInfo), typeof(global::System.Reflection.FieldInfo_))]
    [global::net.sf.jni4net.attributes.ClrWrapperAttribute(typeof(global::System.Reflection.FieldInfo), typeof(global::System.Reflection.FieldInfo_))]
    internal sealed partial class @__FieldInfo : global::java.lang.Object {
        
        internal new static global::java.lang.Class staticClass;
        
        private @__FieldInfo(global::net.sf.jni4net.jni.JNIEnv @__env) : 
                base(@__env) {
        }
        
        private static void InitJNI(global::net.sf.jni4net.jni.JNIEnv @__env, java.lang.Class @__class) {
            global::System.Reflection.@__FieldInfo.staticClass = @__class;
        }
        
        private static global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod> @__Init(global::net.sf.jni4net.jni.JNIEnv @__env, global::java.lang.Class @__class) {
            global::System.Type @__type = typeof(__FieldInfo);
            global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod> methods = new global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod>();
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getFieldType", "FieldType0", "()Lsystem/Type;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "GetValue", "GetValue1", "(Lsystem/Object;)Lsystem/Object;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "SetValue", "SetValue2", "(Lsystem/Object;Lsystem/Object;Lsystem/reflection/BindingFlags;Lsystem/Object;Lsy" +
                        "stem/Object;)V"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getFieldHandle", "FieldHandle3", "()Lsystem/ValueType;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getAttributes", "Attributes4", "()Lsystem/Enum;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "SetValue", "SetValue5", "(Lsystem/Object;Lsystem/Object;)V"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "isPublic", "IsPublic6", "()Z"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "isPrivate", "IsPrivate7", "()Z"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "isFamily", "IsFamily8", "()Z"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "isAssembly", "IsAssembly9", "()Z"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "isFamilyAndAssembly", "IsFamilyAndAssembly10", "()Z"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "isFamilyOrAssembly", "IsFamilyOrAssembly11", "()Z"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "isStatic", "IsStatic12", "()Z"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "isInitOnly", "IsInitOnly13", "()Z"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "isLiteral", "IsLiteral14", "()Z"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "isNotSerialized", "IsNotSerialized15", "()Z"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "isSpecialName", "IsSpecialName16", "()Z"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "isPinvokeImpl", "IsPinvokeImpl17", "()Z"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "GetFieldFromHandle", "GetFieldFromHandle18", "(Lsystem/ValueType;)Lsystem/reflection/FieldInfo;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "GetFieldFromHandle", "GetFieldFromHandle19", "(Lsystem/ValueType;Lsystem/ValueType;)Lsystem/reflection/FieldInfo;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "GetRequiredCustomModifiers", "GetRequiredCustomModifiers20", "()[Lsystem/Type;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "GetOptionalCustomModifiers", "GetOptionalCustomModifiers21", "()[Lsystem/Type;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "GetRawConstantValue", "GetRawConstantValue22", "()Lsystem/Object;"));
            return methods;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle FieldType0(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Lsystem/Type;
            // ()LSystem/Type;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2Jp<global::System.Type>(@__env, ((global::System.Reflection.FieldInfo)(@__real)).FieldType);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle GetValue1(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle obj) {
            // (Lsystem/Object;)Lsystem/Object;
            // (LSystem/Object;)LSystem/Object;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.FullC2J<object>(@__env, ((global::System.Reflection.FieldInfo)(@__real)).GetValue(global::net.sf.jni4net.utils.Convertor.FullJ2C<object>(@__env, obj)));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static void SetValue2(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle obj, global::net.sf.jni4net.utils.JniLocalHandle value, global::net.sf.jni4net.utils.JniLocalHandle invokeAttr, global::net.sf.jni4net.utils.JniLocalHandle binder, global::net.sf.jni4net.utils.JniLocalHandle culture) {
            // (Lsystem/Object;Lsystem/Object;Lsystem/reflection/BindingFlags;Lsystem/Object;Lsystem/Object;)V
            // (LSystem/Object;LSystem/Object;LSystem/Reflection/BindingFlags;LSystem/Reflection/Binder;LSystem/Globalization/CultureInfo;)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            ((global::System.Reflection.FieldInfo)(@__real)).SetValue(global::net.sf.jni4net.utils.Convertor.FullJ2C<object>(@__env, obj), global::net.sf.jni4net.utils.Convertor.FullJ2C<object>(@__env, value), global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.BindingFlags>(@__env, invokeAttr), global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.Binder>(@__env, binder), global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Globalization.CultureInfo>(@__env, culture));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        private static global::net.sf.jni4net.utils.JniHandle FieldHandle3(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Lsystem/ValueType;
            // ()LSystem/RuntimeFieldHandle;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2Jp<global::System.RuntimeFieldHandle>(@__env, ((global::System.Reflection.FieldInfo)(@__real)).FieldHandle);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle Attributes4(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Lsystem/Enum;
            // ()LSystem/Reflection/FieldAttributes;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2Jp<global::System.Reflection.FieldAttributes>(@__env, ((global::System.Reflection.FieldInfo)(@__real)).Attributes);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static void SetValue5(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle obj, global::net.sf.jni4net.utils.JniLocalHandle value) {
            // (Lsystem/Object;Lsystem/Object;)V
            // (LSystem/Object;LSystem/Object;)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            ((global::System.Reflection.FieldInfo)(@__real)).SetValue(global::net.sf.jni4net.utils.Convertor.FullJ2C<object>(@__env, obj), global::net.sf.jni4net.utils.Convertor.FullJ2C<object>(@__env, value));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        private static bool IsPublic6(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Z
            // ()Z
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            bool @__return = default(bool);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = ((bool)(((global::System.Reflection.FieldInfo)(@__real)).IsPublic));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static bool IsPrivate7(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Z
            // ()Z
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            bool @__return = default(bool);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = ((bool)(((global::System.Reflection.FieldInfo)(@__real)).IsPrivate));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static bool IsFamily8(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Z
            // ()Z
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            bool @__return = default(bool);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = ((bool)(((global::System.Reflection.FieldInfo)(@__real)).IsFamily));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static bool IsAssembly9(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Z
            // ()Z
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            bool @__return = default(bool);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = ((bool)(((global::System.Reflection.FieldInfo)(@__real)).IsAssembly));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static bool IsFamilyAndAssembly10(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Z
            // ()Z
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            bool @__return = default(bool);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = ((bool)(((global::System.Reflection.FieldInfo)(@__real)).IsFamilyAndAssembly));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static bool IsFamilyOrAssembly11(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Z
            // ()Z
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            bool @__return = default(bool);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = ((bool)(((global::System.Reflection.FieldInfo)(@__real)).IsFamilyOrAssembly));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static bool IsStatic12(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Z
            // ()Z
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            bool @__return = default(bool);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = ((bool)(((global::System.Reflection.FieldInfo)(@__real)).IsStatic));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static bool IsInitOnly13(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Z
            // ()Z
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            bool @__return = default(bool);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = ((bool)(((global::System.Reflection.FieldInfo)(@__real)).IsInitOnly));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static bool IsLiteral14(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Z
            // ()Z
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            bool @__return = default(bool);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = ((bool)(((global::System.Reflection.FieldInfo)(@__real)).IsLiteral));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static bool IsNotSerialized15(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Z
            // ()Z
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            bool @__return = default(bool);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = ((bool)(((global::System.Reflection.FieldInfo)(@__real)).IsNotSerialized));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static bool IsSpecialName16(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Z
            // ()Z
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            bool @__return = default(bool);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = ((bool)(((global::System.Reflection.FieldInfo)(@__real)).IsSpecialName));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static bool IsPinvokeImpl17(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Z
            // ()Z
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            bool @__return = default(bool);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = ((bool)(((global::System.Reflection.FieldInfo)(@__real)).IsPinvokeImpl));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle GetFieldFromHandle18(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__class, global::net.sf.jni4net.utils.JniLocalHandle handle) {
            // (Lsystem/ValueType;)Lsystem/reflection/FieldInfo;
            // (LSystem/RuntimeFieldHandle;)LSystem/Reflection/FieldInfo;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2Jp<global::System.Reflection.FieldInfo>(@__env, global::System.Reflection.FieldInfo.GetFieldFromHandle(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.RuntimeFieldHandle>(@__env, handle)));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle GetFieldFromHandle19(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__class, global::net.sf.jni4net.utils.JniLocalHandle handle, global::net.sf.jni4net.utils.JniLocalHandle declaringType) {
            // (Lsystem/ValueType;Lsystem/ValueType;)Lsystem/reflection/FieldInfo;
            // (LSystem/RuntimeFieldHandle;LSystem/RuntimeTypeHandle;)LSystem/Reflection/FieldInfo;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2Jp<global::System.Reflection.FieldInfo>(@__env, global::System.Reflection.FieldInfo.GetFieldFromHandle(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.RuntimeFieldHandle>(@__env, handle), global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.RuntimeTypeHandle>(@__env, declaringType)));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle GetRequiredCustomModifiers20(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()[Lsystem/Type;
            // ()[LSystem/Type;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.ArrayStrongC2Jp<System.Type[], global::System.Type>(@__env, @__real.GetRequiredCustomModifiers());
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle GetOptionalCustomModifiers21(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()[Lsystem/Type;
            // ()[LSystem/Type;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.ArrayStrongC2Jp<System.Type[], global::System.Type>(@__env, @__real.GetOptionalCustomModifiers());
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle GetRawConstantValue22(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Lsystem/Object;
            // ()LSystem/Object;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::System.Reflection.FieldInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.FieldInfo>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.FullC2J<object>(@__env, @__real.GetRawConstantValue());
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        new internal sealed class ContructionHelper : global::net.sf.jni4net.utils.IConstructionHelper {
            
            public global::net.sf.jni4net.jni.IJvmProxy CreateProxy(global::net.sf.jni4net.jni.JNIEnv @__env) {
                return new global::System.Reflection.@__FieldInfo(@__env);
            }
        }
    }
    #endregion
}
