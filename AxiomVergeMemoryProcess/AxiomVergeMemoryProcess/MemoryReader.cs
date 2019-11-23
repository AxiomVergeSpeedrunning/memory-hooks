using System.Diagnostics;

namespace TrackerLibrary
{
    public class MemoryReader
    {
        public int MemoryReadBytes(Process process, long _baseAddress, int _offsetAddress, int _deepPointerOffset1, int _deepPointerOffset2)
        {
            var Pointer = new DeepPointer(_baseAddress + _offsetAddress, true, _deepPointerOffset1, _deepPointerOffset2);
            return Pointer.Deref<int>(process);
        }

        public int MemoryReadBytes(Process process, long _baseAddress, int _offsetAddress, int _deepPointerOffset1, int _deepPointerOffset2, int _deepPointerOffset3)
        {
            var Pointer = new DeepPointer(_baseAddress + _offsetAddress, true, _deepPointerOffset1, _deepPointerOffset2, _deepPointerOffset3);
            return Pointer.Deref<int>(process);
        }

        public string MemoryReadBytesAsString(Process process, long _baseAddress, int _offsetAddress, int _deepPointerOffset1, int _deepPointerOffset2)
        {
            var Pointer = new DeepPointer(_baseAddress + _offsetAddress, true, _deepPointerOffset1, _deepPointerOffset2);
            var success = Pointer.Deref(process, out int _ptr);
            var ValueToString = success ? _ptr.ToString() : "?";
            return ValueToString;
        }

        public string MemoryReadString(Process process, long _baseAddress, int _offsetAddress, int _deepPointerOffset1, int _deepPointerOffset2, int _deepPointerOffset3, int _deepPointerOffset4)
        {
            var stringLen = new DeepPointer(_baseAddress + _offsetAddress, true, _deepPointerOffset1, _deepPointerOffset2, _deepPointerOffset3);
            var len = stringLen.Deref<int>(process);
            var stringArr = new DeepPointer(_baseAddress + _offsetAddress, true, _deepPointerOffset1, _deepPointerOffset2, _deepPointerOffset4);
            var bytes = stringArr.DerefBytes(process, len * 2);
            if (bytes == null) { return ""; }
            var result = System.Text.Encoding.Unicode.GetString(bytes);
            return result;
        }

        public string MemoryReadListItemString(Process process, long _baseAddress, int _offsetAddress, int _deepPointerOffset1, int _deepPointerOffset2, int _deepPointerOffset3, int _deepPointerOffset4, int _deepPointerOffset5, int _deepPointerOffset6, int _deepPointerOffset7)
        {
            var stringLen = new DeepPointer(_baseAddress + _offsetAddress, true, _deepPointerOffset1, _deepPointerOffset2, _deepPointerOffset3, _deepPointerOffset4, _deepPointerOffset5, _deepPointerOffset6);
            var len = stringLen.Deref<int>(process);
            var stringArr = new DeepPointer(_baseAddress + _offsetAddress, true, _deepPointerOffset1, _deepPointerOffset2, _deepPointerOffset3, _deepPointerOffset4, _deepPointerOffset5, _deepPointerOffset7);
            var bytes = stringArr.DerefBytes(process, len * 2);
            var result = System.Text.Encoding.Unicode.GetString(bytes);
            return result;
        }

        public int MemoryReadListItemBytes(Process process, long _baseAddress, int _offsetAddress, int _deepPointerOffset1, int _deepPointerOffset2, int _deepPointerOffset3, int _deepPointerOffset4, int _deepPointerOffset5)
        {
            var Pointer = new DeepPointer(_baseAddress + _offsetAddress, true, _deepPointerOffset1, _deepPointerOffset2, _deepPointerOffset3, _deepPointerOffset4, _deepPointerOffset5);
            return Pointer.Deref<int>(process);
        }

    }
}
