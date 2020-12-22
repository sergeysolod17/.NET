using System;
public class OperatorFunction
{
    public static void F1(double x_a, double y_a, double fi_a, double x_b, double y_b, double fi_b, ref double x_c, ref double y_c)
    {
        x_c = (x_a * Math.Tan(fi_a) - y_a - x_b * Math.Tan(fi_b) + y_b) / (Math.Tan(fi_a) - Math.Tan(fi_b));
        y_c = (x_c - x_a) * Math.Tan(fi_a) + y_a;
    }
    public static void F2(double x_a, double y_a, double AB, double fi_AB, ref double x_b, ref double y_b)
    {
        x_b = x_a + AB * Math.Cos(fi_AB);
        y_b = y_a + AB * Math.Sin(fi_AB);
    }
    public static void F3(double x_a, double y_a, double x_b, double y_b, double AB, ref double fi_AB)
    {
        fi_AB = Math.Sign(y_b - y_a) * Math.Acos((x_b - x_a) / AB);
        if (y_b < y_a)
            { fi_AB += 2 * Math.PI; }
    }
    public static void F4(double x_a, double y_a, double x_b, double y_b, ref double AB)
    {
        AB = Math.Sqrt((x_a - x_b) * (x_a - x_b) + (y_b - y_a) * (y_b - y_a));
    }
    public static void F5(double x_a, double y_a, double x_b, double y_b, double AC, double BC, int i, ref double x_c, ref double y_c)
    {
        x_c = (x_a + i * x_b * AC / BC) / (1 + i * AC / BC);
        y_c = (y_a + i * y_b * AC / BC) / (1 + i * AC / BC);
    }
    public static void F6(double v_BA, double AB, double alpha_BA, double fi_AB, ref double omega)
    {
        omega = Math.Sin(alpha_BA - fi_AB) * v_BA / AB;
    }
    public static void F7(double atau_BA, double AB, double beta_BA, double fi_AB, ref double epsilon)
    {
        epsilon = Math.Sin(beta_BA - fi_AB) * atau_BA / AB;
    }
}