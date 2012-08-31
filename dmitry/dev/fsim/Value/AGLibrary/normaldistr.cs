/*************************************************************************
Cephes Math Library Release 2.8:  June, 2000
Copyright 1984, 1987, 1988, 1992, 2000 by Stephen L. Moshier

Contributors:
    * Sergey Bochkanov (ALGLIB project). Translation from C to
      pseudocode.

See subroutines comments for additional copyrights.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are
met:

- Redistributions of source code must retain the above copyright
  notice, this list of conditions and the following disclaimer.

- Redistributions in binary form must reproduce the above copyright
  notice, this list of conditions and the following disclaimer listed
  in this license in the documentation and/or other materials
  provided with the distribution.

- Neither the name of the copyright holders nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*************************************************************************/

using System;

namespace AGLibrary
{
    public class normaldistr
    {
        /*************************************************************************
        ���������� ������� erf

        ������� ���������:
            x   -   ��������

        ���������� ��������:
            -inf < x < +inf

        �������� (������������� �����������):

        arithmetic   domain     # trials      peak         rms
           IEEE      0,1         30000       3.7e-16     1.0e-16

        Cephes Math Library Release 2.8:  June, 2000
        Copyright 1984, 1987, 1988, 1992, 2000 by Stephen L. Moshier
        *************************************************************************/

        public static double erf(double x)
        {
            double result = 0;
            double xsq = 0;
            double s = 0;
            double p = 0;
            double q = 0;

            s = Math.Sign(x);
            x = Math.Abs(x);
            if (x < 0.5)
            {
                /*
                 * The commented author's code gives, for example, the accuracy .2862276975845121e-8
                 * for x = 0.49 instead of announced by the authors 1.0e-16. We correct this 
                 * situation using row expansion for erf(). Our code gives an accuracy < .2759017e-17
                 * for |x| < 0.5 (fixed by Tyshkevich Dmitry) 
                 */ 
                //xsq = x * x;
                //p = 0.007547728033418631287834;
                //p = 0.288805137207594084924010 + xsq * p;
                //p = 14.3383842191748205576712 + xsq * p;
                //p = 38.0140318123903008244444 + xsq * p;
                //p = 3017.82788536507577809226 + xsq * p;
                //p = 7404.07142710151470082064 + xsq * p;
                //p = 80437.3630960840172832162 + xsq * p;
                //q = 0.0;
                //q = 1.00000000000000000000000 + xsq * q;
                //q = 38.0190713951939403753468 + xsq * q;
                //q = 658.070155459240506326937 + xsq * q;
                //q = 6379.60017324428279487120 + xsq * q;
                //q = 34216.5257924628539769006 + xsq * q;
                //q = 80437.3630960840172826266 + xsq * q;
                //result = s * 1.1283791670955125738961589031 * x * p / q;
                //return result;
                xsq = x * x;
                q = xsq;
                p = 1.0 - q / 3.0;
                q = q * xsq ;
                p = p + q * 0.1 ;
                q = q * xsq ;
                p = p - q / 42.0;
                q = q * xsq ;
                p = p + q / 216.0;
                q = q * xsq ;
                p = p - q / 1320.0;
                q = q * xsq ;
                p = p + q / 9360.0;
                q = q * xsq ;
                p = p - q / 75600.0;
                q = q * xsq ;
                p = p + q / 685440.0;
                q = q * xsq ;
                p = p - q / 6894720.0;
                q = q * xsq ;
                p = p + q / 76204800.0;
                q = q * xsq ;
                p = p - q / 918086400.0;
                result = s * 1.1283791670955125738961589031 * x * p;
                return result;
            }
            if (x >= 10)
            {
                result = s;
                return result;
            }
            result = s * (1 - erfc(x));
            return result;
        }


        /*************************************************************************
        ���������� �������������� ������� erfc

        ������� ���������:
            x   -   ��������

        ���������� ��������:
            -inf < x < +inf
        
        �������� (������������� �����������):

        arithmetic   domain     # trials      peak         rms
           IEEE      0,26.6417   30000       5.7e-14     1.5e-14

        Cephes Math Library Release 2.8:  June, 2000
        Copyright 1984, 1987, 1988, 1992, 2000 by Stephen L. Moshier
        *************************************************************************/

