using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EDS_34112001
{
    class Program
    {
        static void Main(string[] args)
        {
            // Значения взяты из стандарта
            SignatureParameters Signature = new SignatureParameters();
            Signature.c = new EllipticCurve();
            Signature.P = new EllipticCurvePoint();

            //Модуль Элиптической кривой
            Signature.c.p = BigInteger.Parse("57896044618658097711785492504343953926634992332820282019728792003956564821041");

            Signature.c.a = BigInteger.Parse("7");
            Signature.c.b = BigInteger.Parse("43308876546767276905765904595650931995942111794451039583252968842033849580414");
            Signature.c.m = BigInteger.Parse("57896044618658097711785492504343953927082934583725450622380973592137631069619");
            Signature.c.q = BigInteger.Parse("57896044618658097711785492504343953927082934583725450622380973592137631069619");
            Signature.P.x = BigInteger.Parse("2");
            Signature.P.y = BigInteger.Parse("4018974056539037503335449422937059775635739389905545080690979365213431566280");
            Signature.P.isZero = false;

            SignatureKey SignatureKey = new SignatureKey();
            SignatureKey.d = BigInteger.Parse("55441196065363246126355624130324183196576709222340016572108097750006097525544");

            VerificationKey VerificationKey = new VerificationKey();
            VerificationKey.Q = new EllipticCurvePoint();
            VerificationKey.Q.x = BigInteger.Parse("57520216126176808443631405023338071176630104906313632182896741342206604859403");
            VerificationKey.Q.y = BigInteger.Parse("17614944419213781543809391949654080031942662045363639260709847859438286763994");
            VerificationKey.Q.isZero = false;


            EDS.CreateSignature("C://Users//Kanda//Desktop//fjhg.txt", Signature, SignatureKey);
            Console.WriteLine("Подпись успешно создана!");
            if (EDS.CheckSignature("C://Users//Kanda//Desktop//fjhg.txt", Signature, VerificationKey))
            {
                Console.WriteLine("Подпись действительна!");
            }
            else
            {
                Console.WriteLine("Подпись НЕ действительна!");
            }
        }
    }
}
