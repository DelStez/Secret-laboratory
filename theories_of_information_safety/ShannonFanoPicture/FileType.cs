using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShannonFanoPicture
{
    public class FileType
    {
        public byte?[] header { get; private set; }
        public int headerOffset { get; private set; }
        public string extension { get; private set; }
        public string mime { get; private set; }

        public FileType(byte?[] header, string extension, string mime)
        {
            this.header = header;
            this.extension = extension;
            this.mime = mime;
            this.headerOffset = 0;
        }

        public FileType(byte?[] header, int offset, string extension, string mime)
        {
            this.header = null;
            this.header = header;
            this.headerOffset = offset;
            this.extension = extension;
            this.mime = mime;
        }


        public override bool Equals(object other)
        {
            if (!base.Equals(other)) return false;

            if (!(other is FileType)) return false;

            FileType otherType = (FileType)other;

            if (this.header != otherType.header) return false;
            if (this.headerOffset != otherType.headerOffset) return false;
            if (this.extension != otherType.extension) return false;
            if (this.mime != otherType.mime) return false;


            return true;
        }

        public override string ToString()
        {
            return extension;
        }
    }
    public static class Detective
    {

        public readonly static FileType JPEG = new FileType(new byte?[] { 0xFF, 0xD8, 0xFF }, "jpg", "image/jpeg");
        public readonly static FileType PNG = new FileType(new byte?[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, "png", "image/png");
        public readonly static FileType GIF = new FileType(new byte?[] { 0x47, 0x49, 0x46, 0x38, null, 0x61 }, "gif", "image/gif");

        private readonly static List<FileType> types = new List<FileType> {JPEG, PNG, GIF};

        private const int MaxHeaderSize = 560;

        public static FileType GetFileType(this FileInfo file)
        {

            Byte[] fileHeader = ReadFileHeader(file, MaxHeaderSize);

            foreach (FileType type in types)
            {
                int matchingCount = 0;
                for (int i = 0; i < type.header.Length; i++)
                {
                    if (type.header[i] != null && type.header[i] != fileHeader[i + type.headerOffset])
                    {
                        matchingCount = 0;
                        break;
                    }
                    else
                    {
                        matchingCount++;
                    }
                }
                if (matchingCount == type.header.Length)
                {

                    return type;
                }
            }
            return null;
        }

        private static Byte[] ReadFileHeader(FileInfo file, int MaxHeaderSize)
        {
            Byte[] header = new byte[MaxHeaderSize];
            try 
            {
                using (FileStream fsSource = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    fsSource.Read(header, 0, MaxHeaderSize);
                }   
            }
            catch (Exception e)
            {
                throw new ApplicationException("Нечитаемый файл : " + e.Message);
            }

            return header;
        }

        public static bool isFileOfTypes(this FileInfo file, List<FileType> requiredTypes)
        {
            FileType currentType = file.GetFileType();

            if (null == currentType)
            {
                return false;
            }

            return requiredTypes.Contains(currentType);
        }
        public static bool isFileOfTypes(this FileInfo file, String CSV)
        {
            List<FileType> providedTypes = GetFileTypesByExtensions(CSV);

            return file.isFileOfTypes(providedTypes);
        }
        private static List<FileType> GetFileTypesByExtensions(String CSV)
        {
            String[] extensions = CSV.ToUpper().Replace(" ", "").Split(',');

            List<FileType> result = new List<FileType>();

            foreach (FileType type in types)
            {
                if (extensions.Contains(type.extension.ToUpper()))
                {
                    result.Add(type);
                }
            }
            return result;
        }

        public static bool isType(this FileInfo file, FileType type)
        {
            FileType actualType = GetFileType(file);

            if (null == actualType)
                return false;

            return (actualType.Equals(type));
        }

        public static bool isJpeg(this FileInfo fileInfo)
        {
            return fileInfo.isType(JPEG);
        }

        public static bool isPng(this FileInfo fileInfo)
        {
            return fileInfo.isType(PNG);
        }
        public static bool isGif(this FileInfo fileInfo)
        {
            return fileInfo.isType(GIF);
        }
    }
    class BitReader : IDisposable
    {
        BufferedStream s = null;
        MemoryStream ms = null;

        bool disposed = false;
        byte? b = null;
        int pos = 0;

        public BitOrder bitOrder = BitOrder.LeftToRight;
        public bool EndOfStream;

        public BitReader(BufferedStream _s)
        {
            s = _s;
        }

        public BitReader(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;

            s = new BufferedStream(ms);
        }


        public bool? ReadBit()
        {
            bool? result = null;

            try
            {
                if (b == null || (pos % 8 == 0))
                {
                    int i = s.ReadByte();

                    if (i == -1)
                    {
                        throw new EndOfStreamException();
                    }
                    else
                    {
                        b = Convert.ToByte(i);
                    }

                    pos = 0;
                }

                if (bitOrder == BitOrder.LeftToRight)
                {
                    result = Convert.ToBoolean(b & (1 << (7 - pos)));
                }
                else if (bitOrder == BitOrder.RightToLeft)
                {
                    result = Convert.ToBoolean((b >> pos) % 2);
                }

                pos++;

                return result;
            }
            catch (EndOfStreamException)
            {
                EndOfStream = true;

                return null;
            }
        }

        public bool?[] ReadBits(int n)
        {
            bool?[] bits = new bool?[n];

            for (int i = 0; i < n; i++)
            {
                bool? bit = ReadBit();
                bits[i] = bit;
            }

            return bits;
        }

        public bool[] ReadAll()
        {
            List<bool> bits = new List<bool>();
            bool? bit = null;
            while ((bit = ReadBit()) != null)
            {
                bits.Add(bit.Value);
            }

            return bits.ToArray();
        }

        public long Position
        {
            get
            {
                return ((s.Position - 1) * 8) + (pos - 1);
            }
        }

        public long Length
        {
            get
            {
                return s.Length * 8;
            }
        }


        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (this.s != null)
                    {
                        s.Close();
                    }

                    if (this.ms != null)
                    {
                        ms.Close();
                    }
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion

        public enum BitOrder
        {
            LeftToRight = 0,
            RightToLeft = 1
        }
    }
    public static class ExtensionMethods
    {
        public static void ForEach<T>(this IEnumerable<T> sequance, Action<T> action)
        {
            foreach (T item in sequance)
            {
                action(item);
            }
        }

        public static void WriteLine<T>(this IEnumerable<T> sequence)
        {
            foreach (T item in sequence)
            {
                Console.WriteLine(item);
            }
        }

        public static void WriteLine<K, V>(this Dictionary<K, V> dict)
        {
            foreach (var pair in dict)
            {
                Console.WriteLine("Key: " + pair.Key + ", Value: " + pair.Value);
            }
        }

        public static string ToStringLines<K, V>(this Dictionary<K, V> dict)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pair in dict)
            {
                sb.Append(("Key: " + pair.Key + ", Value: " + pair.Value));
                sb.AppendLine();
            }

            return sb.ToString();
        }


        public static string FillWithZero(this string value, int len)
        {
            while (value.Length < len)
            {
                value = "0" + value;
            }

            return value;
        }

        public static byte[] ToByteArray(this string value)
        {
            List<byte> l = new List<byte>();

            int i = 0;
            for (i = 0; i < value.Length; i += 8)
            {
                string bs = "";
                if (i + 8 <= value.Length)
                {
                    bs = value.Substring(i, 8);
                }
                else
                {
                    bs = value.Substring(i, value.Length - i);
                }

                byte b = Convert.ToByte(bs, 2);

                l.Add(b);
            }

            return l.ToArray();
        }

        public static string GetBinaryString(this byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();

            using (BitReader br = new BitReader(bytes))
            {
                bool[] bb = br.ReadAll();
                for (int i = 0; i < bb.Length; i++)
                {
                    bool b = bb[i];
                    sb.Append(Convert.ToInt32(b).ToString());
                }
            }

            return sb.ToString();
        }

        public static string FindKey(this IDictionary<string, int> lookup, int value)
        {
            foreach (var pair in lookup)
            {
                if (pair.Value == value)
                {
                    return pair.Key;
                }
            }

            return null;
        }
    }
}
