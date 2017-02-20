// Type: System.IO.StringReader
// Assembly: mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: c:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll

using System;
using System.Runtime.InteropServices;

namespace System.IO
{
    [ComVisible(true)]
    [Serializable]
    public class StringReader : TextReader
    {
        public StringReader(string s);
        public override void Close();
        protected override void Dispose(bool disposing);
        public override int Peek();
        public override int Read();
        public override int Read([In, Out] char[] buffer, int index, int count);
        public override string ReadToEnd();
        public override string ReadLine();
    }
}
