using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Reflection;
using System.Drawing;

namespace DacII.Util
{
    /// <summary>
    /// ChangeFormCulture provides methods to change the culture used by a single or all forms in an application
    /// </summary>
    public class ChangeFormCulture
    {
        /// <summary>
        /// ChangeAllForms changes the culture of all existing forms in the application
        /// </summary>
        /// <param name="culture">The culture name to change the forms to</param>
        public static void ChangeAllForms(string culture)
        {
            FormCollection forms = Application.OpenForms;
            foreach (Form form in forms)
            {
                ChangeForm(form, culture);
            }
        }

        /// <summary>
        /// ChangeForm changes the culture of an existing form by forcing a reload of its resources
        /// </summary>
        /// <param name="form">The form for which the culture should be changed</param>
        /// <param name="culture">The culture name to change the form to</param>
        /// <remarks>This method changes the CurrentUICulture to the given culture</remarks>
        public static void ChangeForm(Form form, string culture)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            ComponentResourceManager resourceManager = new ComponentResourceManager(form.GetType());

            bool maximized=(form.WindowState == FormWindowState.Maximized);
            if (form.IsMdiContainer == false)
            {
                if (maximized)
                {
                    form.WindowState = FormWindowState.Normal;
                }
            }

            // apply resources to each control
            foreach (Control control in form.Controls)
            {
                ApplyControlResources(resourceManager, control);
            }

            // apply resources to the form
            if (form.IsMdiContainer == false)
            {
                int X = form.Location.X;
                int Y = form.Location.Y;
                
                resourceManager.ApplyResources(form, "$this");

                form.Location = new Point(X, Y);

                if (maximized)
                {
                    form.WindowState = FormWindowState.Maximized;
                }
            }

            ApplyMenuResources(resourceManager, form);
        }

        private static void ApplyControlResources(ComponentResourceManager resourceManager, Control control)
        {
            foreach (Control subcontrol in control.Controls)
            {
                ApplyControlResources(resourceManager, subcontrol);
            }

            if (control.GetType().FullName == "System.Windows.Forms.ListView")
            {
                ListView lv = (ListView)control;
                foreach (ColumnHeader ch in lv.Columns)
                {
                    resourceManager.ApplyResources(ch, ch.Tag.ToString());
                }
                resourceManager.ApplyResources(control, control.Name);
            }
            else
            {
                resourceManager.ApplyResources(control, control.Name);
            }
        }

        private static void ApplyMenuResources(ComponentResourceManager resourceManager, ToolStripMenuItem menuItem)
        {
            foreach (ToolStripMenuItem subItem in menuItem.DropDownItems)
            {
                resourceManager.ApplyResources(subItem, subItem.Name);
                ApplyMenuResources(resourceManager, subItem);
            }
        }

        private static void ApplyMenuResources(ComponentResourceManager resourceManager, Form form)
        {
            if (form.MainMenuStrip != null)
            {
                foreach(ToolStripMenuItem menuItem in form.MainMenuStrip.Items)
                {
                    ApplyMenuResources(resourceManager, menuItem);
                    resourceManager.ApplyResources(menuItem, menuItem.Name);
                    
                }
            }
            
            
            //if (form.Menu != null)
            //{
            //    FieldInfo[] fieldInfos = form.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            //    foreach (FieldInfo fieldInfo in fieldInfos)
            //    {
            //        if (fieldInfo.FieldType == typeof(System.Windows.Forms.MenuItem))
            //        {
            //            MenuItem menuItem = (MenuItem)fieldInfo.GetValue(form);
            //            resourceManager.ApplyResources(menuItem, fieldInfo.Name);
            //        }
            //    }
            //}
        }

        /// <summary>
        /// ChangeFormUsingInitializeComponent changes the culture of an existing form by removing all of its
        /// controls and adding them back by calling InitializeComponent
        /// </summary>
        /// <param name="form">The form for which the culture should be changed</param>
        /// <param name="culture">The culture name to change the form to</param>
        /// <remarks>This method changes the CurrentUICulture to the given culture</remarks>
        public static void ChangeFormUsingInitializeComponent(Form form, string culture)
        {
            // get the form's private InitializeComponent method
            MethodInfo initializeComponentMethodInfo = form.GetType().GetMethod("InitializeComponent", BindingFlags.Instance | BindingFlags.NonPublic);

            if (initializeComponentMethodInfo != null)
            {
                // the form has an InitializeComponent method that we can invoke

                // save all controls
                List<Control> controls = new List<Control>();
                foreach (Control control in form.Controls)
                {
                    controls.Add(control);
                }
                // remove all controls
                foreach (Control control in controls)
                {
                    form.Controls.Remove(control);
                }

                int X = form.Location.X;
                int Y = form.Location.Y;

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);

                // call the InitializeComponent method to add back controls
                initializeComponentMethodInfo.Invoke(form, new object[] { });

                form.Location = new Point(X, Y);
            }
        }
    }
}
