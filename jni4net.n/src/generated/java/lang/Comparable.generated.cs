//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by jni4net. See http://jni4net.sourceforge.net/ 
//     Runtime Version:2.0.50727.3074
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace java.lang {
    
    
    #region Component Designer generated code 
    [global::net.sf.jni4net.attributes.JavaInterfaceAttribute()]
    public partial interface Comparable {
        
        int compareTo(global::java.lang.Object par0);
    }
    #endregion
    
    #region Component Designer generated code 
    public unsafe partial class Comparable_ {
        
        public new static global::java.lang.Class _class {
            get {
                return global::java.lang.@__Comparable.staticClass;
            }
        }
    }
    #endregion
    
    #region Component Designer generated code 
    [global::net.sf.jni4net.attributes.JavaProxyAttribute()]
    [global::net.sf.jni4net.attributes.ClrWrapperAttribute(typeof(global::java.lang.Comparable))]
    internal unsafe partial class @__Comparable : global::java.lang.Object, global::java.lang.Comparable {
        
        internal static global::java.lang.Class staticClass;
        
        internal static global::net.sf.jni4net.jni.MethodId _compareTo0;
        
        protected @__Comparable(global::net.sf.jni4net.jni.JNIEnv env) : 
                base(env) {
        }
        
        private static void InitJNI(global::net.sf.jni4net.jni.JNIEnv env, java.lang.Class staticClass) {
            global::java.lang.@__Comparable.staticClass = staticClass;
            global::java.lang.@__Comparable._compareTo0 = env.GetMethodID(global::java.lang.@__Comparable.staticClass, "compareTo", "(Ljava/lang/Object;)I");
        }
        
        public virtual int compareTo(global::java.lang.Object par0) {
            global::net.sf.jni4net.jni.JNIEnv env = this.Env;
            return env.CallIntMethod(this, global::java.lang.@__Comparable._compareTo0, new global::net.sf.jni4net.jni.Value(par0));
        }
        
        private static global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod> @__Init(global::net.sf.jni4net.jni.JNIEnv env, global::java.lang.Class clazz) {
            global::System.Type type = typeof(Comparable);
            global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod> methods = new global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod>();
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(type, "compareTo", "compareTo0", "(Ljava/lang/Object;)I"));
            return methods;
        }
        
        private static int compareTo0(global::net.sf.jni4net.jni.JNIEnv.JavaPtr* @__envi, global::java.lang.Object.JavaPtr* @__obj, global::java.lang.Object.JavaPtr* par0) {
            // (Ljava/lang/Object;)I
            // (Ljava/lang/Object;)I
            global::net.sf.jni4net.jni.JNIEnv @__env = (*@__envi).Wrap();
            try {
            global::java.lang.Comparable real = global::net.sf.jni4net.utils.ClrProxiesMap.ToClr<global::java.lang.Comparable>(__env, @__obj);
            return real.compareTo(global::net.sf.jni4net.utils.JavaProxiesMap.Wrap<java.lang.Object>(__env, par0));
            }catch (global::System.Exception ex){__env.ThrowExisting(ex);}
            return default(int);
        }
        
        internal sealed class ContructionHelper : global::net.sf.jni4net.utils.IConstructionHelper {
            
            public global::net.sf.jni4net.jni.IJavaProxy CreateProxy(global::net.sf.jni4net.jni.JNIEnv env) {
                return new global::java.lang.@__Comparable(env);
            }
        }
    }
    #endregion
}