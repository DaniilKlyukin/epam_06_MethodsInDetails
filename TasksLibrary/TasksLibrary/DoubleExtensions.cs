using System.Linq;
using System.Runtime.InteropServices;

namespace TasksLibrary
{
    public static class DoubleExtensions
    {
        private const int BitsCount = 64;

        /// <summary>
        /// Сonverts a real number into binary form.
        /// </summary>
        /// <returns>String representation of a binary number.</returns>
        public static string ToIEEE754(this double inputNumber)
        {
            var bits = new bool[BitsCount];
            var ch64 = new ConvertHelper();

            ch64.DoubleForm = inputNumber;
            var dataPointer = ch64.LongForm;

            for (int i = 1; i <= BitsCount; i++, dataPointer >>= 1)
                bits[BitsCount - i] = (dataPointer % 2) != 0;

            return string.Join(string.Empty, bits.Select(x => x ? "1" : "0"));
        }

        [StructLayout(LayoutKind.Explicit, Size = BitsCount)]
        class ConvertHelper
        {
            [FieldOffset(0)]
            private double doubleForm;
            [FieldOffset(0)]
            private long longForm;

            public double DoubleForm
            {
                set
                {
                    this.doubleForm = value;
                }
            }

            public long LongForm
            {
                get
                {
                    return this.longForm;
                }
            }
        }
    }
}
