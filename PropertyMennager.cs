using System;
using System.Security.Policy;
using System.Security.Principal;
using System.Windows.Forms;

namespace FormDesiner
{
    public class PropertyMennager
    {
        public class PropertyTypes
        {
            public class BaseProperty
            {
                protected string name;
            }

            public abstract class StringProperty : BaseProperty, IProperty
            {
                private string value;

                public StringProperty(string name, string value)
                {
                    this.name = name;
                    this.value = value;
                }

                public void SetValue(object value)
                {
                    this.value = (string)value;
                }

                public object GetValue()
                {
                    return this.value;
                }

                public string GetPropertyName()
                {
                    return this.name;
                }

                public string GetPropertyType()
                {
                    return "string";
                }

                public virtual string GetLine()
                {
                    return this.name + " = " + this.value;
                }
            }

            public abstract class IntProperty : BaseProperty, IProperty
            {
                private int value;

                public IntProperty(string name, int value)
                {
                    this.name = name;
                    this.value = value;
                }

                public void SetValue(object value)
                {
                    this.value = (int)value;
                }

                public object GetValue()
                {
                    return this.value;
                }

                public string GetPropertyName()
                {
                    return this.name;
                }

                public string GetPropertyType()
                {
                    return "int";
                }

                public virtual string GetLine()
                {
                    return this.name + " = " + this.value;
                }
            }

            public abstract class BoolProperty : BaseProperty, IProperty
            {
                private bool value;

                public BoolProperty(string name, bool value)
                {
                    this.name = name;
                    this.value = value;
                }

                public void SetValue(object value)
                {
                    this.value = (bool)value;
                }

                public object GetValue()
                {
                    return this.value;
                }

                public string GetPropertyName()
                {
                    return this.name;
                }

                public string GetPropertyType()
                {
                    return "bool";
                }

                public virtual string GetLine()
                {
                    return this.name + " = " + this.value;
                }
            }

            public abstract class FloatProperty : BaseProperty, IProperty
            {
                private float value;

                public FloatProperty(string name, float value)
                {
                    this.name = name;
                    this.value = value;
                }

                public void SetValue(object value)
                {
                    this.value = (float)value;
                }

                public object GetValue()
                {
                    return this.value;
                }

                public string GetPropertyName()
                {
                    return this.name;
                }

                public string GetPropertyType()
                {
                    return "float";
                }

                public virtual string GetLine()
                {
                    return this.name + " = " + this.value;
                }
            }

            public abstract class PointProperty : BaseProperty, IProperty
            {
                private System.Drawing.Point value;

                public PointProperty(string name, System.Drawing.Point value)
                {
                    this.name = name;
                    this.value = value;
                }

                public void SetValue(object value)
                {
                    this.value = (System.Drawing.Point)value;
                }

                public object GetValue()
                {
                    return this.value;
                }

                public string GetPropertyName()
                {
                    return this.name;
                }

                public string GetPropertyType()
                {
                    return "System.Drawing.Point";
                }

                public virtual string GetLine()
                {
                    return this.name + " = new System.Drawing.Point(" + this.value.X + ", " + this.value.Y + ")";
                }
            }

            public abstract class SizeProperty : BaseProperty, IProperty
            {
                private System.Drawing.Size value;

                public SizeProperty(string name, System.Drawing.Size value)
                {
                    this.name = name;
                    this.value = value;
                }

                public void SetValue(object value)
                {
                    this.value = (System.Drawing.Size)value;
                }

                public object GetValue()
                {
                    return this.value;
                }

                public string GetPropertyName()
                {
                    return this.name;
                }

                public string GetPropertyType()
                {
                    return "System.Drawing.Size";
                }

                public virtual string GetLine()
                {
                    return this.name + " = new System.Drawing.Size(" + this.value.Width + ", " + this.value.Height +
                           ")";
                }
            }

            public abstract class SelectionProperty : BaseProperty, IProperty
            {
                protected string[] values;
                protected int selected;
                
                public SelectionProperty(string name, string[] values)
                {
                    this.name = name;
                    this.values = values;
                    this.selected = 0;
                }

