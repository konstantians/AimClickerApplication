using System.Reflection;
using System.Windows.Forms;

namespace UIAssignment
{
    public static class DoubleBufferingForForms
    {
        public static void SetDoubleBuffer(Control control, bool doubleBuffered)
        {
            try
            {
                typeof(Control).InvokeMember("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null, control, new object[] { doubleBuffered });
            }
            catch
            {
                MessageBox.Show("Something Went Wrong!");
            }
        }
    }
}
