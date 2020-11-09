using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EDS_34112001
{
    class EllipticCurve
    {
        public BigInteger a;
        public BigInteger b;
        public BigInteger p;
        public BigInteger m;
        public BigInteger q;
    }

    class EllipticCurvePoint
    {
        public BigInteger x;
        public BigInteger y;
        public bool isZero;
    }

    class SignatureParameters
    {
        public EllipticCurve c;
        public EllipticCurvePoint P;
    }

    class SignatureKey
    {
        public BigInteger d;
    }

    class VerificationKey
    {
        public EllipticCurvePoint Q;
    }
    class EDS
    {
        // Генерирует число в диапозоне от [min, max]
        static BigInteger getRandomBigint(BigInteger minBound, BigInteger maxBound)
        {
            //Модель умножения на число из интервала [0,1)
            BigInteger difference = maxBound - minBound;
            int length = difference.ToByteArray().Length;
            Random random = new Random();
            byte[] data = new byte[length];
            random.NextBytes(data);
            data[data.Length - 1] &= 0x7F;
            BigInteger numerator = new BigInteger(data);
            BigInteger denominator = BigInteger.One << (data.Length * 8 - 1);
            // 
            return minBound + (difference * numerator) / denominator;
        }

        //gcd(a, b) = a * x + b * y
        static BigInteger ExtendedEuclideanAlgorithm(BigInteger a, BigInteger b, out BigInteger x, out BigInteger y)
        {
            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }
            BigInteger x1, y1;
            BigInteger gcd = ExtendedEuclideanAlgorithm(b % a, a, out x1, out y1);
            x = y1 - (b / a) * x1;
            y = x1;
            return gcd;
        }

        //находит обратный элемент для a в конечном p-поле
        static BigInteger InverseElement(BigInteger a, BigInteger p)
        {
            // p должно быть простым числом
            BigInteger x, y;
            BigInteger gcd = ExtendedEuclideanAlgorithm(a, p, out x, out y);
            return (x % p + p) % p;
        }

        // выполняет сложение двух точек на эллиптической кривой
        static EllipticCurvePoint AddEllipticCurvePoints(EllipticCurve c, EllipticCurvePoint p1, EllipticCurvePoint p2)
        {
            EllipticCurvePoint result = new EllipticCurvePoint();

            if (p1.isZero)
                return p2;

            if (p2.isZero)
                return p1;

            if (p1.x == p2.x && (p1.y + p2.y) % c.p == 0)
            {
                result.isZero = true;
                return result;
            }

            BigInteger numerator, denominator;
            if (p1.x != p2.x)
            {
                numerator = (p2.y - p1.y + c.p) % c.p;
                denominator = (p2.x - p1.x + c.p) % c.p;
            }
            else
            {
                // (p1.x == p2.x && p1.y == p2.y && p1.y != 0)
                numerator = (3 * p1.x * p1.x + c.a) % c.p;
                denominator = (2 * p1.y) % c.p;
            }
            BigInteger lambda = (numerator * InverseElement(denominator, c.p)) % c.p;
            result.x = (lambda * lambda - p1.x - p2.x + 2 * c.p) % c.p;
            result.y = (lambda * (p1.x - result.x + c.p) - p1.y + c.p) % c.p;
            return result;
        }

        // выполняет быстрое умножение заданной точки p на эллиптической кривой c на число k
        static EllipticCurvePoint MultiplyEllipticCurvePoints(EllipticCurve c, EllipticCurvePoint p, BigInteger k)
        {
            if (k == 1)
            {
                return p;
            }
            else if (k.IsEven)
            {
                EllipticCurvePoint q = MultiplyEllipticCurvePoints(c, p, k / 2);
                return AddEllipticCurvePoints(c, q, q);
            }
            else
            {
                EllipticCurvePoint q = MultiplyEllipticCurvePoints(c, p, k - 1);
                return AddEllipticCurvePoints(c, q, p);
            }
        }

        //создаёт файл с ЭЦП
        public static void CreateSignature(string filename, SignatureParameters signature, SignatureKey key)
        {
            BigInteger h = FileHash.CalculateHash(filename);
            BigInteger e = h % signature.c.q;
            if (e == 0)
                e = 1;

            BigInteger r, s;
            while (true)
            {
                BigInteger k = getRandomBigint(0, signature.c.q - 1) + 1;
                // 0 < k < q
                r = MultiplyEllipticCurvePoints(signature.c, signature.P, k).x % signature.c.q;
                if (r == 0)
                    continue;

                s = (r * key.d + k * e) % signature.c.q;
                if (s != 0)
                    break;
            }
            BigInteger result = r * (BigInteger.One << 256) + s;

            //Создаёт файл
            string signatureFile = filename + ".sg";
            StreamWriter fileStream = new StreamWriter(signatureFile);
            fileStream.Write(result.ToString("x").PadLeft(128, '0'));
            fileStream.Close();
        }

        // Проверка файла
        public static bool CheckSignature(string filename, SignatureParameters signature, VerificationKey key)
        {
            string signatureFile = filename + ".sg";
            StreamReader fileStream = new StreamReader(signatureFile);
            string signatureHex = fileStream.ReadLine();
            fileStream.Close();

            BigInteger r, s;
            r = BigInteger.DivRem(BigInteger.Parse(signatureHex, NumberStyles.AllowHexSpecifier), BigInteger.One << 256, out s);
            if (r <= 0 || r >= signature.c.q || s <= 0 || s >= signature.c.q)
            {
                throw new Exception("Файл подписи недействителен");
            }

            BigInteger h = FileHash.CalculateHash(filename);
            BigInteger e = h % signature.c.q;
            if (e == 0)
                e = 1;

            BigInteger v = InverseElement(e, signature.c.q);
            BigInteger z1 = (s * v) % signature.c.q;
            BigInteger z2 = (-(r * v) % signature.c.q + signature.c.q) % signature.c.q;
            EllipticCurvePoint C1 = MultiplyEllipticCurvePoints(signature.c, signature.P, z1);
            EllipticCurvePoint C2 = MultiplyEllipticCurvePoints(signature.c, key.Q, z2);
            EllipticCurvePoint C = AddEllipticCurvePoints(signature.c, C1, C2);
            BigInteger R = C.x % signature.c.q;
            if (R == r)
                return true;
            else
                return false;
        }
    }
}