                public SelectionProperty(string name, string[] values,int index)
                {
                    this.name = name;
                    this.values = values;
                    this.selected = index;
                }

                public void SetValue(object value)
                {
                    for(int i = 0; i < this.values.Length; i++)
                    {
                        if (this.values[i].Equals(value))
                        {
                            this.selected = i;
                            return;
                        }
                    }
                    //if the value is not in the list, add it to the list
                    this.selected = this.values.Length;
                    Array.Resize(ref this.values, this.values.Length + 1);
                    this.values[this.selected] = (string)value;
                }
                
                public object GetValue()
                {
                    return this.values[this.selected];
                }
                
                public string GetPropertyName()
                {
                    return this.name;
                }
                
                public string GetPropertyType()
                {
                    return "Selection";
                }
                
                public virtual string GetLine()
                {
                    return this.name + " = " + this.values[this.selected];
                }
                
                public object[] GetValues()
                {
                    return this.values;
                }
                
                public int GetSelected()
                {
                    return this.selected;
                }
            }
            
            public abstract class ColorProperty : BaseProperty, IProperty
            {
                private System.Drawing.Color value;
                //TODO: add system color and static color selection
    
                public ColorProperty(string name, System.Drawing.Color value)
                {
                    this.name = name;
                    this.value = value;
                }

                public void SetValue(object value)
                {
                    this.value = (System.Drawing.Color)value;
                }

                public object GetValue()
                {
                    return this.value;
                }

                public string GetPropertyName()
                {
                    return this.name;
                }

                public string GetPropertyType()
                {
                    return "Color";
                }

                public virtual string GetLine()
                {
                    return this.name + " = System.Drawing.Color.FromArgb(" + this.value.A + ", " + this.value.R + ", " + this.value.G + ", " + this.value.B + ")";
                }
            }
        }

        public class Properties
        {
            public class AutoSizeProperty : PropertyTypes.BoolProperty
            {
                public AutoSizeProperty(bool value) : base("AutoSize", value)
                {
                }
            }

            public class LocationProperty : PropertyTypes.PointProperty
            {
                public LocationProperty(System.Drawing.Point value) : base("Location", value)
                {
                }
            }

            public class NameProperty : PropertyTypes.StringProperty
            {
                public NameProperty(string value) : base("Name", value)
                {
                }
            }

            public class SizeProperty : PropertyTypes.SizeProperty
            {
                public SizeProperty(System.Drawing.Size value) : base("Size", value)
                {
                }
            }

            public class TabIndexProperty : PropertyTypes.IntProperty
            {
                public TabIndexProperty(int value) : base("TabIndex", value)
                {
                }
            }

            public class TextProperty : PropertyTypes.StringProperty
            {
                public TextProperty(string value) : base("Text", value)
                {
                }
            }

            public class AccessibleDescriptionProperty : PropertyTypes.StringProperty
            {
                public AccessibleDescriptionProperty(string value) : base("AccessibleDescription", value)
                {
                }
            }

            public class AccessibleNameProperty : PropertyTypes.StringProperty
            {
                public AccessibleNameProperty(string value) : base("AccessibleName", value)
                {
                }
            }

            public class AccessibleRoleProperty : PropertyTypes.SelectionProperty
            {
                public AccessibleRoleProperty(): base("AccessibleRole", Enum.GetNames(typeof(AccessibleRole)))
                {
                    
                }

                public AccessibleRoleProperty(string value) : base("AccessibleRole", Enum.GetNames(typeof(AccessibleRole)))
                {
                    this.SetValue(value);
                }
                
                public AccessibleRoleProperty(AccessibleRole value) : base("AccessibleRole", Enum.GetNames(typeof(AccessibleRole)))
                {
                    this.SetValue(value.ToString());
                }
                
                public AccessibleRoleProperty(int index) : base("AccessibleRole", Enum.GetNames(typeof(AccessibleRole)),index)
                {
                }
                
                public void SetValue(AccessibleRole value)
                {
                    this.SetValue(value.ToString());
                }
                
                public AccessibleRole GetAccessibleRole()
                {
                    return (AccessibleRole)Enum.Parse(typeof(AccessibleRole), this.values[this.selected]);
                }
                
