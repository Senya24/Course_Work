using System;

namespace Kursova.Model
{
    public class Inequality
    {
        public int A, B, C;
        public double NormalFormC;
        public string Operator;
        public string NormalFormOperator { get; private set; }
        public Range Range { get; private set; }

        public Inequality(int a, int b, string Operator, int c)
        {
            A = a;
            B = b;
            C = c;
            this.Operator = Operator;
            NormalFormC = Math.Round(((double)(C - B) / A), 3);
            NormalFormOperator = A > 0 ? Operator : (Operator[0] == '>' ? "<" : ">") + (Operator.Length == 2 ? "=" : "");
            SetRange();
        }

        public override string ToString()
        {
            return "" + (A == 1 ? "" : A == -1 ? "-" : A)+"x"+(B>0?"+"+B:B<0?B:"") + Operator + C;
        }

        public void SetRange()
        {
            bool boundaryIsIncluded = NormalFormOperator.Length == 2;
            if (NormalFormOperator[0] == '>') Range = new(NormalFormC, null, boundaryIsIncluded);
            else Range = new(null, NormalFormC, false, boundaryIsIncluded);
        }
    }
}