        public static double erfc(double x)
        {
            double result = 0;
            double p = 0;
            double q = 0;

            if (x < 0)
            {
                result = 2 - erfc(-x);
                return result;
            }
            if (x < 0.5)
            {
                result = 1.0 - erf(x);
                return result;
            }
            if (x >= 10)
            {
                result = 0;
                return result;
            }
            p = 0.0;
            p = 0.5641877825507397413087057563 + x * p;
            p = 9.675807882987265400604202961 + x * p;
            p = 77.08161730368428609781633646 + x * p;
            p = 368.5196154710010637133875746 + x * p;
            p = 1143.262070703886173606073338 + x * p;
            p = 2320.439590251635247384768711 + x * p;
            p = 2898.0293292167655611275846 + x * p;
            p = 1826.3348842295112592168999 + x * p;
            q = 1.0;
            q = 17.14980943627607849376131193 + x * q;
            q = 137.1255960500622202878443578 + x * q;
            q = 661.7361207107653469211984771 + x * q;
            q = 2094.384367789539593790281779 + x * q;
            q = 4429.612803883682726711528526 + x * q;
            q = 6089.5424232724435504633068 + x * q;
            q = 4958.82756472114071495438422 + x * q;
            q = 1826.3348842295112595576438 + x * q;
            result = Math.Exp(-ApMath.Sqr(x)) * p / q;
            return result;
        }


        /*************************************************************************
        ���������� ������������ ������� ����������� ����������� �������������

        ������� ���������:
            x   -   ��������

        ���������� ��������:
            -inf < x < +inf

        �������� (������������� �����������):

        arithmetic   domain     # trials      peak         rms
           IEEE     -13,0        30000       3.4e-14     6.7e-15

        Cephes Math Library Release 2.8:  June, 2000
        Copyright 1984, 1987, 1988, 1992, 2000 by Stephen L. Moshier
        *************************************************************************/

        public static double normaldistribution(double x)
        {
            double result = 0;

            result = 0.5 * (erf(x / 1.41421356237309504880) + 1);
            return result;
        }


        /*************************************************************************
        ���������� �������, �������� � erf(x)

        ������� ���������:
            E

        ���������� ��������:
            -1 < E < 1

        �� ��������� -0.99999998 < E < 0.99999998 ���������� �����������
        ����������� �������� �� ����������� 10^-8.

        Cephes Math Library Release 2.8:  June, 2000
        Copyright 1984, 1987, 1988, 1992, 2000 by Stephen L. Moshier
        *************************************************************************/

        public static double inverf(double e)
        {
            double result = 0;

            result = invnormaldistribution(0.5 * (e + 1)) / Math.Sqrt(2);
            return result;
        }


        /*************************************************************************
        ���������� �������� ������������ ������� ����������� �����������
        �������� �������������.

        ������� ���������:
            y0

        ���������� ��������:
            0 < y0 < 1

        �������� (������������� �����������):

        arithmetic   domain        # trials      peak         rms
           IEEE     0.125, 1        20000       7.2e-16     1.3e-16
           IEEE     3e-308, 0.135   50000       4.6e-16     9.8e-17

        Cephes Math Library Release 2.8:  June, 2000
        Copyright 1984, 1987, 1988, 1992, 2000 by Stephen L. Moshier
        *************************************************************************/

