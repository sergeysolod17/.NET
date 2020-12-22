using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMM_Analys
{
    public enum NumberPoints : byte
    { 
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4
    }
    public enum DirectionRotation:int
    {
        OnClockWise = 1,
        AgainClockWise = -1
    }
    public class ExceptionIllegaValue : Exception 
    {
        public string NameParameter;
        public ExceptionIllegaValue(string str) {NameParameter  = str; }
    };
    public class MechanismAnalys
    {
#region InputData
        public static double L_AB
            {
                get {return l2;} 
                set{if(value > 0) l2 = value; else{throw new ExceptionIllegaValue("L_AB");}}
            }
        public static double L_BC
            {
                get {return l3;} 
                set{if(value > 0) l3 = value; else{throw new ExceptionIllegaValue("L_BC");}}
            }
        public static double L_CD
            {
                get {return l4;} 
                set {if(value > 0) l4 = value; else{throw new ExceptionIllegaValue("L_CD");};}
            }
        public static double L_AD
            {
                get {return l_AD;}
                set { l_AD = value; if (_Y_D == 0) { _X_D = l_AD; } }
            }
        public static double L_AS2
            {
                get {return l_AS_2;} 
                set{if((value > 0)&&(value < l2)) l_AS_2 = value; else{throw new ExceptionIllegaValue("L_AS2");}}
            }
        public static double L_BS3
            {
                get {return l_BS_3;} 
                set {l_BS_3 = value;}
            }
        public static double L_DS4
            {
                get {return l_DS_4;} 
                set{if((value > 0)&&(value < l4)) l_DS_4 = value; else{throw new ExceptionIllegaValue("L_DS4");}}
            }
        public static double Omega
            {
                get {return omega;}
                set { omega = value; if (omegaDirect == null) omegaDirect = (value >= 0) ? -1 : 1; else if (value < 0) omegaDirect = -omegaDirect; }
            }
        public static double Epsilon
            {
                get {return epsilon;}
                set { epsilon = value; if (epsilonDirect == null) epsilonDirect = (value >= 0) ? -1 : 1; else if (value < 0) epsilonDirect = -epsilonDirect; }
            }
        public static double M2
        {
            get { return m_2; }
            set { if (value > 0) m_2 = value; else { throw new ExceptionIllegaValue("маса ланки 2"); } }
        }
        public static double M3
        {
            get { return m_3; }
            set { if (value > 0) m_3 = value; else { throw new ExceptionIllegaValue("маса ланки 3"); } }
        }
        public static double M4
        {
            get { return m_4; }
            set { if (value > 0) m_4 = value; else { throw new ExceptionIllegaValue("маса ланки 4"); } }
        }
        public static double J_S2
        {
            get { return _J_S2; }
            set { if (value > 0) _J_S2 = value; else { throw new ExceptionIllegaValue("момент інерції ланки 2"); } }
        }
        public static double J_S3
        {
            get { return _J_S3; }
            set { if (value > 0) _J_S3 = value; else { throw new ExceptionIllegaValue("момент інерції ланки 3"); } }
        }
        public static double J_S4
        {
            get { return _J_S4; }
            set { if (value > 0) _J_S4 = value; else { throw new ExceptionIllegaValue("момент інерції ланки 4"); } }
        }
        public static double Moment4
        {
            get { return M_4; }
            set { M_4 = value;  }
        }
        public static double g
        {
            get { return _g; }
            set { if (value > 0) _g = value; else { throw new ExceptionIllegaValue("прискорення вільного падіння"); } }
        }
        public static double V_B
        {
            get { return v_B; }
        }
        public static DirectionRotation DirectionLink4
        {
            get { return direction_link4; }
            set { direction_link4 = value; }
        }
        public static double X_A, Y_A, X_P, Y_P;
        public static double X_D { get { return _X_D; } set { _X_D = value; } }
        public static double Y_D { get { return _Y_D; } set { _X_D = value; } }
        public static int QuantIteration
        {
            get { return quantIteration; }
            set{if ((value > 0)&&(value < 1000))  quantIteration = value; else throw new ExceptionIllegaValue("кількість положень механізму"); }
        }
        public static CalculationModes CalculationMode
        {
            get { return  calculation_mode; }
            set { calculation_mode = value; }
        }
#endregion
        public enum CalculationModes : byte
        {
            CalcOnlyPlanePosition = 1,
            CalcVelocities = 2,
            CalcAcceleration = 3,
            CalcForces = 4
        }
        public struct PlanPositionParameters
        {
            public double fi_2n, X_Bn, Y_Bn, fi_3n, X_Cn, Y_Cn, fi_4n, X_S2n, Y_S2n, X_S3n, Y_S3n, X_S4n, Y_S4n,X_En, Y_En;//output data of position analys
            public double alpha_2n, v_Cn, alpha_3n, alpha_4n, omega_3n, omega_4n, v_S2n, alpha_S2n, v_S3n, alpha_S3n, v_S4n, alpha_S4n;
        }


       





        //public double l2, L3, l4;
        //public double _X_D, _Y_D;
        //public double l_AS2, l_CS3, //l_CS4;
        
        //public double beta_S2n, beta_S3n, beta_S4n;
        //public double epsilon_2n, epsilon_3n, epsilon_4n;
        
        //public double X_S2n, X_S3n, X_S4n, X_A, X_Cn;
        //public double Y_S2n, Y_S3n, Y_S4n, Y_A, Y_Cn;
        
        public double theta;
        //public double fi_2n, fi_3n, fi_4n;
        public double r_omega;
        public double alpha_omega;

#region OutputData
        public double a_Bn, beta_2n, a_Cn, a_CBn, a_S2n, beta_S2n, a_S3n, beta_S3n, a_S4n, beta_S4n, epsilon_3n, epsilon_4n; 
#endregion
#region inside_vars     
        private static double M_4, _g;
        private static double _J_S2, _J_S3, _J_S4, m_4, m_2, m_3;
        private double l_CS4 { get { return (l4 - l_DS_4); } }
        private static double l2, l3, l4, l_AD, l_AS_2, l_BS_3, l_DS_4, omega, epsilon;
        private static double  _X_D, _Y_D, omegaDirect, epsilonDirect, v_B;
        private static DirectionRotation direction_link4;
        private static int quantIteration;
        private static double Fi_Sum, Fi_0, Fi_10;
        private static bool isInitialise;
        private static CalculationModes calculation_mode;
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
            if (!isInitialise)
            { init_vars(); }

        }



        public void CalculationForces()
        {
            G_2 = m_2 * _g;
            G_3 = m_3 * _g;
            G_4 = m_4 * _g;
            FI_2n = m_2 * a_S2n;
            FI_3n = m_3 * a_S3n;
            FI_4n = m_4 * a_S4n;
            gamma_FI2n = beta_S2n + Math.PI;
            gamma_FI3n = beta_S3n + Math.PI;
            gamma_FI4n = beta_S4n + Math.PI;
            M_FI2n = -_J_S2 * epsilon_2n;
            M_FI3n = -_J_S3 * epsilon_3n;
            M_FI4n = -_J_S4 * epsilon_4n;
            x_S22n = X_S2n * Math.Cos(theta) - Y_S2n * Math.Sin(theta);
            x_S32n = X_S3n * Math.Cos(theta) - Y_S3n * Math.Sin(theta);
            x_S42n = X_S4n * Math.Cos(theta) - Y_S4n * Math.Sin(theta);
            x_C2n = X_Cn * Math.Cos(theta) - Y_Cn * Math.Sin(theta);
            x_A2n = X_A * Math.Cos(theta) - Y_A * Math.Sin(theta);
            if(Y_S3n >= Y_Cn)
            { fi_CS3n = Math.Sign(Y_S2n - Y_Cn) * Math.Acos((X_S3n - X_Cn) / l_CS3); }
            else
            { fi_CS3n = Math.Sign(Y_S2n - Y_Cn) * Math.Acos((X_S3n - X_Cn) / l_CS3) + 2 * Math.PI; };    
            R_23taun = -(M_FI3n+FI_3n*l_CS3*Math.Sin(gamma_FI3n-fi_CS3n)+G_3*(x_C2n-x_S32n))/l3;
            if(R_23taun > 0)
            { gamma_R23taun = fi_3n - Math.PI / 2; }
            else
            { gamma_R23taun = fi_3n + Math.PI / 2; };
            if (Y_S4n >= Y_Cn)
            { fi_CS4n = Math.Sign(Y_S4n - Y_Cn) * Math.Acos((X_S4n - X_Cn) / l_CS4); }
            else 
            { fi_CS4n = Math.Sign(Y_S4n - Y_Cn) * Math.Acos((X_S4n - X_Cn) / l_CS4) + 2*Math.PI; };
            R_14taun = -(M_4+M_FI4n+FI_4n*l_CS4*Math.Sin(gamma_FI4n-fi_CS4n)+G_4*(x_C2n-x_S42n))/l4;
            if (R_14taun > 0)
            { gamma_R14taun = fi_4n - Math.PI / 2; }
            else
            { gamma_R14taun = fi_4n + Math.PI / 2; };
            fi_G = 1.5 * Math.PI - theta;
            fi_44n = Math.PI - fi_4n;
            c_4n = R_14taun * Math.Cos(gamma_R14taun + fi_44n) + FI_4n * Math.Cos(gamma_FI4n + fi_44n) + (G_3 + G_4) * Math.Cos(fi_G + fi_44n) + FI_3n * Math.Cos(gamma_FI3n + fi_44n) + R_23taun * Math.Cos(gamma_R23taun + fi_44n);
            d_4n = R_14taun * Math.Cos(gamma_R14taun - fi_3n) + FI_4n * Math.Cos(gamma_FI4n - fi_3n) + (G_3 + G_4) * Math.Cos(fi_G - fi_3n) + FI_3n * Math.Cos(gamma_FI3n - fi_3n) + R_23taun * Math.Cos(gamma_R23taun - fi_3n);
            R_23nn = (c_4n*Math.Cos(fi_4n-fi_3n-Math.PI)-d_4n)/(1-Math.Cos(fi_3n+fi_44n)*Math.Cos(fi_4n-fi_3n-Math.PI));
            if (R_23nn > 0)
                { gamma_R23nn = fi_3n; }
            else
                { gamma_R23nn = fi_3n - Math.PI; };
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
            R_34yn = -(R_14n*Math.Sin(gamma_R14n)+FI_4n*Math.Sin(gamma_FI4n)+G_4*Math.Sin(fi_G));
            R_34xn = -(R_14n * Math.Cos(gamma_R14n) + FI_4n * Math.Cos(gamma_FI4n) + G_4 * Math.Cos(fi_G));
            R_34n = Math.Sqrt(R_34xn * R_34xn + R_34yn * R_34yn);
            if (R_34yn >= 0)
                { gamma_R34n = Math.Acos(R_34xn / R_34n); }
            else
                { gamma_R34n = -Math.Acos(R_34xn / R_34n)+2*Math.PI; };
            if (Y_S2n >= Y_A)
                { fi_AS2n = Math.Sign(Y_S2n - Y_A) * Math.Acos((X_S2n - X_A) / l_AS2); }
            else
                { fi_AS2n = Math.Sign(Y_S2n - Y_A) * Math.Acos((X_S2n - X_A) / l_AS2) + 2 * Math.PI; };
            if (Y_Cn >= Y_A)
                { fi_ACn = Math.Sign(Y_Cn - Y_A) * Math.Acos((X_Cn - X_A) / l2); }
            else
                { fi_ACn = Math.Sign(Y_Cn - Y_A) * Math.Acos((X_Cn - X_A) / l2) + 2 * Math.PI; };
            //
            fi_ACn = 2.45;//EDIT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //
            gamma_R32n = gamma_R23n + Math.PI;
            R_32n = R_23n;
            M_F2n = -(R_32n*l2*Math.Sin(gamma_R32n-fi_ACn)+FI_2n*l_AS2*Math.Sin(gamma_FI2n-fi_AS2n)+G_2*(x_A2n-x_S22n)+M_FI2n);
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
        l2 = 5.0;
        l3 = 15;
        l4 = 14;
        _X_D = 10;
        _Y_D = -4;
         l_AS2 = 2.5; l_CS3 = 7.5; l_CS4 = 7;
         m_4 = 3; m_2 = 1; m_3 = 2;
         _g = 10; a_S2n = 11.2; a_S3n = 14.3; a_S4n = 4;
         beta_S2n = 5.12; beta_S3n = 4.93; beta_S4n = 4.35;
         epsilon_2n = 2; epsilon_3n = 1.13; epsilon_4n = 0.214;
         _J_S2 = 0.01; _J_S3 = 2.0; _J_S4 = 3.0;
         X_S2n = -1.92; X_S3n = 2.84; X_S4n = 9.77; X_A = 0; X_Cn = 9.53;
         Y_S2n = 1.6; Y_S3n = 6.6; Y_S4n = 3.0; Y_A = 0; Y_Cn = 10;
         M_4 = -50;
         theta = 2.09;
         fi_2n = 2.45; fi_3n = 0.47; fi_4n = 1.6;
         r_omega = 5;
         alpha_omega = 0.349;
         CalculationForces();
        }
#endregion
        
        //public KinematikAnalys() { }
        private static bool isAdditionalPoint;
        public static void Add5Point(double l_BE, NumberPoints point_0)
        {
            MechanismAnalys.point_0 = point_0;
            l5 = l_BE;
            isAdditionalPoint = true;
        }
        private static double l5;
        private static NumberPoints point_0;
        
        
        private static void init_vars()
        {
            Fi_Sum = Math.Acos(((l2 + l3) * (l2 + l3) + l_AD * l_AD - l4 * l4) / (2 * (l2 + l3) * l_AD));
            Fi_0 = Math.Atan((_Y_D - Y_A) / (_X_D - X_A));
            if (direction_link4 == DirectionRotation.AgainClockWise)
                { Fi_0 = Math.PI * 2 - Fi_0; };
            Fi_10 = Fi_0 + Fi_Sum;
            if (calculation_mode > CalculationModes.CalcOnlyPlanePosition)
            { v_B = omega * l2; }
        }
        
        public static void CalculationPlanPosition(ref MechanismAnalys res, int n)
        {
            double L_BDn = new double();
            double Fi_BDn = new double();
            double delta_n = new double();
            res.fi_2n = Fi_10 + n * 2 * Math.PI / quantIteration;//значення узагальненої координати
            OperatorFunction.F2(X_A, Y_A, l2, res.fi_2n, ref res.X_Bn, ref res.Y_Bn);//знаходимо координати точки В
            OperatorFunction.F4(res.X_Bn, res.Y_Bn, _X_D, _Y_D, ref L_BDn);//знаходимо довжину відрізка ВD
            OperatorFunction.F3(res.X_Bn, res.Y_Bn, _X_D, _Y_D, L_BDn, ref Fi_BDn);//знаходимо кут BDn 
            delta_n = Math.Acos((l3 * l3 + L_BDn * L_BDn - l4 * l4) / (2 * l3 * L_BDn));//
            res.fi_3n = delta_n + Fi_BDn;
            OperatorFunction.F2(res.X_Bn, res.Y_Bn, l3, res.fi_3n, ref res.X_Cn, ref res.Y_Cn);
            OperatorFunction.F3(res.X_Cn, res.Y_Cn, _X_D, _Y_D, l4, ref res.fi_4n);
            OperatorFunction.F5(X_A, Y_A, res.X_Bn, res.Y_Bn, l_AS_2, l2 - l_AS_2, 1, ref res.X_S2n, ref res.Y_S2n);
            OperatorFunction.F5(res.X_Bn, res.Y_Bn, res.X_Cn, res.Y_Cn, l_BS_3, l3 - l_BS_3, 1, ref res.X_S3n, ref res.Y_S3n);
            OperatorFunction.F5(_X_D, _Y_D, res.X_Cn, res.Y_Cn, l_DS_4, l4 - l_DS_4, 1, ref res.X_S4n, ref res.Y_S4n);

            if (isAdditionalPoint)
            {
                if (point_0 == NumberPoints.B)
                {
                    OperatorFunction.F2(res.X_Bn, res.Y_Bn, l5, res.fi_3n, ref res.X_En, ref res.Y_En);
                }
                else if (point_0 == NumberPoints.C)
                {
                    OperatorFunction.F2(res.X_Cn, res.Y_Cn, l5, res.fi_3n+Math.PI, ref res.X_En, ref res.Y_En);
                }
            };
        }
        public static void CalculationPlanVelocity(ref MechanismAnalys res)
        {
            double x_BVn = new double();
            double y_BVn = new double();
            double x_CVn = new double();
            double y_CVn = new double();
            double v_CBn = new double();
            double X_S2Vn = new double();
            double Y_S2Vn = new double();
            double X_S3Vn = new double();
            double Y_S3Vn = new double();
            double X_S4Vn = new double();
            double Y_S4Vn = new double();
            res.alpha_2n = res.fi_2n + omegaDirect * Math.PI / 2;
            OperatorFunction.F2(X_P, Y_P, MechanismAnalys.v_B, res.alpha_2n, ref x_BVn, ref y_BVn);
            OperatorFunction.F1(x_BVn, y_BVn, res.fi_3n + Math.PI / 2, X_P, Y_P, res.fi_4n + Math.PI / 2, ref x_CVn, ref y_CVn);
            OperatorFunction.F4(X_P, Y_P, x_CVn, y_CVn, ref res.v_Cn);
            OperatorFunction.F4(x_BVn, y_BVn, x_CVn, y_CVn, ref v_CBn);
            OperatorFunction.F3(x_BVn, y_BVn, x_CVn, y_CVn, v_CBn, ref res.alpha_3n);
            OperatorFunction.F3(X_P, Y_P, x_CVn, y_CVn, res.v_Cn, ref res.alpha_4n);
            //Кутові швидкості ланок 3 і 4
            OperatorFunction.F6(v_CBn, l3, res.alpha_3n, res.fi_3n, ref res.omega_3n);
            OperatorFunction.F6(res.v_Cn, l4, res.alpha_4n, res.fi_4n, ref res.omega_4n);
            //Визначаємо швидкість точки S2
            OperatorFunction.F5(X_P, Y_P, x_BVn, y_BVn, l_AS_2, l2 - l_AS_2, 1, ref X_S2Vn, ref Y_S2Vn);
            OperatorFunction.F4(X_P, Y_P, X_S2Vn, Y_S2Vn, ref res.v_S2n);
            OperatorFunction.F3(X_P, Y_P, X_S2Vn, res.Y_S2n, res.v_S2n, ref res.alpha_S2n);
            //Визначаємо швидкість точки S3
            OperatorFunction.F5(x_BVn, y_BVn, x_CVn, y_CVn, l_BS_3, l3 - l_BS_3, 1, ref X_S3Vn, ref Y_S3Vn);
            OperatorFunction.F4(X_P, Y_P, X_S3Vn, Y_S3Vn, ref res.v_S3n);
            OperatorFunction.F3(X_P, Y_P, X_S3Vn, Y_S3Vn, res.v_S3n, ref res.alpha_S3n);
            //Визначаємо швидкість точки S4
            OperatorFunction.F5(X_P, Y_P, x_CVn, y_CVn, l_DS_4, l4 - l_DS_4, 1, ref X_S4Vn, ref Y_S4Vn);
            OperatorFunction.F4(X_P, Y_P, X_S4Vn, Y_S4Vn, ref res.v_S4n);
            OperatorFunction.F3(X_P, Y_P, X_S4Vn, Y_S4Vn, res.v_S4n, ref res.alpha_S4n);
        }
        private double X_pi,Y_pi,a_n2n, a_tau2n, beta_2nn, beta_tau2n, X_Ban, Y_Ban, a_n3n, beta_3nn, X_CB3n, Y_CB3n, a_n4n, beta_4nn, X_CB4n, Y_CB4n, X_Can, Y_Can, X_S2an, Y_S2an, X_S3an, Y_S3an, X_S4an, Y_S4an,  a_tau3n, beta_tau3n,  a_tau4n, beta_tau4n;
        
        public void CalculationAcceleration()
        {
            a_n2n = omega * omega * l2;
            a_tau2n = epsilon * l2;
            beta_2nn = fi_2n + Math.PI;
            beta_tau2n = fi_2n - epsilonDirect * Math.PI / 2;
            X_Ban = a_n2n * Math.Cos(beta_2nn) + a_tau2n * Math.Cos(beta_tau2n);
            Y_Ban = a_n2n * Math.Sin(beta_2nn) + a_tau2n * Math.Sin(beta_tau2n);
            OperatorFunction.F4(X_pi, Y_pi, X_Ban, Y_Ban, ref a_Bn);
            OperatorFunction.F3(X_pi, Y_pi, X_Ban, Y_Ban, a_Bn, ref beta_2nn);
            a_n3n = omega_3n * omega_3n * l3;
            beta_3nn = fi_3n + Math.PI;
            OperatorFunction.F2(X_Ban, Y_Ban, a_n3n, beta_3nn, ref X_CB3n, ref Y_CB3n);
            a_n4n=omega_4n*omega_4n*l4;
            beta_4nn=fi_4n+Math.PI;
            OperatorFunction.F2(X_pi, Y_pi, a_n4n, beta_4nn, ref X_CB4n, ref Y_CB4n);
            OperatorFunction.F1(X_CB3n, Y_CB3n, fi_3n + Math.PI / 2, X_CB4n, Y_CB4n, fi_4n + Math.PI / 2, ref X_Can, ref Y_Can);
            OperatorFunction.F4(X_pi, Y_pi, X_Can, Y_Can, ref a_Cn);
            OperatorFunction.F4(X_Ban, Y_Ban, X_Can, Y_Can, ref a_CBn);
            OperatorFunction.F5(X_pi, Y_pi, X_Ban, Y_Ban, l_AS_2, l2 - l_AS_2, 1, ref X_S2an, ref Y_S2an);
            OperatorFunction.F4(X_pi,Y_pi,X_S2an,Y_S2an, ref a_S2n);
            beta_S2n = beta_2n;
            //Визначаємо прискорення точки S4
            OperatorFunction.F5(X_Ban, Y_Ban, X_Can, Y_Can, l_BS_3, l3 - l_BS_3, 1, ref X_S3an, ref Y_S3an);
            OperatorFunction.F4(X_pi, Y_pi, X_S3an, Y_S3an, ref a_S3n);
            OperatorFunction.F3(X_pi, Y_pi, X_S3an, Y_S3an, a_S3n, ref beta_S3n);
            //Визначаємо прискорення точки S4
            OperatorFunction.F5(X_pi,Y_pi,X_Ban, Y_Ban,l_DS_4, l4-l_DS_4, 1, ref X_S4an, ref Y_S4an);
            OperatorFunction.F4(X_pi, Y_pi, X_S4an, Y_S4an, ref a_S4n);
            OperatorFunction.F3(X_pi, Y_pi, X_S4an, Y_S4an, a_S4n, ref beta_S4n);
            //Визначаємо кутове прискорення ланки 3
            OperatorFunction.F4(X_CB3n,Y_CB3n,X_Can,Y_Can, ref a_tau3n);
            OperatorFunction.F3(X_CB3n,Y_CB3n,X_Can,Y_Can, a_tau3n,ref beta_tau3n);
            OperatorFunction.F7(a_tau3n,l3,beta_tau3n,fi_3n,ref epsilon_3n);
            //Визначаємо кутове прискорення ланки 4
            OperatorFunction.F4(X_CB4n,Y_CB4n,X_Can,Y_Can, ref a_tau4n);
            OperatorFunction.F3(X_CB4n,Y_CB4n,X_Can,Y_Can, a_tau4n,ref beta_tau4n);
            OperatorFunction.F7(a_tau4n,l4,beta_tau4n,fi_4n,ref epsilon_4n);
        }
    }
}
