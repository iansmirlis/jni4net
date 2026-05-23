#region Copyright (C) 2009 by Pavel Savara

/*
This file is part of jni4net library - bridge between Java and .NET
http://jni4net.sourceforge.net/

This content is released under the (http://opensource.org/licenses/MIT) MIT License, see license/jni4net-MIT.txt.
*/

#endregion

using System;
using System.Runtime.Serialization;

namespace net.sf.jni4net.jni
{
    [Serializable]
    public class JNIException : Exception
    {
#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB0051 // Retain the legacy serialization constructor for compatibility.
#endif
        protected JNIException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
#if NET10_0_OR_GREATER
#pragma warning restore SYSLIB0051
#endif

        public JNIException()
        {
        }

        public JNIException(string message)
            : base(message)
        {
        }

        public JNIException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
