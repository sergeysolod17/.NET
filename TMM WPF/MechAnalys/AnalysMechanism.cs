using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMM_Analys
{
    public class MechanismAnalys
    {
        
#region InputData
        public static double L_AB
        {
            get { return l2; }
            set { if (value > 0) l2 = value; else { throw new ExceptionIllegaValue("L_AB"); } }
        }
        public static double L_BC
        {
            get { return l3; }
            set { if (value > 0) l3 = value; else { throw new ExceptionIllegaValue("L_BC"); } }
        }
        public static double L_CD
        {
            get { return l4; }
            set { if (value > 0) l4 = value; else { throw new ExceptionIllegaValue("L_CD"); };}
        }
        public static double L_AD
        {
            get { return l_AD; }
            set { l_AD = value; if (_Y_D == 0) { _X_D = l_AD; } }
        }
        public static double L_BE
        {
            get { return l5; }
            set
            {
                if (value > 0) l5 = value; else throw new ExceptionIllegaValue("L_BE");
                isAdditionalPoint = true; if (point_0 == null) point_0 = NumberPoints.B;
            }
        }
        public static double L_AS2
        {
            get { return l_AS_2; }
            set { if ((value > 0) && (value < l2)) l_AS_2 = value; else { throw new ExceptionIllegaValue("L_AS2"); } }
        }
        public static double L_BS3
        {
            get { return l_BS_3; }
            set { l_BS_3 = value; }
        }
        public static double L_DS4
        {
            get { return l_DS_4; }
            set { if ((value > 0) && (value < l4)) l_DS_4 = value; else { throw new ExceptionIllegaValue("L_DS4"); } }
        }
        public static double Omega
        {
            get { return omega; }
            set { omega = value; if (omegaDirect == null) omegaDirect = (value >= 0) ? -1 : 1; else if (value < 0) omegaDirect = -omegaDirect; }
        }
        public static double Epsilon
        {
            get { return epsilon; }
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
            get { if (_J_S2 == 0) { return m_2 * l2 * l2 / 12; } else return _J_S2; }
            set { if (value > 0) _J_S2 = value; else { throw new ExceptionIllegaValue("момент інерції ланки 2"); } }
        }
        public static double J_S3
        {
            get { if (_J_S3 == 0) { return m_3 * l3 * l3 / 12; } else return _J_S3; }
            set { if (value > 0) _J_S3 = value; else { throw new ExceptionIllegaValue("момент інерції ланки 3"); } }
        }
        public static double J_S4
        {
            get { if (_J_S4 == 0) { return m_4 * l4 * l4 / 12; } else return _J_S4; }
            set { if (value > 0) _J_S4 = value; else { throw new ExceptionIllegaValue("момент інерції ланки 4"); } }
        }
        public static double Moment4
        {
            get { return M_4; }
            set { M_4 = value; }
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
        public static double X_A, Y_A, X_P, Y_P, X_pi, Y_pi;
        public static double X_D { get { return _X_D; } set { _X_D = value; } }
        public static double Y_D { get { return _Y_D; } set { _X_D = value; } }
        public static int QuantIteration
        {
            get { return quantIteration; }
            set { if ((value > 0) && (value < 1000))  quantIteration = value; else throw new ExceptionIllegaValue("кількість положень механізму"); }
        }
        public static CalculationModes CalculationMode
        {
            get { return calculation_mode; }
            set { calculation_mode = value; }
        }
        public static NumberPoints PointBeginBE
        {
            get { return point_0; }
            set { point_0 = value; }
        }
        public static int OmegaDirection
        {
            get { return omegaDirect; }
            set { omegaDirect = value; }
        }
        public static int EpsilonDirection
        {
            get { return epsilonDirect; }
            set { epsilonDirect = value; }
        }
        public static bool IsAdditionalPoint { get { return isAdditionalPoint; } }
        public double MomentInertia { get{return calc_moment_inertia();} }
        public double Moment { get { return calc_moment(); } }
        public double G2 { get { return m_2 * _g; } }
        public double G3 { get { return m_3 * _g; } }
        public double G4 { get { return m_4 * _g; } }
        public static bool IsInitialise { get { return isInitialise; } set { isInitialise = value; } } 
        public double theta;
        public double r_omega;
        public double alpha_omega;
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
            public double  X_Bn, Y_Bn,  X_Cn, Y_Cn,  X_S2n, Y_S2n, X_S3n, Y_S3n, X_S4n, Y_S4n,X_En, Y_En;//output data of position analys
            
        }
        public struct PlanVelositiesParameters
        {
            public double x_BVn, y_BVn, x_CVn, y_CVn, v_CBn, X_S2Vn, Y_S2Vn, X_S3Vn, Y_S3Vn, X_S4Vn, Y_S4Vn, X_EVn, Y_EVn;
        }
        public struct PlanAccelerationsParameters
        {
            public double a_n2n, a_tau2n, beta_2nn, beta_tau2n, X_Ban, Y_Ban, a_n3n, beta_3nn;
            public double X_CB3n, Y_CB3n, a_n4n, beta_4nn,X_CB4n, Y_CB4n, X_Can, Y_Can, X_S2an, Y_S2an, X_S3an;
            public double  Y_S3an, X_S4an, Y_S4an, a_tau3n, beta_tau3n, a_tau4n, beta_tau4n, X_Ean, Y_Ean;
        }
        public struct PlanForcesParameters
        {            
            public double x_S22n, x_S32n, x_S42n, x_C2n, x_A2n;
            public double fi_CS3n, R_23taun, gamma_R23taun, fi_CS4n, R_14taun, gamma_R14taun, fi_G, fi_44n;
            public double c_4n, d_4n, R_23nn, gamma_R23nn, R_14nn, gamma_R14nn,R_23xn, R_23yn,   R_14xn, R_14yn;
            public double R_34yn, R_34xn,   fi_AS2n, fi_ACn,  R_32n,  M_F2n, R_12xn, R_12yn;
        }
        public enum NumberPoints : byte
        {
            A = 0,
            B = 1,
            C = 2,
            D = 3,
            E = 4
        }
        public enum DirectionRotation : int
        {
            OnClockWise = 1,
            AgainClockWise = -1
        }
        public class ExceptionIllegaValue : Exception
        {
            public string NameParameter;
            public ExceptionIllegaValue(string str) { NameParameter = str; }
        };
#region OutputData
        public double fi_2n, fi_3n, fi_4n;
        public double v_Bn, alpha_2n, v_Cn, alpha_3n, alpha_4n, omega_3n, omega_4n, v_S2n, alpha_S2n, v_S3n, alpha_S3n, v_S4n, alpha_S4n, v_En,alpha_En; 
        public double a_Bn, beta_2n, a_Cn, a_CBn, a_S2n, beta_S2n, a_S3n, beta_S3n, a_S4n, beta_S4n, epsilon_3n, epsilon_4n, a_Ean, beta_Ean; 
        public double G_2, G_3, G_4, M_FI3n, M_FI4n;
        public double FI_2n, FI_3n, FI_4n, gamma_FI2n, gamma_FI3n, gamma_FI4n, M_FI2n;
        public double R_23n, R_14n, R_34n, F_2n, R_12n, gamma_R23n, gamma_R14n, gamma_R34n, gamma_R32n,gamma_F2n, gamma_R12n;
        public int NumberPosition;
        public double omega_2n;
        private static double omega, epsilon;
#endregion
#region inside_vars     
        private static double M_4, _g;
        private static double _J_S2, _J_S3, _J_S4, m_4, m_2, m_3;
        private double l_CS4 { get { return (l4 - l_DS_4); } }
        private double l_CS3 { get { return (l3 - l_BS_3); } }
        private static double l2, l3, l4, l5, l_AD, l_AS_2, l_BS_3, l_DS_4;
        private static double  _X_D, _Y_D, v_B;
        private static DirectionRotation direction_link4;
        private static int quantIteration;
        private static double Fi_Sum, Fi_0, Fi_10;
        private static bool isInitialise;
        private static CalculationModes calculation_mode;
        private static NumberPoints point_0;
        private static bool isAdditionalPoint;
        private static int omegaDirect, epsilonDirect;
#endregion        
#region CalculationFunctions
        public void Calculation(int n)
        {
            if (!isInitialise)
                { init_vars(); }
            NumberPosition = n;
            PlanPositionParameters res_position = new PlanPositionParameters();
            PlanVelositiesParameters res_velocity;
            PlanAccelerationsParameters res_acceleration;
            PlanForcesParameters res_forces;
            CalculationPlanPosition(ref res_position, n);
            if (calculation_mode > CalculationModes.CalcOnlyPlanePosition)
            {
                res_velocity = new PlanVelositiesParameters();
                CalculationVelocities( ref res_position, ref res_velocity);
            }
            if (calculation_mode > CalculationModes.CalcVelocities)
            {
                res_acceleration = new PlanAccelerationsParameters();
                CalculationAcceleration(ref res_acceleration);
            }
            if (calculation_mode > CalculationModes.CalcAcceleration)
            {
                res_forces = new PlanForcesParameters();
                CalculationForces(ref res_position, ref res_forces);
            }
        }
        public void CalculationPlanPosition(ref PlanPositionParameters res, int n)
        {
            double L_BDn = new double();
            double Fi_BDn = new double();
            double delta_n = new double();
            fi_2n = Fi_10 + n * 2 * Math.PI / quantIteration;//значення узагальненої координати
            OperatorFunction.F2(X_A, Y_A, l2, fi_2n, ref res.X_Bn, ref res.Y_Bn);//знаходимо координати точки В
            OperatorFunction.F4(res.X_Bn, res.Y_Bn, _X_D, _Y_D, ref L_BDn);//знаходимо довжину відрізка ВD
            OperatorFunction.F3(res.X_Bn, res.Y_Bn, _X_D, _Y_D, L_BDn, ref Fi_BDn);//знаходимо кут BDn 
            delta_n = Math.Acos(((l3 * l3 + L_BDn * L_BDn - l4 * l4) / (2 * l3 * L_BDn)));//
            fi_3n = Fi_BDn+ ((direction_link4 == DirectionRotation.AgainClockWise) ? (-delta_n) : (delta_n));
            OperatorFunction.F2(res.X_Bn, res.Y_Bn, l3, fi_3n, ref res.X_Cn, ref res.Y_Cn);
            OperatorFunction.F3(res.X_Cn, res.Y_Cn, _X_D, _Y_D, l4, ref fi_4n);
            OperatorFunction.F5(X_A, Y_A, res.X_Bn, res.Y_Bn, l_AS_2, l2 - l_AS_2, 1, ref res.X_S2n, ref res.Y_S2n);
            OperatorFunction.F5(res.X_Bn, res.Y_Bn, res.X_Cn, res.Y_Cn, l_BS_3, l3 - l_BS_3, 1, ref res.X_S3n, ref res.Y_S3n);
            OperatorFunction.F5(_X_D, _Y_D, res.X_Cn, res.Y_Cn, l_DS_4, l4 - l_DS_4, 1, ref res.X_S4n, ref res.Y_S4n);
            if (isAdditionalPoint)
                if (point_0 == NumberPoints.B)
                    OperatorFunction.F2(res.X_Bn, res.Y_Bn, l5, fi_3n+Math.PI, ref res.X_En, ref res.Y_En);
                else if (point_0 == NumberPoints.C)
                    OperatorFunction.F2(res.X_Cn, res.Y_Cn, l5, fi_3n, ref res.X_En, ref res.Y_En);
        }
        public void CalculationVelocities(ref PlanPositionParameters input, ref PlanVelositiesParameters res)
        {
            if (epsilon == 0)
            {
                omega_2n = omega;
                
            }
            v_Bn = omega_2n * l2;


            alpha_2n = fi_2n + omegaDirect * Math.PI / 2;


res.x_BVn = X_P + v_B * Math.Cos(alpha_2n);
res.y_BVn = Y_P + v_B * Math.Sin(alpha_2n);
double k3n = Math.Tan(fi_3n + Math.PI / 2);
double k4n = Math.Tan(fi_4n + Math.PI / 2);
res.x_CVn = (k3n * res.x_BVn - res.y_BVn - k4n * X_P + Y_P) / (k3n - k4n);
res.y_CVn = k3n * (res.x_CVn - res.x_BVn) + res.y_BVn;
v_Cn = Math.Sqrt((res.x_CVn - X_P) * (res.x_CVn - X_P) + (res.y_CVn - Y_P) * (res.y_CVn - Y_P));

            OperatorFunction.F2(X_P, Y_P, v_Bn, alpha_2n, ref res.x_BVn, ref res.y_BVn);
            OperatorFunction.F1(res.x_BVn, res.y_BVn, fi_3n + Math.PI / 2, X_P, Y_P, fi_4n + Math.PI / 2, ref res.x_CVn, ref res.y_CVn);
            OperatorFunction.F4(X_P, Y_P, res.x_CVn, res.y_CVn, ref v_Cn);
            OperatorFunction.F4(res.x_BVn, res.y_BVn, res.x_CVn, res.y_CVn, ref res.v_CBn);
            OperatorFunction.F3(res.x_BVn, res.y_BVn, res.x_CVn, res.y_CVn, res.v_CBn, ref alpha_3n);
            OperatorFunction.F3(X_P, Y_P, res.x_CVn, res.y_CVn, v_Cn, ref alpha_4n);
            //Кутові швидкості ланок 3 і 4
            OperatorFunction.F6(res.v_CBn, l3, alpha_3n, fi_3n, ref omega_3n);
            OperatorFunction.F6(v_Cn, l4, alpha_4n, fi_4n, ref omega_4n);
            //Визначаємо швидкість точки S2
            OperatorFunction.F5(X_P, Y_P, res.x_BVn, res.y_BVn, l_AS_2, l2 - l_AS_2, 1, ref res.X_S2Vn, ref res.Y_S2Vn);
            OperatorFunction.F4(X_P, Y_P, res.X_S2Vn, res.Y_S2Vn, ref v_S2n);
            OperatorFunction.F3(X_P, Y_P, res.X_S2Vn, input.Y_S2n, v_S2n, ref alpha_S2n);
            //Визначаємо швидкість точки S3
            OperatorFunction.F5(res.x_BVn, res.y_BVn, res.x_CVn, res.y_CVn, l_BS_3, l3 - l_BS_3, 1, ref res.X_S3Vn, ref res.Y_S3Vn);
            OperatorFunction.F4(X_P, Y_P, res.X_S3Vn, res.Y_S3Vn, ref v_S3n);
            OperatorFunction.F3(X_P, Y_P, res.X_S3Vn, res.Y_S3Vn, v_S3n, ref alpha_S3n);
            //Визначаємо швидкість точки S4
            OperatorFunction.F5(X_P, Y_P, res.x_CVn, res.y_CVn, l_DS_4, l4 - l_DS_4, 1, ref res.X_S4Vn, ref res.Y_S4Vn);
            OperatorFunction.F4(X_P, Y_P, res.X_S4Vn, res.Y_S4Vn, ref v_S4n);
            OperatorFunction.F3(X_P, Y_P, res.X_S4Vn, res.Y_S4Vn, v_S4n, ref alpha_S4n);
            //Визначаємо швидкість точки E
            if (isAdditionalPoint)            
                if (point_0 == NumberPoints.B)
                {
                    OperatorFunction.F5(input.X_Cn, input.Y_Cn, input.X_Bn, input.Y_Bn, l3+l5, l3, -1, ref res.X_EVn, ref res.Y_EVn);
                    OperatorFunction.F4(X_P, Y_P, res.X_EVn, res.Y_EVn, ref v_En);
                    OperatorFunction.F3(X_P, Y_P, res.X_EVn, res.Y_EVn, v_En, ref alpha_En);
                }
                else if (point_0 == NumberPoints.C)
                {
                    OperatorFunction.F5(input.X_Bn, input.Y_Bn, input.X_Cn, input.Y_Cn, l3 + l5, l3, -1, ref res.X_EVn, ref res.Y_EVn);
                    OperatorFunction.F4(X_P, Y_P, res.X_EVn, res.Y_EVn, ref v_En);
                    OperatorFunction.F3(X_P, Y_P, res.X_EVn, res.Y_EVn, v_En, ref alpha_En);
                }            
        }
        public void CalculationAcceleration(ref PlanAccelerationsParameters res)
        {
            res.a_n2n = omega * omega * l2;
            res.a_tau2n = epsilon * l2;
            res.beta_2nn = fi_2n + Math.PI;
            res.beta_tau2n = fi_2n - epsilonDirect * Math.PI / 2;
            res.X_Ban = res.a_n2n * Math.Cos(res.beta_2nn) + res.a_tau2n * Math.Cos(res.beta_tau2n);
            res.Y_Ban = res.a_n2n * Math.Sin(res.beta_2nn) + res.a_tau2n * Math.Sin(res.beta_tau2n);
            OperatorFunction.F4(X_pi, Y_pi, res.X_Ban, res.Y_Ban, ref a_Bn);
            OperatorFunction.F3(X_pi, Y_pi, res.X_Ban, res.Y_Ban, a_Bn, ref res.beta_2nn);
            res.a_n3n = omega_3n * omega_3n * l3;
            res.beta_3nn = fi_3n + Math.PI;
            OperatorFunction.F2(res.X_Ban, res.Y_Ban, res.a_n3n, res.beta_3nn, ref res.X_CB3n, ref res.Y_CB3n);
            res.a_n4n = omega_4n * omega_4n * l4;
            res.beta_4nn = fi_4n + Math.PI;
            OperatorFunction.F2(X_pi, Y_pi, res.a_n4n, res.beta_4nn, ref res.X_CB4n, ref res.Y_CB4n);
            OperatorFunction.F1(res.X_CB3n, res.Y_CB3n, fi_3n + Math.PI / 2, res.X_CB4n, res.Y_CB4n, fi_4n + Math.PI / 2, ref res.X_Can, ref res.Y_Can);
            OperatorFunction.F4(X_pi, Y_pi, res.X_Can, res.Y_Can, ref a_Cn);
            OperatorFunction.F4(res.X_Ban, res.Y_Ban, res.X_Can, res.Y_Can, ref a_CBn);
            OperatorFunction.F5(X_pi, Y_pi, res.X_Ban, res.Y_Ban, l_AS_2, l2 - l_AS_2, 1, ref res.X_S2an, ref res.Y_S2an);
            OperatorFunction.F4(X_pi, Y_pi, res.X_S2an, res.Y_S2an, ref a_S2n);
            beta_S2n = beta_2n;
            //Визначаємо прискорення точки S4
            OperatorFunction.F5(res.X_Ban, res.Y_Ban, res.X_Can, res.Y_Can, l_BS_3, l3 - l_BS_3, 1, ref res.X_S3an, ref res.Y_S3an);
            OperatorFunction.F4(X_pi, Y_pi, res.X_S3an, res.Y_S3an, ref a_S3n);
            OperatorFunction.F3(X_pi, Y_pi, res.X_S3an, res.Y_S3an, a_S3n, ref beta_S3n);
            //Визначаємо прискорення точки S4
            OperatorFunction.F5(X_pi, Y_pi, res.X_Ban, res.Y_Ban, l_DS_4, l4 - l_DS_4, 1, ref res.X_S4an, ref res.Y_S4an);
            OperatorFunction.F4(X_pi, Y_pi, res.X_S4an, res.Y_S4an, ref a_S4n);
            OperatorFunction.F3(X_pi, Y_pi, res.X_S4an, res.Y_S4an, a_S4n, ref beta_S4n);
            //Визначаємо кутове прискорення ланки 3
            OperatorFunction.F4(res.X_CB3n, res.Y_CB3n, res.X_Can, res.Y_Can, ref res.a_tau3n);
            OperatorFunction.F3(res.X_CB3n, res.Y_CB3n, res.X_Can, res.Y_Can, res.a_tau3n, ref res.beta_tau3n);
            OperatorFunction.F7(res.a_tau3n, l3, res.beta_tau3n, fi_3n, ref epsilon_3n);
            //Визначаємо кутове прискорення ланки 4
            OperatorFunction.F4(res.X_CB4n, res.Y_CB4n, res.X_Can, res.Y_Can, ref res.a_tau4n);
            OperatorFunction.F3(res.X_CB4n, res.Y_CB4n, res.X_Can, res.Y_Can, res.a_tau4n, ref res.beta_tau4n);
            OperatorFunction.F7(res.a_tau4n, l4, res.beta_tau4n, fi_4n, ref epsilon_4n);
            //Визначаємо прискорення точки Е
            if (isAdditionalPoint)
                if (point_0 == NumberPoints.B)
                {
                    OperatorFunction.F5(res.X_Can, res.Y_Can, res.X_Ban, res.Y_Ban, l5+l3, l3, -1, ref res.X_Ean, ref res.Y_Ean);
                    OperatorFunction.F4(X_pi, Y_pi, res.X_Ean, res.Y_Ean, ref a_Ean);
                    OperatorFunction.F3(X_pi, Y_pi, res.X_Ean, res.Y_Ean, a_Ean, ref beta_Ean);
                }
                else if (point_0 == NumberPoints.C)
                {
                    OperatorFunction.F5(res.X_Ban, res.Y_Ban, res.X_Can, res.Y_Can, l5 + l3, l3, -1, ref res.X_Ean, ref res.Y_Ean);
                    OperatorFunction.F4(X_pi, Y_pi, res.X_Ean, res.Y_Ean, ref a_Ean);
                    OperatorFunction.F3(X_pi, Y_pi, res.X_Ean, res.Y_Ean, a_Ean, ref beta_Ean);
                } 
        }
        public void CalculationForces(ref PlanPositionParameters plan_position, ref PlanForcesParameters res)
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
            M_FI2n = -_J_S2 * epsilon;
            M_FI3n = -_J_S3 * epsilon_3n;
            M_FI4n = -_J_S4 * epsilon_4n;
            res.x_S22n = plan_position.X_S2n * Math.Cos(theta) - plan_position.Y_S2n * Math.Sin(theta);
            res.x_S32n = plan_position.X_S3n * Math.Cos(theta) - plan_position.Y_S3n * Math.Sin(theta);
            res.x_S42n = plan_position.X_S4n * Math.Cos(theta) - plan_position.Y_S4n * Math.Sin(theta);
            res.x_C2n = plan_position.X_Cn * Math.Cos(theta) - plan_position.Y_Cn * Math.Sin(theta);
            res.x_A2n = X_A * Math.Cos(theta) - Y_A * Math.Sin(theta);
            if (plan_position.Y_S3n >= plan_position.Y_Cn)
            { res.fi_CS3n = Math.Sign(plan_position.Y_S2n - plan_position.Y_Cn) * Math.Acos((plan_position.X_S3n - plan_position.X_Cn) / l_CS3); }
            else
            { res.fi_CS3n = Math.Sign(plan_position.Y_S2n - plan_position.Y_Cn) * Math.Acos((plan_position.X_S3n - plan_position.X_Cn) / l_CS3) + 2 * Math.PI; };
            res.R_23taun = -(M_FI3n + FI_3n * l_CS3 * Math.Sin(gamma_FI3n - res.fi_CS3n) + G_3 * (res.x_C2n - res.x_S32n)) / l3;
            if(res.R_23taun > 0)
            { res.gamma_R23taun = fi_3n - Math.PI / 2; }
            else
            { res.gamma_R23taun = fi_3n + Math.PI / 2; };
            if (plan_position.Y_S4n >= plan_position.Y_Cn)
            { res.fi_CS4n = Math.Sign(plan_position.Y_S4n - plan_position.Y_Cn) * Math.Acos((plan_position.X_S4n - plan_position.X_Cn) / l_CS4); }
            else
            { res.fi_CS4n = Math.Sign(plan_position.Y_S4n - plan_position.Y_Cn) * Math.Acos((plan_position.X_S4n - plan_position.X_Cn) / l_CS4) + 2 * Math.PI; };
            res.R_14taun = -(M_4 + M_FI4n + FI_4n * l_CS4 * Math.Sin(gamma_FI4n - res.fi_CS4n) + G_4 * (res.x_C2n - res.x_S42n)) / l4;
            if (res.R_14taun > 0)
            { res.gamma_R14taun = fi_4n - Math.PI / 2; }
            else
            { res.gamma_R14taun = fi_4n + Math.PI / 2; };
            res.fi_G = 1.5 * Math.PI - theta;
            res.fi_44n = Math.PI - fi_4n;
            res.c_4n = res.R_14taun * Math.Cos(res.gamma_R14taun + res.fi_44n) + FI_4n * Math.Cos(gamma_FI4n + res.fi_44n) + (G_3 + G_4) * Math.Cos(res.fi_G + res.fi_44n) + FI_3n * Math.Cos(gamma_FI3n + res.fi_44n) + res.R_23taun * Math.Cos(res.gamma_R23taun + res.fi_44n);
            res.d_4n = res.R_14taun * Math.Cos(res.gamma_R14taun - fi_3n) + FI_4n * Math.Cos(gamma_FI4n - fi_3n) + (G_3 + G_4) * Math.Cos(res.fi_G - fi_3n) + FI_3n * Math.Cos(gamma_FI3n - fi_3n) + res.R_23taun * Math.Cos(res.gamma_R23taun - fi_3n);
            res.R_23nn = (res.c_4n * Math.Cos(fi_4n - fi_3n - Math.PI) - res.d_4n) / (1 - Math.Cos(fi_3n + res.fi_44n) * Math.Cos(fi_4n - fi_3n - Math.PI));
            if (res.R_23nn > 0)
            { res.gamma_R23nn = fi_3n; }
            else
            { res.gamma_R23nn = fi_3n - Math.PI; };
            res.R_14nn = -(res.c_4n + res.R_23nn * Math.Cos(fi_3n + res.fi_44n));
            if (res.R_14nn > 0)
            { res.gamma_R14nn = fi_4n - Math.PI; }
            else
            { res.gamma_R14nn = fi_4n; };
            R_23n = Math.Sqrt(res.R_23taun * res.R_23taun + res.R_23nn * res.R_23nn);
            res.R_23xn = res.R_23nn * Math.Cos(res.gamma_R23nn) + res.R_23taun * Math.Cos(res.gamma_R23taun);
            res.R_23yn = res.R_23nn * Math.Sin(res.gamma_R23nn) + res.R_23taun * Math.Sin(res.gamma_R23taun);
            if (res.R_23yn >= 0)
            { gamma_R23n = Math.Acos(res.R_23xn / R_23n); }
            else
            { gamma_R23n = -Math.Acos(res.R_23xn / R_23n) + 2 * Math.PI; };
            R_14n = Math.Sqrt(res.R_14taun * res.R_14taun + res.R_14nn * res.R_14nn);
            res.R_14xn = res.R_14nn * Math.Cos(res.gamma_R14nn) + res.R_14taun * Math.Cos(res.gamma_R14taun);
            res.R_14yn = res.R_14nn * Math.Sin(res.gamma_R14nn) + res.R_14taun * Math.Sin(res.gamma_R14taun);
            if (res.R_14yn >= 0)
            { gamma_R14n = Math.Acos(res.R_14xn / R_14n); }
            else
            { gamma_R14n = -Math.Acos(res.R_14xn / R_14n) + 2 * Math.PI; };
            res.R_34yn = -(R_14n * Math.Sin(gamma_R14n) + FI_4n * Math.Sin(gamma_FI4n) + G_4 * Math.Sin(res.fi_G));
            res.R_34xn = -(R_14n * Math.Cos(gamma_R14n) + FI_4n * Math.Cos(gamma_FI4n) + G_4 * Math.Cos(res.fi_G));
            R_34n = Math.Sqrt(res.R_34xn * res.R_34xn + res.R_34yn * res.R_34yn);
            if (res.R_34yn >= 0)
            { gamma_R34n = Math.Acos(res.R_34xn / R_34n); }
            else
            { gamma_R34n = -Math.Acos(res.R_34xn / R_34n) + 2 * Math.PI; };
            if (plan_position.Y_S2n >= Y_A)
            { res.fi_AS2n = Math.Sign(plan_position.Y_S2n - Y_A) * Math.Acos((plan_position.X_S2n - X_A) / l_AS_2); }
            else
            { res.fi_AS2n = Math.Sign(plan_position.Y_S2n - Y_A) * Math.Acos((plan_position.X_S2n - X_A) / l_AS_2) + 2 * Math.PI; };
            if (plan_position.Y_Cn >= Y_A)
            { res.fi_ACn = Math.Sign(plan_position.Y_Cn - Y_A) * Math.Acos((plan_position.X_Cn - X_A) / l2); }
            else
            { res.fi_ACn = Math.Sign(plan_position.Y_Cn - Y_A) * Math.Acos((plan_position.X_Cn - X_A) / l2) + 2 * Math.PI; };
            //
            res.fi_ACn = 2.45;//EDIT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //
            gamma_R32n = gamma_R23n + Math.PI;
            res.R_32n = R_23n;
            res.M_F2n = -(res.R_32n * l2 * Math.Sin(gamma_R32n - res.fi_ACn) + FI_2n * l_AS_2 * Math.Sin(gamma_FI2n - res.fi_AS2n) + G_2 * (res.x_A2n - res.x_S22n) + M_FI2n);
            F_2n = Math.Abs(res.M_F2n / (r_omega * Math.Cos(alpha_omega)));
            if (res.M_F2n > 0)
                { gamma_F2n = -alpha_omega; }
            else
                { gamma_F2n = Math.PI - alpha_omega; };
            res.R_12xn = -(res.R_32n * Math.Cos(gamma_R32n) + G_2 * Math.Cos(res.fi_G) + FI_2n * Math.Cos(gamma_FI2n) + F_2n * Math.Cos(gamma_F2n));
            res.R_12yn = -(res.R_32n * Math.Sin(gamma_R32n) + G_2 * Math.Sin(res.fi_G) + FI_2n * Math.Sin(gamma_FI2n) + F_2n * Math.Sin(gamma_F2n));
            R_12n = Math.Sqrt(res.R_12xn * res.R_12xn + res.R_12yn * res.R_12yn);
            if (res.R_12yn >= 0)
            { gamma_R12n = Math.Acos(res.R_12xn / R_12n); }
            else
            { gamma_R12n = -Math.Acos(res.R_12xn / R_12n) + 2 * Math.PI; };
        }    
#endregion
#region additional_private_functions
        private static void init_vars()
        {
            Fi_Sum = Math.Acos(((l2 + l3) * (l2 + l3) + l_AD * l_AD - l4 * l4) / (2 * (l2 + l3) * l_AD));
            Fi_0 = Math.Atan((_Y_D - Y_A) / (_X_D - X_A));
            /*if (direction_link4 == DirectionRotation.AgainClockWise)
                { Fi_Sum = 2*Math.PI  - Fi_Sum; }*/
            if (direction_link4 == DirectionRotation.AgainClockWise)
            { Fi_Sum = -Fi_Sum; }
            Fi_10 = Fi_0 + Fi_Sum;
            
            
            isInitialise = true;
        }
        private double calc_moment_inertia()
        {
 	        double res=J_S2+(1/(omega*omega))*(m_2*v_S2n*v_S2n+J_S3*omega_3n*omega_3n+m_3*v_S3n*v_S3n+J_S4*omega_4n*omega_4n+m_4*v_S4n*v_S4n);
            return res;
        }
        private double calc_moment()
        {
            double res = (1 / (omega * omega)) * (G2 * v_S2n * Math.Cos(get_angle(alpha_2n)) + G3 * v_S3n * Math.Cos(get_angle(alpha_3n)) + G4 * v_S4n * Math.Cos(get_angle(alpha_4n)));
            return res;
        }
        private double get_angle(double alpha)
        {
            if(alpha >= 0)
               while (alpha > 2 * Math.PI)
                    { alpha -= 2 * Math.PI; }
            else
                while (alpha < -2 * Math.PI)
                { alpha += 2 * Math.PI; }
            return (alpha_2n <= Math.PI) ? (alpha_2n + Math.PI / 2) : (3 * Math.PI / 2 - alpha_2n);
        }
#endregion
    }
}
