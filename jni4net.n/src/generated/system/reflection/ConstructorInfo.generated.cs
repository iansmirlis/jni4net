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
    public partial class ConstructorInfo_ {
        
        public static global::java.lang.Class _class {
            get {
                return global::System.Reflection.@__ConstructorInfo.staticClass;
            }
        }
    }
    #endregion
    
    #region Component Designer generated code 
    [global::net.sf.jni4net.attributes.JavaProxyAttribute(typeof(global::System.Reflection.ConstructorInfo), typeof(global::System.Reflection.ConstructorInfo_))]
    [global::net.sf.jni4net.attributes.ClrWrapperAttribute(typeof(global::System.Reflection.ConstructorInfo), typeof(global::System.Reflection.ConstructorInfo_))]
    internal sealed partial class @__ConstructorInfo : global::java.lang.Object {
        
        internal new static global::java.lang.Class staticClass;
        
        private @__ConstructorInfo(global::net.sf.jni4net.jni.JNIEnv @__env) : 
                base(@__env) {
        }
        
        private static void InitJNI(global::net.sf.jni4net.jni.JNIEnv @__env, java.lang.Class @__class) {
            global::System.Reflection.@__ConstructorInfo.staticClass = @__class;
        }
        
        private static global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod> @__Init(global::net.sf.jni4net.jni.JNIEnv @__env, global::java.lang.Class @__class) {
            global::System.Type @__type = typeof(__ConstructorInfo);
            global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod> methods = new global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod>();
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "Invoke", "Invoke4", "(Lsystem/reflection/BindingFlags;Lsystem/Object;[Lsystem/Object;Lsystem/Object;)L" +
                        "system/Object;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "Invoke", "Invoke5", "([Lsystem/Object;)Lsystem/Object;"));
            return methods;
        }

        private static global::net.sf.jni4net.utils.JniHandle Invoke4(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle invokeAttr, global::net.sf.jni4net.utils.JniLocalHandle binder, global::net.sf.jni4net.utils.JniLocalHandle parameters, global::net.sf.jni4net.utils.JniLocalHandle culture) {
            // (Lsystem/reflection/BindingFlags;Lsystem/Object;[Lsystem/Object;Lsystem/Object;)Lsystem/Object;
            // (LSystem/Reflection/BindingFlags;LSystem/Reflection/Binder;[LSystem/Object;LSystem/Globalization/CultureInfo;)LSystem/Object;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::System.Reflection.ConstructorInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.ConstructorInfo>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.FullC2J<object>(@__env, @__real.Invoke(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.BindingFlags>(@__env, invokeAttr), global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.Binder>(@__env, binder), global::net.sf.jni4net.utils.Convertor.ArrayFullJ2C<object[], object>(@__env, parameters), global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Globalization.CultureInfo>(@__env, culture)));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle Invoke5(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle parameters) {
            // ([Lsystem/Object;)Lsystem/Object;
            // ([LSystem/Object;)LSystem/Object;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::System.Reflection.ConstructorInfo @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.Reflection.ConstructorInfo>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.FullC2J<object>(@__env, @__real.Invoke(global::net.sf.jni4net.utils.Convertor.ArrayFullJ2C<object[], object>(@__env, parameters)));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        new internal sealed class ContructionHelper : global::net.sf.jni4net.utils.IConstructionHelper {
            
            public global::net.sf.jni4net.jni.IJvmProxy CreateProxy(global::net.sf.jni4net.jni.JNIEnv @__env) {
                return new global::System.Reflection.@__ConstructorInfo(@__env);
            }
        }
    }
    #endregion
}