                public override string GetLine()
                {
                    return this.name + " = System.Windows.Forms.AccessibleRole." + this.values[this.selected];
                }
            }
            
            public class BackColorProperty : PropertyTypes.ColorProperty
            {
                public BackColorProperty(System.Drawing.Color value) : base("BackColor", value)
                {
                }
            }

            public class BorderStyleProperty : PropertyTypes.SelectionProperty
            {
                public BorderStyleProperty() : base("BorderStyle", Enum.GetNames(typeof(BorderStyle)))
                {
                }
                
                public BorderStyleProperty(string value) : base("BorderStyle", Enum.GetNames(typeof(BorderStyle)))
                {
                    this.SetValue(value);
                }
                
                public BorderStyleProperty(BorderStyle value) : base("BorderStyle", Enum.GetNames(typeof(BorderStyle)))
                {
                    this.SetValue(value.ToString());
                }
                
                public BorderStyleProperty(int index) : base("BorderStyle", Enum.GetNames(typeof(BorderStyle)),index)
                {
                }
                
                public void SetValue(BorderStyle value)
                {
                    this.SetValue(value.ToString());
                }
                
                public BorderStyle GetBorderStyle()
                {
                    return (BorderStyle)Enum.Parse(typeof(BorderStyle), this.values[this.selected]);
                }
                
                public override string GetLine()
                {
                    return this.name + " = System.Windows.Forms.BorderStyle." + this.values[this.selected];
                }
            }
            
            public class CursorProperty : PropertyTypes.SelectionProperty
            {
                public CursorProperty() : base("Cursor", Enum.GetNames(typeof(Cursor)))
                {
                }
                
                public CursorProperty(string value) : base("Cursor", Enum.GetNames(typeof(Cursor)))
                {
                    this.SetValue(value);
                }
                
                public CursorProperty(Cursor value) : base("Cursor", Enum.GetNames(typeof(Cursor)))
                {
                    this.SetValue(value.ToString());
                }
                
                public CursorProperty(int index) : base("Cursor", Enum.GetNames(typeof(Cursor)),index)
                {
                }
                
                public void SetValue(Cursor value)
                {
                    this.SetValue(value.ToString());
                }
                
                public Cursor GetCursor()
                {
                    return (Cursor)Enum.Parse(typeof(Cursor), this.values[this.selected]);
                }
                
                public override string GetLine()
                {
                    return this.name + " = System.Windows.Forms.Cursor." + this.values[this.selected];
                }
            }
            
            public class FlatStyleProperty : PropertyTypes.SelectionProperty
            {
                public FlatStyleProperty() : base("FlatStyle", Enum.GetNames(typeof(FlatStyle)))
                {
                }
                
                public FlatStyleProperty(string value) : base("FlatStyle", Enum.GetNames(typeof(FlatStyle)))
                {
                    this.SetValue(value);
                }
                
                public FlatStyleProperty(FlatStyle value) : base("FlatStyle", Enum.GetNames(typeof(FlatStyle)))
                {
                    this.SetValue(value.ToString());
                }
                
                public FlatStyleProperty(int index) : base("FlatStyle", Enum.GetNames(typeof(FlatStyle)),index)
                {
                }
                
                public void SetValue(FlatStyle value)
                {
                    this.SetValue(value.ToString());
                }
                
                public FlatStyle GetFlatStyle()
                {
                    return (FlatStyle)Enum.Parse(typeof(FlatStyle), this.values[this.selected]);
                }
                
                public override string GetLine()
                {
                    return this.name + " = System.Windows.Forms.FlatStyle." + this.values[this.selected];
                }
            }
            
            //TODO:: make a font property
            
            //TODO:: make a image property
            
            
            
            public class ForeColorProperty : PropertyTypes.ColorProperty
            {
                public ForeColorProperty(System.Drawing.Color value) : base("ForeColor", value)
                {
                }
            }
        }

        public interface IProperty
        {
            void SetValue(object value);
            object GetValue();
            string GetPropertyName();
            string GetPropertyType();
            string GetLine();
        }

    }
}   