        public static double invnormaldistribution(double y0)
        {
            double result = 0;
            double expm2 = 0;
            double s2pi = 0;
            double x = 0;
            double y = 0;
            double z = 0;
            double y2 = 0;
            double x0 = 0;
            double x1 = 0;
            int code = 0;
            double p0 = 0;
            double q0 = 0;
            double p1 = 0;
            double q1 = 0;
            double p2 = 0;
            double q2 = 0;

            expm2 = 0.13533528323661269189;
            s2pi = 2.50662827463100050242;
            if (y0 <= 0)
            {
                result = -ApMath.MaxRealNumber;
                return result;
            }
            if (y0 >= 1)
            {
                result = ApMath.MaxRealNumber;
                return result;
            }
            code = 1;
            y = y0;
            if (y > 1.0 - expm2)
            {
                y = 1.0 - y;
                code = 0;
            }
            if (y > expm2)
            {
                y = y - 0.5;
                y2 = y * y;
                p0 = -59.9633501014107895267;
                p0 = 98.0010754185999661536 + y2 * p0;
                p0 = -56.6762857469070293439 + y2 * p0;
                p0 = 13.9312609387279679503 + y2 * p0;
                p0 = -1.23916583867381258016 + y2 * p0;
                q0 = 1;
                q0 = 1.95448858338141759834 + y2 * q0;
                q0 = 4.67627912898881538453 + y2 * q0;
                q0 = 86.3602421390890590575 + y2 * q0;
                q0 = -225.462687854119370527 + y2 * q0;
                q0 = 200.260212380060660359 + y2 * q0;
                q0 = -82.0372256168333339912 + y2 * q0;
                q0 = 15.9056225126211695515 + y2 * q0;
                q0 = -1.18331621121330003142 + y2 * q0;
                x = y + y * y2 * p0 / q0;
                x = x * s2pi;
                result = x;
                return result;
            }
            x = Math.Sqrt(-(2.0 * Math.Log(y)));
            x0 = x - Math.Log(x) / x;
            z = 1.0 / x;
            if (x < 8.0)
            {
                p1 = 4.05544892305962419923;
                p1 = 31.5251094599893866154 + z * p1;
                p1 = 57.1628192246421288162 + z * p1;
                p1 = 44.0805073893200834700 + z * p1;
                p1 = 14.6849561928858024014 + z * p1;
                p1 = 2.18663306850790267539 + z * p1;
                p1 = -(1.40256079171354495875 * 0.1) + z * p1;
                p1 = -(3.50424626827848203418 * 0.01) + z * p1;
                p1 = -(8.57456785154685413611 * 0.0001) + z * p1;
                q1 = 1;
                q1 = 15.7799883256466749731 + z * q1;
                q1 = 45.3907635128879210584 + z * q1;
                q1 = 41.3172038254672030440 + z * q1;
                q1 = 15.0425385692907503408 + z * q1;
                q1 = 2.50464946208309415979 + z * q1;
                q1 = -(1.42182922854787788574 * 0.1) + z * q1;
                q1 = -(3.80806407691578277194 * 0.01) + z * q1;
                q1 = -(9.33259480895457427372 * 0.0001) + z * q1;
                x1 = z * p1 / q1;
            }
            else
            {
                p2 = 3.23774891776946035970;
                p2 = 6.91522889068984211695 + z * p2;
                p2 = 3.93881025292474443415 + z * p2;
                p2 = 1.33303460815807542389 + z * p2;
                p2 = 2.01485389549179081538 * 0.1 + z * p2;
                p2 = 1.23716634817820021358 * 0.01 + z * p2;
                p2 = 3.01581553508235416007 * 0.0001 + z * p2;
                p2 = 2.65806974686737550832 * 0.000001 + z * p2;
                p2 = 6.23974539184983293730 * 0.000000001 + z * p2;
                q2 = 1;
                q2 = 6.02427039364742014255 + z * q2;
                q2 = 3.67983563856160859403 + z * q2;
                q2 = 1.37702099489081330271 + z * q2;
                q2 = 2.16236993594496635890 * 0.1 + z * q2;
                q2 = 1.34204006088543189037 * 0.01 + z * q2;
                q2 = 3.28014464682127739104 * 0.0001 + z * q2;
                q2 = 2.89247864745380683936 * 0.000001 + z * q2;
                q2 = 6.79019408009981274425 * 0.000000001 + z * q2;
                x1 = z * p2 / q2;
            }
            x = x0 - x1;
            if (code != 0)
            {
                x = -x;
            }
            result = x;
            return result;
        }
    }
}