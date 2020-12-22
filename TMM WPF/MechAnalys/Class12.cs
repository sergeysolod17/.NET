using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForceAnalys
{
    public class ForceAnalys
    {
#region InputData
        public double L2, L3, L4;
        public double X_D, Y_D;
        public double l_AS2, l_CS3, l_CS4;
        public double m_4, m_2, m_3;
        public double g, a_S2n, a_S3n, a_S4n;
        public double beta_S2n, beta_S3n, beta_S4n;
        public double epsilon_2n, epsilon_3n, epsilon_4n;
        public double J_S2, J_S3, J_S4;
        public double x_S2n, x_S3n, x_S4n, x_An, x_Cn;
        public double y_S2n, y_S3n, y_S4n, y_An, y_Cn;
        public double M_4;
        public double theta;
        public double fi_2n, fi_3n, fi_4n;
        public double r_omega;
        public double alpha_omega;
#endregion
#region OutputData
        //public double 
#endregion
#region TemporaryVars
        public double G_2, G_3, G_4, FI_2n, FI_3n, FI_4n, gamma_FI2n, gamma_FI3n, gamma_FI4n, M_FI2n;
        public double M_FI3n, M_FI4n, x_S22n, x_S32n, x_S42n, x_C2n, x_A2n;
        public double fi_CS3n, R_23taun, gamma_R23taun, fi_CS4n, R_14taun, gamma_R14taun, fi_G, fi_44n;
        public double c_4n, d_4n, R_23nn, gamma_R23nn, R_14nn, gamma_R14nn, R_23n, R_23xn, R_23yn, gamma_R23n, R_14n, R_14xn, R_14yn, gamma_R14n;
        public double R_34yn, R_34xn, R_34n, gamma_R34n, fi_AS2n, fi_ACn, gamma_R32n, R_32n, F_2n, M_F2n, gamma_F2n, R_12xn, R_12yn, R_12n, gamma_R12n;
#endregion
#region CalculationFunctions
        public void Calculation()
        {
            G_2 = m_2 * g;
            G_3 = m_3 * g;
            G_4 = m_4 * g;
            FI_2n = m_2 * a_S2n;
            FI_3n = m_3 * a_S3n;
            FI_4n = m_4 * a_S4n;
            gamma_FI2n = beta_S2n + Math.PI;
            gamma_FI3n = beta_S3n + Math.PI;
            gamma_FI4n = beta_S4n + Math.PI;
            M_FI2n = -J_S2 * epsilon_2n;
            M_FI3n = -J_S3 * epsilon_3n;
            M_FI4n = -J_S4 * epsilon_4n;
            x_S22n = x_S2n * Math.Cos(theta) - y_S2n * Math.Sin(theta);
            x_S32n = x_S3n * Math.Cos(theta) - y_S3n * Math.Sin(theta);
            x_S42n = x_S4n * Math.Cos(theta) - y_S4n * Math.Sin(theta);
            x_C2n = x_Cn * Math.Cos(theta) - y_Cn * Math.Sin(theta);
            x_A2n = x_An * Math.Cos(theta) - y_An * Math.Sin(theta);
            if(y_S3n >= y_Cn)
            { fi_CS3n = Math.Sign(y_S2n - y_Cn) * Math.Acos((x_S3n - x_Cn) / l_CS3); }
            else
            { fi_CS3n = Math.Sign(y_S2n - y_Cn) * Math.Acos((x_S3n - x_Cn) / l_CS3) + 2 * Math.PI; };    
            R_23taun = -(M_FI3n+FI_3n*l_CS3*Math.Sin(gamma_FI3n-fi_CS3n)+G_3*(x_C2n-x_S32n))/L3;
            if(R_23taun > 0)
            { gamma_R23taun = fi_3n - Math.PI / 2; }
            else
            { gamma_R23taun = fi_3n + Math.PI / 2; };
            if (y_S4n >= y_Cn)
            { fi_CS4n = Math.Sign(y_S4n - y_Cn) * Math.Acos((x_S4n - x_Cn) / l_CS4); }
            else 
            { fi_CS4n = Math.Sign(y_S4n - y_Cn) * Math.Acos((x_S4n - x_Cn) / l_CS4) + 2*Math.PI; };
            R_14taun = -(M_4+M_FI4n+FI_4n*l_CS4*Math.Sin(gamma_FI4n-fi_CS4n)+G_4*(x_C2n-x_S42n))/L4;
            if (R_14taun > 0)
            { gamma_R14taun = fi_4n - Math.PI / 2; }
            else
            { gamma_R14taun = fi_4n + Math.PI / 2; };
            fi_G = 1.5 * Math.PI - theta;
            fi_44n = Math.PI - fi_4n;
            c_4n = R_14taun * Math.Cos(gamma_R14taun + fi_44n) + FI_4n * Math.Cos(gamma_FI4n + fi_44n) + (G_3 + G_4) * Math.Cos(fi_G + fi_44n) + FI_3n * Math.Cos(gamma_FI3n + fi_44n) + R_23taun * Math.Cos(gamma_R23taun + fi_44n);
            d_4n = R_14taun * Math.Cos(gamma_R14taun - fi_3n) + fi_4n * Math.Cos(gamma_FI4n - fi_3n) + (G_3 + G_4) * Math.Cos(fi_G - fi_3n) + fi_3n * Math.Cos(gamma_FI3n - fi_3n) + R_23taun * Math.Cos(gamma_R23taun - fi_3n);
            R_23nn = (c_4n*Math.Cos(fi_4n-fi_3n-Math.PI)-d_4n)/(1-Math.Cos(fi_3n+fi_44n)*Math.Cos(fi_4n-fi_3n-Math.PI));
            if (R_23nn > 0)
                { gamma_R23taun = fi_3n; }
            else
                { gamma_R23taun = fi_3n - Math.PI; };
            R_14nn = -(c_4n + R_23nn * Math.Cos(fi_3n + fi_44n));
            if (R_14nn > 0)
                { gamma_R14nn = fi_4n - Math.PI; }
            else
                { gamma_R14nn = fi_4n; };
            R_23n = Math.Sqrt(R_23taun * R_23taun + R_23nn * R_23nn);
            R_23xn = R_23nn * Math.Cos(gamma_R23nn) + R_23taun * Math.Cos(gamma_R23taun);
            R_23yn = R_23nn * Math.Sin(gamma_R23nn) + R_23taun * Math.Sin(gamma_R23taun);
            if (R_23yn >= 0)
                { gamma_R23n = Math.Acos(R_23xn / R_23n); }
            else
                { gamma_R23n = -Math.Acos(R_23xn / R_23n)+2*Math.PI; };
            R_14n = Math.Sqrt(R_14taun * R_14taun + R_14nn * R_14nn);
            R_14xn = R_14nn * Math.Cos(gamma_R14nn) + R_14taun * Math.Cos(gamma_R14taun);
            R_14yn = R_14nn * Math.Sin(gamma_R14nn) + R_14taun * Math.Sin(gamma_R14taun);
            if (R_14yn >= 0)
                { gamma_R14n = Math.Acos(R_14xn/R_14n);}
            else
                { gamma_R14n = - Math.Acos(R_14xn / R_14n)+2*Math.PI; };
            R_34yn = -(R_14n*Math.Sin(gamma_R14n)+fi_4n*Math.Sin(gamma_FI4n)+G_4*Math.Sin(fi_G));
            R_34xn = -(R_14n * Math.Cos(gamma_R14n) + fi_4n * Math.Cos(gamma_FI4n) + G_4 * Math.Cos(fi_G));
            R_34n = Math.Sqrt(R_34xn * R_34xn + R_34yn * R_34yn);
            if (R_34yn >= 0)
                { gamma_R34n = Math.Acos(R_34xn / R_34n); }
            else
                { gamma_R34n = -Math.Acos(R_34xn / R_34n)+2*Math.PI; };
            if (y_S2n >= y_An)
                { fi_AS2n = Math.Sign(x_S2n - y_An) * Math.Acos((x_S2n - x_An) / l_AS2); }
            else
                { fi_AS2n = Math.Sign(x_S2n - y_An) * Math.Acos((x_S2n - x_An) / l_AS2) + 2 * Math.PI; };
            if (y_Cn >= y_An)
                { fi_ACn = Math.Sign(x_Cn - y_An) * Math.Acos((x_Cn - x_An) / L2); }
            else
                { fi_ACn = Math.Sign(x_Cn - y_An) * Math.Acos((x_Cn - x_An) / L2) + 2 * Math.PI; };
            gamma_R32n = gamma_R23n + Math.PI;
            R_32n = R_23n;
            M_F2n = -(R_32n*L2*Math.Sin(gamma_R32n-fi_ACn)+FI_2n*l_AS2*Math.Sin(gamma_FI2n-fi_AS2n)+G_2*(x_A2n-x_S22n)+M_FI2n);
            F_2n = Math.Abs(M_F2n/(r_omega*Math.Cos(alpha_omega)));
            if (M_F2n > 0)
                { gamma_F2n = -alpha_omega; }
            else
                { gamma_F2n = Math.PI - alpha_omega; };
            R_12xn = -(R_32n * Math.Cos(gamma_R32n) + G_2 * Math.Cos(fi_G) + FI_2n * Math.Cos(gamma_FI2n) + F_2n * Math.Cos(gamma_F2n));
            R_12yn = -(R_32n * Math.Sin(gamma_R32n) + G_2 * Math.Sin(fi_G) + FI_2n * Math.Sin(gamma_FI2n) + F_2n * Math.Sin(gamma_F2n));
            R_12n = Math.Sqrt(R_12xn * R_12xn + R_12yn * R_12yn);
            if (R_12yn >= 0)
            { gamma_R12n = Math.Acos(R_12xn / R_12n); }
            else
            { gamma_R12n = -Math.Acos(R_12xn / R_12n) + 2 * Math.PI; };
        }
        public void Test()
        { 
        L2 = 5.0;
        L3 = 15;
        L4 = 14;
        X_D = 10;
        Y_D = -4;
         l_AS2 = 2.5; l_CS3 = 7.5; l_CS4 = 7;
         m_4 = 3; m_2 = 1; m_3 = 2;
         g = 10; a_S2n = 11.2; a_S3n = 14.3; a_S4n = 4;
         beta_S2n = 5.12; beta_S3n = 4.93; beta_S4n = 4.35;
         epsilon_2n = 2; epsilon_3n = 1.13; epsilon_4n = 0.214;
         J_S2 = 0.01; J_S3 = 2.0; J_S4 = 3.0;
         x_S2n = -1.92; x_S3n = 2.84; x_S4n = 9.77; x_An = 0; x_Cn = 9.53;
         y_S2n = 1.6; y_S3n = 6.6; y_S4n = 3.0; y_An = 0; y_Cn = 10;
         M_4 = -50;
         theta = 2.09;
         fi_2n = 2.45; fi_3n = 0.47; fi_4n = 1.6;
         r_omega = 5;
         alpha_omega = 0.349;
         Calculation();
        }
#endregion

    }
}
